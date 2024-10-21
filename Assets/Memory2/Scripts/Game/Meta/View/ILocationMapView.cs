using Memory2.Scripts.Game.Global.MVP.WindowService;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.View {
    public interface ILocationMapView : IWindowView {
        void AddLocationButton(Transform buttonTransform);
    }
}