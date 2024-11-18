using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.Enums;
using Memory2.Scripts.Core.MVP;
using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.Signals;
using Memory2.Scripts.Global.Configs;
using Memory2.Scripts.Global.MVP.Context;
using Memory2.Scripts.Global.MVP.Enums;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Global.MVP.WindowService {
    public class WindowService : IWindowService,
        IDisposable {
        private readonly SignalBus _signalBus;
        private readonly WindowsConfigs _config;
        private readonly WindowFactory _windowFactory;
        private readonly ContextService _contextService;
        private Dictionary<UIContainerType, GameObject> _containers;
        private readonly Dictionary<WindowKey, UIWindow> _windowsByUid;
        private readonly Dictionary<WindowKey, UIWindow> _activeWindows;
        private readonly Dictionary<WindowKey, Task> _loadCache;

        private Dictionary<GameContext, List<WindowKey>> _windowsIntoContext = new();

        public WindowService(SignalBus signalBus,
            WindowsConfigs config,
            WindowFactory windowFactory,
            ContextService contextService) {
            _signalBus = signalBus;
            _config = config;
            _windowFactory = windowFactory;
            _contextService = contextService;

            _windowsByUid = new();
            _loadCache = new();
            SubscribeSignals();
            _contextService.OnContextUnRegister += ClearContext;
        }

        public bool IsWindowOpened(WindowKey key) {
            return IsWindowLoaded(key) && _windowsByUid[key].State == WindowState.Opened;
        }

        public void RegisterContainers(List<UIContainerToGameObjectElement> containers) {
            _containers ??= new();

            foreach (var element in containers) {
                if (_containers.ContainsKey(element.Key)) continue;

                _containers.Add(element.Key, element.Holder);
            }
        }

        private async void OpenWindow(WindowKey key, IWindowData data) {
            var windowPair = await PreloadWindow(key);

            var window = windowPair.window;

            //TODO check state = opened
            await window.Initialize(data, windowPair.isInitialized);
            await window.Open();
        }

        private void ClearContext(GameContext context) {
            if (!_windowsIntoContext.TryGetValue(context, out var windowKeys)) return;

            foreach (var key in windowKeys) {
                if (!_windowsByUid.ContainsKey(key)) continue;

                CloseWindow(key, true).Forget();
                var window = _windowsByUid[key];

                window.DestroyView();
                _windowsByUid.Remove(key);
            }

            _windowsIntoContext[context].Clear();
        }

        private async UniTask<(UIWindow window, bool isInitialized)> PreloadWindow(WindowKey key) {
            var config = GetWindowConfig(key);

            UIWindow window;
            bool isInitialized = false;

            if (_loadCache.ContainsKey(key)) {
                var task = _loadCache[key];
                await task;
            }

            if (_windowsByUid.ContainsKey(key)) {
                window = _windowsByUid[key];
                isInitialized = true;
            }
            else {
                Transform transform = GetUIContainer(UIContainerType.WindowsContainer);

                var task = _windowFactory.Create(config, transform, key, Vector3.zero).AsTask();
                _loadCache.Add(key, task);

                window = await task;

                _loadCache.Remove(key);

                window.SubscribeDestroy(OnDestroyView);

                _windowsByUid.Add(key, window);
            }

            if (_windowsIntoContext.ContainsKey(config.Context)) {
                _windowsIntoContext[config.Context].Add(key);
            }
            else {
                List<WindowKey> list = new() { key };
                _windowsIntoContext[config.Context] = list;
            }

            window.InitializeDependencies();
            window.PreloadInitialize();
            window.CloseImmediate();

            if (!isInitialized) {
                await window.InitializeOnce();
            }

            return (window, isInitialized);
        }

        public bool IsWindowLoaded(WindowKey key) => _windowsByUid.ContainsKey(key);

        private async UniTask CloseWindow(WindowKey key, bool immediate = false) {
            if (!_windowsByUid.TryGetValue(key, out UIWindow window)) {
                Debug.LogWarning($"Window is not active, uid: {key}");
            }

            if (CanBeClosed(window)) {
                if (immediate) {
                    window.CloseImmediate();
                }
                else {
                    await window.Close();
                }
            }
            else {
                Debug.LogWarning($"Can't close the window with uid: {key}");
            }
        }


        private void SubscribeSignals() {
            _signalBus.Subscribe<OpenWindowSignal>(signal => OpenWindow(signal.Key, signal.Data));
            _signalBus.Subscribe<CloseWindowSignal>(signal => CloseWindow(signal.Key));
            _signalBus.Subscribe<PreloadWindowSignal>(signal => PreloadWindow(signal.Key));
        }

        private WindowConfig GetWindowConfig(WindowKey key) {
            _config.WindowsConfig.TryGetValue(key, out WindowConfig windowData);
            if (windowData == null) {
                throw new WarningException("WindowConfig not found");
            }

            return windowData;
        }

        private Transform GetUIContainer(UIContainerType type) {
            _containers.TryGetValue(type, out GameObject container);

            //TODO default container or throw exception
            return container != null ? container.transform : new GameObject().transform;
        }

        private void OnDestroyView(string uid) { }

        private static bool CanBeClosed(UIWindow window)
            => window?.State == WindowState.Opened;

        public void Dispose() {
            foreach (var windowPair in _windowsByUid) {
                CloseWindow(windowPair.Key).Forget();
            }

            _contextService.OnContextUnRegister -= ClearContext;
        }
    }
}