using Memory2.Scripts.Game.Global.MVP;
using Memory2.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Meta.View {
    public class LocationView : BaseWindow {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Transform _levelContainer;
        
        public void SetLabel(string label) {
            _label.text = label;
        }

        public void AddLevel(Transform levelTransform) {
            levelTransform.SetParent(_levelContainer, false);
        }
        
        public void SubscribeOnCloseButton(UnityAction action) {
            _closeButton.Subscribe(action);
        }
    }
}