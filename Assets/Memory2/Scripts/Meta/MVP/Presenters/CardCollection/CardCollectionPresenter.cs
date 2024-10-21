using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Global.Configs.Cards;
using Memory2.Scripts.Global.MVP.Context;
using Memory2.Scripts.Global.Services;
using Memory2.Scripts.Meta.Configs;
using Memory2.Scripts.Meta.MVP.Data;
using Memory2.Scripts.Meta.MVP.Interfaces;
using Memory2.Scripts.Meta.MVP.View.CardCollection;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Meta.MVP.Presenters.CardCollection {
    public sealed class CardCollectionPresenter : BaseWindowPresenter<ICardCollectionWindow, CardCollectionData> {
        private CardCollectionService _cardCollectionService;
        private CardCollectionConfig _cardCollectionConfig;
        private CardsConfig _cardsConfig;

        private readonly Dictionary<int, CardCollectionElement> _cardCollectionElements = new();

        private int _selectedCardCount;

        public CardCollectionPresenter(ContextService service) : base(service) { }

        [Inject]
        public void Inject(CardCollectionService cardCollectionService,
            CardCollectionConfig cardCollectionConfig,
            CardsConfig cardsConfig) {
            _cardCollectionService = cardCollectionService;
            _cardCollectionConfig = cardCollectionConfig;
            _cardsConfig = cardsConfig;
        }

        protected override async UniTask LoadContent() {
            View.Init(_cardsConfig.CardCount / 2);
            View.OnClickCloseButton += OnClosed;
            InitCards();
        }

        public void InitCards() {
            var unlockedCards = _cardCollectionService.UnlockedCards;
            _selectedCardCount = 0;
            foreach (var unlockedCard in unlockedCards) {
                var cardCollectionElement = GetCollectionElement();
                if (unlockedCard.InDeck) _selectedCardCount++;
                _cardCollectionElements[unlockedCard.Id] = cardCollectionElement;
                View.AddCollectionElement(cardCollectionElement.transform);
                cardCollectionElement.Init(unlockedCard.InDeck,
                    unlockedCard.CardName,
                    unlockedCard.CardLevel.ToString(),
                    unlockedCard.Sprite,
                    unlockedCard.Color,
                    state => OnToggleClicked(unlockedCard.Id, state));
                cardCollectionElement.gameObject.SetActive(true);
            }

            SelectedCardCountChanged(_selectedCardCount);
        }

        private void SelectedCardCountChanged(int value) {
            View.SetSelectedCard(value);
        }

        private void OnToggleClicked(int cardId, bool state) {
            _cardCollectionService.ChangeCardInDeckState(cardId, state);

            if (state) _selectedCardCount++;
            else _selectedCardCount--;

            SelectedCardCountChanged(_selectedCardCount);
        }

        private CardCollectionElement GetCollectionElement() {
            var prefab = _cardCollectionConfig.CardCollectionElementPrefab;

            var element = Object.Instantiate(prefab);
            element.gameObject.SetActive(false);

            return element;
        }

        private void OnClosed() {
            _cardCollectionService.SaveCardCollection();
            foreach (var cardCollectionElement in _cardCollectionElements.Values) {
                Object.Destroy(cardCollectionElement.gameObject);
            }
        }
    }
}