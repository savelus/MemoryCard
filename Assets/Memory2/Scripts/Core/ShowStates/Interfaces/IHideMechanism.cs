using System;
using UnityEngine;

namespace Memory2.Scripts.Core.ShowStates.Interfaces {
    public interface IHideMechanism {
        void Hide(GameObject controlObject, Action onClose = null);
        void HideImmediate(GameObject controlObject);
    }
}