using System;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.Enums;
using Memory2.Scripts.Core.MVP.Context;
using R3;
using Zenject;

namespace Memory2.Scripts.Core.MVP.Base {
    public abstract class BasePresenter<TView, TData> : IBasePresenter<WindowKey>
        where TView : IView
        where TData : IWindowData {
        private ReactiveProperty<WindowState> _state;
        protected TData WindowData;
        protected TView View;

        protected WindowState State => _state.Value;

        private IContextService _contextService;
        [Inject] protected SignalBus SignalBus;

        protected BasePresenter(IContextService service) {
            _contextService = service;
        }

        protected T Resolve<T>(GameContext context) {
            var container = _contextService.ResolveContainer(context);
            return container.Resolve<T>();
        }

        public void ProvideState(ReactiveProperty<WindowState> state) {
            _state = state;
        }

        public virtual void PreloadInitialize() { }

        public virtual async UniTask Initialize(IWindowData data, WindowKey key, bool isInit) {
            WindowData = (TData)data;

            await InitializeData();
        }

        public virtual async UniTask InitializeOnce() { }

        public void InitializeView(IView view) {
            View = (TView)view;
        }

        public async UniTask Open() {
            await LoadContent();
            await View.ShowView();
        }

        public void SubscribeToSignal<TSignal>(Action<TSignal> action) {
            SignalBus.Subscribe(action);
        }

        public async UniTask Close() {
            await View.HideView();
        }

        protected virtual async UniTask InitializeData() { }

        protected virtual async UniTask LoadContent() { }

        public virtual void InitDependencies() { }

        public virtual async UniTask Dispose() { }

        protected void FireSignal<TSignal>(TSignal signal) {
            SignalBus.Fire(signal);
        }
    }
}