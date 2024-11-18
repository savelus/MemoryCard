using Memory2.Scripts.Core.MVP.Base;
using UnityEngine;

namespace Memory2.Scripts.Global.MVP.Interfaces {
    public interface ISimpleHintView : IWindowView {
        void Init(string text, Vector2 position);
        Vector2 GetSize();
    }
}