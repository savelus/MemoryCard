using System;
using DG.Tweening;
using Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms {
    public class ScaleShowMechanism : IShowMechanism {
        public void Show(GameObject controlObject, Action onShow = null) {
            var transform = controlObject.transform;

            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, 0.3f);
        }

        public void ShowImmediate(GameObject controlObject) {
            var transform = controlObject.transform;

            transform.localScale = Vector3.zero;
        }
    }
}