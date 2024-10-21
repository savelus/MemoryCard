using System;
using Memory2.Scripts.Core.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Core.VisibilityMechanisms {
    public class SetActiveHideMechanism : IHideMechanism {
        public void Hide(GameObject controlObject, Action _) {
            controlObject.SetActive(false);
        }

        public void HideImmediate(GameObject controlObject) {
            controlObject.SetActive(false);
        }
    }
}