using System.Collections.Generic;
using System.Linq;
using Memory2.Scripts.Game.Global.Configs.Cards;
using Memory2.Scripts.Game.Global.Data;
using Memory2.Scripts.Game.Global.Storages;
using Memory2.Scripts.Game.Meta.Storages;
using ObservableCollections;
using R3;
using Zenject;

namespace Memory2.Scripts.Game.Global.Services {
    public sealed class CardCollectionService : IInitializable {
        public IObservableCollection<CardInfo> UnlockedCards => _unlockedCards;
        
        private readonly ObservableList<CardInfo> _unlockedCards = new();
        private readonly Dictionary<int, CardInfo> _unlockedCardsMap = new();
        
        private readonly CardCollectionStorage _cardCollectionStorage;
        private readonly CardsConfig _cardsConfig;

        public CardCollectionService(CardCollectionStorage cardCollectionStorage,
                                     CardsConfig cardsConfig) {
            _cardCollectionStorage = cardCollectionStorage;
            _cardsConfig = cardsConfig;
        }

        void IInitializable.Initialize() {
            PrepareCards();
        }
        
        
        public ObservableList<CardInfo> GetCardCollection() {
            return _unlockedCards;
        }

        public void BuyCard(int cardId) {
            var cardInfo = InitCard(cardId);
            cardInfo.CardLevel = 1;
            _unlockedCards.Add(cardInfo);
        }
        
        public void ChangeCardInDeckState(int cardId, bool state) {
            var cardInfo = _unlockedCardsMap[cardId];
            cardInfo.InDeck = state;
        }

        public void SaveCardCollection() {
            var cardDatas = new List<CardStorageData>();
            for (var i = 0; i < _unlockedCards.Count; i++) {
                var cardInfo = _unlockedCards[i];
                cardDatas.Add(new() {
                    Id = cardInfo.Id,
                    InDeck = cardInfo.InDeck,
                    Level = cardInfo.CardLevel
                });
            }
            
            _cardCollectionStorage.UpdateUnlockedCards(cardDatas);
            _cardCollectionStorage.Save();
        }

        public bool HasCardInCollection(int cardId) {
            return _unlockedCardsMap.ContainsKey(cardId);
        }

        private void PrepareCards() {
            var cardStorageDatas = _cardCollectionStorage.GetCards();

            UnlockedCards.ObserveAdd().Subscribe(e => CardAdded(e.Value));
            UnlockedCards.ObserveRemove().Subscribe(e => CardRemoved(e.Value));
            
            if (cardStorageDatas.Count == 0) {
                FillStartCardCollection();
                return;
            }
            
            FillSavedCards(cardStorageDatas);
        }

        private void CardRemoved(CardInfo cardInfo) {
            _unlockedCardsMap.Remove(cardInfo.Id);
        }

        private void CardAdded(CardInfo cardInfo) {
            _unlockedCardsMap.TryAdd(cardInfo.Id, cardInfo);
        }

        private void FillSavedCards(List<CardStorageData> cards) {
            foreach (var cardStorageData in cards) {
                var cardInfo = InitCard(cardStorageData.Id);
                cardInfo.CardLevel = cardStorageData.Level;
                cardInfo.InDeck = cardStorageData.InDeck;
                //место для вызова сервиса, который пересчитает значение карточки в зависимости от уровня
                _unlockedCards.Add(cardInfo);
            }
        }

        private void FillStartCardCollection() {
            var starterCardIds = _cardsConfig.GetStartCards();
            
            foreach (var cardId in starterCardIds) {
                var cardInfo = InitCard(cardId);
                cardInfo.InDeck = true;
                cardInfo.CardLevel = 1;
                _unlockedCards.Add(cardInfo);
            }

            SaveCardCollection();
        }

        private CardInfo InitCard(int cardId) {
            var cardData = _cardsConfig.GetCardDataById(cardId);
            var cardInfo = new CardInfo(cardData);
            return cardInfo;
        }

    }
}