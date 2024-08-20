using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.View;
using R3;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Core.Presenters {
    public class CardPresenter {
        public event UnityAction<CardPresenter> CardClicked;
        
        private CardData _cardData;
        private CardView _cardView;
        private Color _backColor;

        public int CardId => _cardData.Id;

        public CardPresenter(CardView cardView, CardData cardData, Color backColor) {
            _cardView = cardView;
            _cardData = cardData;
            _backColor = backColor;
        }
        
        public void Initialize(int cardIndex) {
            CardClicked = null;
            _cardView.ChangeDamage(_cardData.Damage);
            _cardView.SubscribeOnCardClicked(() => CardClicked?.Invoke(this));
            SetSiblingIndex(cardIndex);
            CloseCard();
        }

        public void OpenCard() {
            _cardView.OpenCard(_cardData.Color);
        }

        public void CloseCard() {
            _cardView.CloseCard(_backColor);
        }
        
        public void RemoveCard() {
            CardClicked = null;
            _cardView.Disable();
        }

        public int GetDamage() {
            return _cardData.Damage;
        }

        public void SetSiblingIndex(int index) {
            _cardView.transform.SetSiblingIndex(index);
        }
    }
}