using DG.Tweening;
using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Core.Storages;

namespace Memory2.Scripts.Game.Core.Services {
    public class CardInputService {
        private readonly PointStorage _pointStorage;
        private CardPresenter _firstPickedCard;
        private CardPresenter _secondPickedCard;
        private CardPresenter[] _cardPresenters;

        public CardInputService(PointStorage pointStorage) {
            _pointStorage = pointStorage;
        }
        
        public void SubscribeAllCards(CardPresenter[] cardPresenters) {
            _cardPresenters = cardPresenters;
            
            foreach (var cardPresenter in cardPresenters) {
                cardPresenter.CardClicked += OnCardClicked;
            }
        }

        private void OnCardClicked(CardPresenter clickedCard) {
            if (_firstPickedCard != null && _secondPickedCard != null) return;
            clickedCard.OpenCard();
            
            if (_firstPickedCard == null) {
                _firstPickedCard = clickedCard;
                return;
            }

            if (_firstPickedCard == clickedCard) return;
            
            _secondPickedCard = clickedCard;

            if (!TryPairCard()) {
                var localFirstCard = _firstPickedCard;
                var localSecondCard = _secondPickedCard;
            
                var sequence = DOTween
                    .Sequence()
                    .AppendInterval(0.5f)
                    .AppendCallback(()=> {
                        CloseCards(localFirstCard, localSecondCard);
                    });
                sequence.Play();
            }
            
            _firstPickedCard = null;
            _secondPickedCard = null;
        }
        private void CloseCards(CardPresenter firsCard, CardPresenter secondCard) {
            firsCard.CloseCard();
            secondCard.CloseCard();
        }

        private bool TryPairCard() {
            if (_firstPickedCard.CardId != _secondPickedCard.CardId) return false;
            var localFirstCard = _firstPickedCard;
            var localSecondCard = _secondPickedCard;
                
            var sequence = DOTween
                .Sequence()
                .AppendInterval(0.5f)
                .AppendCallback(()=> {
                    PairCard(localFirstCard, localSecondCard);
                });
            sequence.Play();
            return true;
        }

        private void PairCard(CardPresenter firstCard, CardPresenter secondCard) {
            _pointStorage.AddPoints(firstCard.GetDamage() + secondCard.GetDamage());
            firstCard.RemoveCard();
            secondCard.RemoveCard();
        }
    }
}