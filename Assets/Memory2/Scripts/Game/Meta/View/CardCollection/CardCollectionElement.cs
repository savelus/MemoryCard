using Memory2.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Meta.View.CardCollection {
    public class CardCollectionElement : MonoBehaviour {
        [SerializeField] private Toggle _toggle;
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private Image _cardView;
        [SerializeField] private Image _background;

        public void Init(bool toggleState, string cardName, string levelText, Sprite sprite, Color bgColor, UnityAction<bool> onToggleClicked) {
            _toggle.isOn = toggleState;
            _name.text = cardName;
            _cardView.sprite = sprite;
            _level.text = levelText;
            _background.color = bgColor;
            _toggle.Subscribe(onToggleClicked);
        }
    }
}