using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.VisibilityMechanisms;
using Memory2.Scripts.Meta.MVP.Interfaces;
using TMPro;
using UnityEngine;

namespace Memory2.Scripts.Meta.MVP.View {
    public class LocationMapView : BaseWindow, ILocationMapView {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Transform _locationsButtonRoot;

        protected override void OnEnable() {
            ChangeShowMechanism(new FadeShowMechanism(_group));
            ChangeHideMechanism(new FadeHideMechanism(_group));
        }

        public void AddLocationButton(Transform buttonTransform) {
            buttonTransform.SetParent(_locationsButtonRoot, false);
        }
    }
}