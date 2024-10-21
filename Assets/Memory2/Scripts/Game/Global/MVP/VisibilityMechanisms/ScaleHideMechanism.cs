using System;
using DG.Tweening;
using Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms {
    public class ScaleHideMechanism : IHideMechanism {
        public void Hide(GameObject controlObject, Action onClose = null) {
            var transform = controlObject.transform;

            DOTween.Sequence()
                .Append(transform.DOScale(Vector3.zero, 0.3f))
                .AppendCallback(() => { onClose?.Invoke(); });
        }

        public void HideImmediate(GameObject controlObject) {
            var transform = controlObject.transform;

            transform.localScale = Vector3.zero;
        }
    }
}