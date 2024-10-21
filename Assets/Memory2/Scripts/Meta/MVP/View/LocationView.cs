using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.VisibilityMechanisms;
using Memory2.Scripts.Meta.MVP.Interfaces;
using TMPro;
using UnityEngine;

namespace Memory2.Scripts.Meta.MVP.View {
    public class LocationView : BaseWindow, ILocationView {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Transform _levelContainer;

        protected override void OnEnable() {
            ChangeShowMechanism(new FadeShowMechanism(_group));
            ChangeHideMechanism(new FadeHideMechanism(_group));
        }

        public void SetLabel(string label) {
            _label.text = label;
        }

        public void AddLevel(Transform levelTransform) {
            levelTransform.SetParent(_levelContainer, false);
        }
    }
}