using Memory2.Scripts.Game.Global.MVP.Base;
using Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms;
using TMPro;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.View {
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