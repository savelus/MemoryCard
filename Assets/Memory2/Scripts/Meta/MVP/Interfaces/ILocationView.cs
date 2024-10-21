using Memory2.Scripts.Core.MVP.Base;
using UnityEngine;

namespace Memory2.Scripts.Meta.MVP.Interfaces {
    public interface ILocationView : IWindowView {
        void SetLabel(string label);
        void AddLevel(Transform levelTransform);
    }
}