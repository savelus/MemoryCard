using System.Collections.Generic;
using Memory2.Scripts.Game.MVP.Presenters;
using Memory2.Scripts.Game.MVP.View;
using Memory2.Scripts.Game.Services;
using Memory2.Scripts.Game.StateMachine.Base;
using Memory2.Scripts.Global.Configs.Cards;
using Memory2.Scripts.Global.Configs.Elements;
using Memory2.Scripts.Global.Data;
using Memory2.Scripts.Global.Services;
using ObservableCollections;
using Unity.Collections;
using UnityEngine;
using Random = System.Random;

namespace Memory2.Scripts.Game.StateMachine.States {
    public sealed class InitializeCardState : State {
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly InitializeEnemyState _initializeEnemyState;
        private readonly ElementsIconConfig _elementsIconConfig;
        private readonly CardCollectionService _cardCollectionService;
        private readonly CardsConfig _cardsConfig;
        private readonly CardInputService _cardInputService;
        private CardPresenter[] _cardPresenters;

        public InitializeCardState(Base.StateMachine stateMachine,
            CardsConfig cardsConfig,
            CardInputService cardInputService,
            UIGameplayRoot uiGameplayRoot,
            InitializeEnemyState initializeEnemyState,
            ElementsIconConfig elementsIconConfig,
            CardCollectionService cardCollectionService) : base(stateMachine) {
            _uiGameplayRoot = uiGameplayRoot;
            _initializeEnemyState = initializeEnemyState;
            _elementsIconConfig = elementsIconConfig;
            _cardCollectionService = cardCollectionService;
            _cardsConfig = cardsConfig;
            _cardInputService = cardInputService;
        }

        public override void Enter() {
            _cardPresenters = InitPresenters(_cardsConfig.CardCount, _cardCollectionService.GetCardCollection());
            _cardInputService.CardsEnded += ReFillCards;
            ReFillCards();

            _stateMachine.ChangeState(_initializeEnemyState);
        }

        private CardPresenter[] InitPresenters(int cardsCount, ObservableList<CardInfo> cardsData) {
            var presenters = new CardPresenter[cardsCount];
            var cardPrefab = _cardsConfig.CardPrefab;
            for (int i = 0; i < cardsCount; i++) {
                var card = Object.Instantiate(cardPrefab);
                var cardData = cardsData[i / 2];
                card.gameObject.name = "Card " + i;
                _uiGameplayRoot.AddCard(card.transform);
                var elementSprite = _elementsIconConfig.GetSprite(cardData.Type);
                presenters[i] = new(card, cardData, _cardsConfig.CardBackSideColor, elementSprite);
            }

            return presenters;
        }

        private void ReFillCards() {
            var cardNumbers = GetShuffledCardIndexes(_cardsConfig.CardCount);
            for (var i = 0; i < _cardPresenters.Length; i++) {
                _cardPresenters[i].Initialize(cardNumbers[i]);
            }

            _cardInputService.SubscribeAllCards(_cardPresenters);
        }

        private int[] GetShuffledCardIndexes(int size) {
            var orderedList = new List<int>(size);
            for (var i = 0; i < size; i++) {
                orderedList.Add(i);
            }

            var returnedArray = new int[size];
            var rnd = new Random();
            for (var i = 0; i < size; i++) {
                var index = rnd.Next(0, orderedList.Count);
                returnedArray[i] = orderedList[index];
                orderedList.RemoveAtSwapBack(index);
            }
            
            return returnedArray;
        }
    }
}