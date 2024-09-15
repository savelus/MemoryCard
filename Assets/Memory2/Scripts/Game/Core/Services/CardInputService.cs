using System.Collections.Generic;
using DG.Tweening;
using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Core.Storages;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Core.Services {
    public sealed class CardInputService {
        public event UnityAction CardsEnded;
        
        private readonly PointStorage _pointStorage;
        private readonly EnemyService _enemyService;
        private readonly DamageService _damageService;
        
        private CardPresenter _firstPickedCard;
        private CardPresenter _secondPickedCard;
        private HashSet<int> _activeCards = new();

        public CardInputService(PointStorage pointStorage, 
                                EnemyService enemyService,
                                DamageService damageService) {
            _pointStorage = pointStorage;
            _enemyService = enemyService;
            _damageService = damageService;
        }
        
        public void SubscribeAllCards(CardPresenter[] cardPresenters) {
            _firstPickedCard = null;
            _secondPickedCard = null;
            
            foreach (var cardPresenter in cardPresenters) {
                _activeCards.Add(cardPresenter.CardId);
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
            _damageService.DamageByCards(firstCard.CardData);
            
            _activeCards.Remove(firstCard.CardId);
            firstCard.RemoveCard();
            secondCard.RemoveCard();

            if (_activeCards.Count == 0) {
                CardsEnded?.Invoke();
            }
        }
    }
}