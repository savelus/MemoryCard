using Cysharp.Threading.Tasks;
using Memory2.Scripts.Game.Global.MVP.Context;
using Memory2.Scripts.Game.Global.MVP.Enums;
using Memory2.Scripts.Game.Global.MVP.Signals;
using Memory2.Scripts.Game.Global.MVP.WindowService;

namespace Memory2.Scripts.Game.Global.MVP.Base {
    public class BaseWindowPresenter<TView, TData> : BasePresenterNEW<TView, TData>
                                                     where TView : IWindowView
                                                     where TData : IWindowData {
        private WindowKey _key;

        protected BaseWindowPresenter(ContextService service) : base(service) {
        }

        public override async UniTask Initialize(IWindowData data, WindowKey key, bool isInit) {
            WindowData = (TData) data;

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