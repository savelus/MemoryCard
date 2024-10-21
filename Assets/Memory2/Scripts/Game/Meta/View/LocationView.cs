using Memory2.Scripts.Game.Global.MVP;
using Memory2.Scripts.Game.Global.MVP.Base;
using Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms;
using Memory2.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Meta.View {
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