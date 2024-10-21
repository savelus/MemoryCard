using System;
using DG.Tweening;
using Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms {
    public class FadeShowMechanism : IShowMechanism {
        private readonly CanvasGroup _group;

        public FadeShowMechanism(CanvasGroup group) {
            _group = group;
        }
        
        public void Show(GameObject controlObject, Action onClose = null) {
            _group.DOFade(1, 0.5f);
            _group.blocksRaycasts = true;
            _group.interactable = true;
        }

        public void ShowImmediate(GameObject controlObject) {
            _group.alpha = 1;
            _group.blocksRaycasts = true;
            _group.interactable = true;
        }
    }
}