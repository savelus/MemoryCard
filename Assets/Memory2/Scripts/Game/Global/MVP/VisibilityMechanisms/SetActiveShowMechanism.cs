using System;
using Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms {
    public class SetActiveShowMechanism : IShowMechanism {
        public void Show(GameObject controlObject, Action _) {
            controlObject.SetActive(true);
        }

        public void ShowImmediate(GameObject controlObject) {
            controlObject.SetActive(true);
        }
    }
}