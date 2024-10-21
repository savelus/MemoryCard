using System;
using Cysharp.Threading.Tasks;

namespace Memory2.Scripts.Game.Global.MVP.WindowService {
    public interface IView {
        UniTask ShowView(Action onShow = null);
        UniTask HideView(Action onHide = null);
        void HideImmediate();
        void Dispose();
    }
}