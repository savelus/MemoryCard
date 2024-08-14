using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.View;
using R3;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Core.Presenters {
    public class CardPresenter {
        public ReactiveProperty<int> Damage;
        public ReactiveProperty<Color> Color;
        public ReactiveProperty<Sprite> Sprite;
        public event UnityAction<CardPresenter> CardClicked;
        
        private CardData _cardData;
        private CardView _cardView;
        private Color _backColor;

        public CardPresenter(CardData cardPrefab) {
            _cardData = cardPrefab;
            Damage = new ReactiveProperty<int>(cardPrefab.Damage);
            Color = new ReactiveProperty<Color>(cardPrefab.Color);
            Sprite = new ReactiveProperty<Sprite>(cardPrefab.Sprite);
        }

        public int CardId => _cardData.Id;
//TODO перенести все в конструктор
        public void Initialize(CardView cardView, Color cardsConfigCardBackSideColor) {
            _cardView = cardView;
            _backColor = cardsConfigCardBackSideColor;
            
            Damage.Subscribe(cardView.ChangeDamage);
            Color.Subscribe(cardView.ChangeColor);
            Sprite.Subscribe(cardView.ChangeSprite);

            cardView.CardClicked += () => CardClicked?.Invoke(this);

            CloseCard();
        }

        public void OpenCard() {
            _cardView.OpenCard(Color.Value);
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
    }
}