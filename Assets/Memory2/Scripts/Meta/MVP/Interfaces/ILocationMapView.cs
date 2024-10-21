using Memory2.Scripts.Core.MVP.Base;
using UnityEngine;

namespace Memory2.Scripts.Meta.MVP.Interfaces {
    public interface ILocationMapView : IWindowView {
        void AddLocationButton(Transform buttonTransform);
    }
}