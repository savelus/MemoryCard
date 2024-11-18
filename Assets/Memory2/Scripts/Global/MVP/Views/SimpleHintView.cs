using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.VisibilityMechanisms;
using Memory2.Scripts.Global.MVP.Interfaces;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Memory2.Scripts.Global.MVP.Views {
    public class SimpleHintView : BaseWindow, ISimpleHintView {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private RectTransform _root;
        [SerializeField] private TextMeshProUGUI _hintText;
        [SerializeField] private CanvasScaler _scaler;

        protected override void OnEnable() {
            ChangeShowMechanism(new FadeShowMechanism(_group));
            ChangeHideMechanism(new FadeHideMechanism(_group));
        }

        public void Init(string text, Vector2 position) {
            _hintText.text = text;
            _root.localPosition = position;
        }

        public Vector2 GetSize() {
            return _root.sizeDelta;
        }
    }
}