using System;
using Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms {
    public class CustomHideMechanism : IHideMechanism {
        private readonly Action _hideAction;

        public CustomHideMechanism(Action hideAction) {
            _hideAction = hideAction;
        }

        public void Hide(GameObject controlObject, Action onClose = null) {
            _hideAction.Invoke();
        }

        public void HideImmediate(GameObject controlObject) {
            _hideAction.Invoke();
        }
    }
}