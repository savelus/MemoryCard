using System;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces {
    public interface IHideMechanism {
        void Hide(GameObject controlObject, Action onClose = null);
        void HideImmediate(GameObject controlObject);
    }
}