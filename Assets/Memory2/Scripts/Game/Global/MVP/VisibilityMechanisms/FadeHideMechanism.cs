using System;
using DG.Tweening;
using Memory2.Scripts.Game.Global.MVP.ShowStates.Interfaces;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms {
    public class FadeHideMechanism : IHideMechanism {
        private readonly CanvasGroup _group;

        public FadeHideMechanism(CanvasGroup group) {
            _group = group;
        }
        
        public void Hide(GameObject controlObject, Action onShow = null) {
            _group.DOFade(0, 0.5f);
            _group.blocksRaycasts = false;
            _group.interactable = false;
        }

        public void HideImmediate(GameObject controlObject) {
            _group.alpha = 0;
            _group.blocksRaycasts = false;
            _group.interactable = false;
        }
    }
}