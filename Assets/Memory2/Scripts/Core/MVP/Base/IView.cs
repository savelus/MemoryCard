using System;
using Cysharp.Threading.Tasks;

namespace Memory2.Scripts.Core.MVP.Base {
    public interface IView {
        UniTask ShowView(Action onShow = null);
        UniTask HideView(Action onHide = null);
        void HideImmediate();
        void Dispose();
    }
}