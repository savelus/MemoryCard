using System.Collections.Generic;
using Memory2.Scripts.Game.Core.Configs;
using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Root.View;
using Memory2.Scripts.Game.Core.Services;
using Unity.Collections;
using UnityEngine;
using Random = System.Random;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class InitializeCardState : State {
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly InitializeEnemyState _initializeEnemyState;
        private readonly CardsConfig _cardsConfig;
        private readonly CardInputService _cardInputService;

        public InitializeCardState(Base.StateMachine stateMachine, CardsConfig cardsConfig, CardInputService cardInputService, UIGameplayRoot uiGameplayRoot, InitializeEnemyState initializeEnemyState) : base(stateMachine) {
            _uiGameplayRoot = uiGameplayRoot;
            _initializeEnemyState = initializeEnemyState;
            _cardsConfig = cardsConfig;
            _cardInputService = cardInputService;
        }

        public override void Enter() {
            var cardPrefab = _cardsConfig.CardPrefab;
            var shuffledCurds = ShuffleCards(_cardsConfig.CardCount, _cardsConfig.Cards);
            for (var i = 0; i < shuffledCurds.Length; i++) {
                var card = Object.Instantiate(cardPrefab);
                _uiGameplayRoot.AddCard(card.transform);
                shuffledCurds[i].Initialize(card, _cardsConfig.CardBackSideColor);
            }
            
            _cardInputService.SubscribeAllCards(shuffledCurds);
            
            _stateMachine.ChangeState(_initializeEnemyState);
        }

        private CardPresenter[] ShuffleCards(int cardsCount, List<CardData> cardPrefabs) {
            var preparedCards = new CardPresenter[cardsCount];
            var cardsNumbers = GetCardsNumbers(cardsCount);
            for (var i = 0; i < cardsCount; i++) {
                preparedCards[i] = new CardPresenter(cardPrefabs[cardsNumbers[i]]);
            }

            return preparedCards;
        }

        private int[] GetCardsNumbers(int size) {
            var orderedList = new List<int>(size);
            for (var i = 0; i < size / 2; i++) {
                orderedList.Add(i);
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