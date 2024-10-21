using System;
using Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms {
    public class SetActiveHideMechanism : IHideMechanism {
        public void Hide(GameObject controlObject, Action _) {
            controlObject.SetActive(false);
        }

        public void HideImmediate(GameObject controlObject) {
            controlObject.SetActive(false);
        }
    }
}