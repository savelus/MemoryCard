using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.View;
using Memory2.Scripts.Game.Global.Configs.Elements;
using R3;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Memory2.Scripts.Game.Core.Presenters {
    public class CardPresenter {
        public event UnityAction<CardPresenter> CardClicked;

        public CardData CardData { get; private set; }
        private CardView _cardView;

        private Color _backColor;
        private readonly Sprite _elementSprite;

        public int CardId => CardData.Id;

        public CardPresenter(CardView cardView, CardData cardData, Color backColor, Sprite elementSprite) {
            _cardView = cardView;
            CardData = cardData;
            _backColor = backColor;
            _elementSprite = elementSprite;
        }

        public void Initialize(int cardIndex) {
            CardClicked = null;
            _cardView.ChangeDamage(CardData.Damage);
            _cardView.SubscribeOnCardClicked(() => CardClicked?.Invoke(this));
            SetSiblingIndex(cardIndex);
            CloseCard();
        }

        public void OpenCard() {
            _cardView.OpenCard(CardData.Color, _elementSprite);
        }

        public void CloseCard() {
            _cardView.CloseCard(_backColor);
        }
        
        public void RemoveCard() {
            CardClicked = null;
            _cardView.Disable();
        }

        public int GetDamage() {
            return CardData.Damage;
        }

        public void SetSiblingIndex(int index) {
            _cardView.transform.SetSiblingIndex(index);
        }
    }
}