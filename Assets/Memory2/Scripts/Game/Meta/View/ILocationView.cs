using Memory2.Scripts.Game.Global.MVP.WindowService;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Meta.View {
    public interface ILocationView : IWindowView {
        void SetLabel(string label);
        void AddLevel(Transform levelTransform);
    }
}