using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.Signals;
using Memory2.Scripts.Global.MVP.Context;
using Memory2.Scripts.Global.MVP.Enums;

namespace Memory2.Scripts.Core.MVP.Base {
    public class BaseWindowPresenter<TView, TData> : BasePresenter<TView, TData>
        where TView : IWindowView
        where TData : IWindowData {
        private WindowKey _key;

        protected BaseWindowPresenter(ContextService service) : base(service) { }

        public override async UniTask Initialize(IWindowData data, WindowKey key, bool isInit) {
            WindowData = (TData)data;

            _key = key;
            await InitializeData();
            View.OnClickCloseButton = null;
            View.OnClickCloseButton += () => SignalBus.Fire(new CloseWindowSignal(key));
        }

        protected void CloseThisWindow() {
            SignalBus.Fire(new CloseWindowSignal(_key));
        }
    }
}