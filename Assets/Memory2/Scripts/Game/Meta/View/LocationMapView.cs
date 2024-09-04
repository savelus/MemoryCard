using System;
using Memory2.Scripts.Game.Global.MVP;
using Memory2.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Meta.View {
    public class LocationMapView : BaseWindow {
        [SerializeField] private TextMeshProUGUI _label;
        [SerializeField] private Transform _locationsButtonRoot;

        public void SetLabelText(string text) {
            _label.text = text;
        }
        
        public void AddLocationButton(Transform buttonTransform) {
            buttonTransform.SetParent(_locationsButtonRoot, false);
        }

        public void SubscribeOnCloseButton(UnityAction action) {
            _closeButton.Subscribe(action);
        }
    }
}