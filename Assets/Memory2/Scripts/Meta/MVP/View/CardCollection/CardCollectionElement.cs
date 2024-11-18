using Memory2.Scripts.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Meta.MVP.View.CardCollection {
    public class CardCollectionElement : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private TextMeshProUGUI _level;
        [SerializeField] private Image _cardView;
        [SerializeField] private Image _background;
        
        [SerializeField] private Button _toggleButton;
        [SerializeField] private Image _toggleImage;

        private bool _currentState;
        
        public void Init(bool toggleState, string cardName, string levelText, Sprite sprite, Color bgColor,
            UnityAction<bool> onToggleClicked) {
            _currentState = toggleState;
            _toggleImage.gameObject.SetActive(toggleState);
            _name.text = cardName;
            _cardView.sprite = sprite;
            _level.text = levelText;
            _background.color = bgColor;
            _toggleButton.Subscribe(() => onToggleClicked(!_currentState));
        }

        public void SetToggleState(bool state) {
            _currentState = state;
            _toggleImage.gameObject.SetActive(state);
        }
    }
}