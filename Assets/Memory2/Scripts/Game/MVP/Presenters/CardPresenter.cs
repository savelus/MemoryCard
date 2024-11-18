using Memory2.Scripts.Global;
using Memory2.Scripts.Global.Data;
using Memory2.Scripts.Global.MVP.Views;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.MVP.Presenters {
    public class CardPresenter {
        public event UnityAction<CardPresenter> CardClicked;

        public CardInfo CardInfo { get; private set; }
        private CardView _cardView;

        private Color _backColor;
        private readonly Sprite _elementSprite;

        public int CardId => CardInfo.Id;

        public CardPresenter(CardView cardView, CardInfo cardInfo, Color backColor, Sprite elementSprite) {
            _cardView = cardView;
            CardInfo = cardInfo;
            _backColor = backColor;
            _elementSprite = elementSprite;
        }

        public void Initialize(int cardIndex) {
            CardClicked = null;
            _cardView.ChangeDamage(CardInfo.Damage);
            _cardView.SubscribeOnCardClicked(() => CardClicked?.Invoke(this));
            SetSiblingIndex(cardIndex);
            CloseCard();
        }

        public void OpenCard() {
            _cardView.OpenCard(CardInfo.Color, _elementSprite);
        }

        public void CloseCard() {
            _cardView.CloseCard(_backColor);
        }

        public void RemoveCard() {
            CardClicked = null;
            _cardView.Disable();
        }

        public int GetDamage() {
            return CardInfo.Damage;
        }

        public void SetSiblingIndex(int index) {
            _cardView.transform.SetSiblingIndex(index);
        }
    }
}