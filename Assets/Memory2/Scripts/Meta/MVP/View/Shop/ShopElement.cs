using Memory2.Scripts.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Meta.MVP.View.Shop {
    public class ShopElement : MonoBehaviour {
        [SerializeField] private GameObject _openState;
        [SerializeField] private GameObject _closeState;

        [SerializeField] private TextMeshProUGUI _costText;
        [SerializeField] private TextMeshProUGUI _cardNameText;

        [SerializeField] private Image _cardImage;

        [SerializeField] private Button _buyButton;

        public void Init(bool isOpen, string cost, string cardName, Sprite cardSprite, UnityAction onBuyClick) {
            SwitchState(isOpen);
            SetCost(cost);
            SetName(cardName);
            SetImage(cardSprite);

            _buyButton.Subscribe(onBuyClick);
        }

        private void SwitchState(bool isOpen) {
            _closeState.SetActive(!isOpen);
        }

        private void SetCost(string cost) {
            _costText.text = cost;
        }

        private void SetName(string cardName) {
            _cardNameText.text = cardName;
        }

        private void SetImage(Sprite sprite) {
            _cardImage.sprite = sprite;
        }
    }
}