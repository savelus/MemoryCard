using System;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.Enums;
using Memory2.Scripts.Core.MVP;
using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Global.Configs;
using Memory2.Scripts.Global.MVP.Enums;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Memory2.Scripts.Global.MVP.WindowService {
    public class UIWindow {
        private readonly IBasePresenter<WindowKey> _controller;
        private readonly WindowConfig _data;
        private readonly WindowKey _key;
        private readonly BaseView _view;

        public WindowState State { get; private set; }
        public string Uid { get; }

        public UIWindow(string uid, WindowConfig data, WindowKey key, IBasePresenter<WindowKey> controller,
            BaseView view) {
            Uid = uid;

            _controller = controller;
            _data = data;
            _key = key;
            _view = view;

            State = WindowState.Created;
        }

        public async UniTask Open() {
            await _controller.Open();
            State = WindowState.Opened;
        }

        public async UniTask Close() {
            await _controller.Dispose();
            _view.Dispose();
            await _controller.Close();
            State = WindowState.Closed;
        }

        public void CloseImmediate() {
            _view.HideImmediate();
        }

        public async UniTask Initialize(IWindowData data, bool isInit) {
            await _controller.Initialize(data, _key, isInit);
            _view.Initialize(Uid);
        }

        public void SetPlace(Transform parent, Vector3 position) {
            Transform transform = _view.transform;
            transform.SetParent(parent, false);
            transform.localPosition = position;
        }

        public void SubscribeDestroy(Action<string> onDestroyView) {
            _view.OnDestroyView += onDestroyView;
        }

        public void PreloadInitialize() {
            _controller.InitializeView(_view);
            _controller.PreloadInitialize();
        }

        public void InitializeDependencies() {
            _controller.InitDependencies();
        }

        public async UniTask InitializeOnce() {
            await _controller.InitializeOnce();
        }

        public void DestroyView() {
            Object.Destroy(_view.gameObject);
        }
    }
}