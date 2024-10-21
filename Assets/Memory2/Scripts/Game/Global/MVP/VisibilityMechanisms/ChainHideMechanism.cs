using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms {
    public class ChainHideMechanism : IHideMechanism {
        private readonly List<IHideMechanism> _hideMechanisms;

        public ChainHideMechanism(params IHideMechanism[] mechanisms) {
            _hideMechanisms = new(mechanisms);
        }

        public void Hide(GameObject controlObject, Action onClose = null) {
            foreach (var mechanism in _hideMechanisms) mechanism.Hide(controlObject, onClose);
        }

        public void HideImmediate(GameObject controlObject) {
            foreach (var mechanism in _hideMechanisms) mechanism.HideImmediate(controlObject);
        }
    }
}