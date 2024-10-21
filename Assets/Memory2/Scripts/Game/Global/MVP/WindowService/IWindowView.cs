using System;

namespace Memory2.Scripts.Game.Global.MVP.WindowService {
    public interface IWindowView : IView {
        void ChangeHeader(string header);
        void Initialize(string uid);
        Action<string> OnDestroyView { get; set; }
        Action OnClickCloseButton { get; set; }
        void SubscribeToClose(Action onClose);
    }
}