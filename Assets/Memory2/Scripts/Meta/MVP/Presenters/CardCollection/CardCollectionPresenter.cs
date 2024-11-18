using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.Enums;
using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Core.Signals;
using Memory2.Scripts.Core.Utils.GameObjectPool;
using Memory2.Scripts.Global.Configs.Cards;
using Memory2.Scripts.Global.MVP.Context;
using Memory2.Scripts.Global.MVP.Data;
using Memory2.Scripts.Global.Services;
using Memory2.Scripts.Meta.Configs;
using Memory2.Scripts.Meta.MVP.Data;
using Memory2.Scripts.Meta.MVP.Interfaces;
using Memory2.Scripts.Meta.MVP.View.CardCollection;
using R3;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Meta.MVP.Presenters.CardCollection {
    public sealed class CardCollectionPresenter : BaseWindowPresenter<ICardCollectionWindow, CardCollectionData> {
        private CardCollectionService _cardCollectionService;
        private CardCollectionConfig _cardCollectionConfig;
        private CardsConfig _cardsConfig;
        private SignalBus _signalBus;

        private readonly Dictionary<int, CardCollectionElement> _cardCollectionElements = new();

        private GameObjectPool<CardCollectionElement> _cardCollectionPool;
        private ReactiveProperty<int> _selectedCardCount;

        public CardCollectionPresenter(ContextService service) : base(service) { }

        [Inject]
        public void Inject(CardCollectionService cardCollectionService,
                           CardCollectionConfig cardCollectionConfig,
                           CardsConfig cardsConfig,
                           SignalBus signalBus) {
            _signalBus = signalBus;
            _cardCollectionService = cardCollectionService;
            _cardCollectionConfig = cardCollectionConfig;
            _cardsConfig = cardsConfig;
        }

        public override async UniTask InitializeOnce() {
            _cardCollectionPool = new (_cardCollectionConfig.CardCollectionElementPrefab, 10);
            _selectedCardCount = new();
            _selectedCardCount.Subscribe(SelectedCardCountChanged);
        }

        protected override async UniTask LoadContent() {
            View.Init(_cardsConfig.CardCount / 2);
            InitCards();
        }

        public void InitCards() {
            var unlockedCards = _cardCollectionService.UnlockedCards;
            _selectedCardCount.Value = 0;
            foreach (var unlockedCard in unlockedCards) {
                var cardCollectionElement = GetCollectionElement();
                if (unlockedCard.InDeck) _selectedCardCount.Value++;
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
        }

        private void SelectedCardCountChanged(int value) {
            View.SetSelectedCard(value);
        }

        private void OnToggleClicked(int cardId, bool state) {
            if (state) {
                if (_selectedCardCount.Value == _cardsConfig.CardCount / 2) {
                    View.ShowWarningFullCard();
                    _signalBus.Fire(new OpenWindowSignal(WindowKey.SimpleHint, new HintData(){HintText = "Слишком много карт"}));
                }
                else {
                    _selectedCardCount.Value++;  
                    _cardCollectionElements[cardId].SetToggleState(true);
                    _cardCollectionService.ChangeCardInDeckState(cardId, true);
                }
            }
            else {
                _selectedCardCount.Value--;
                _cardCollectionElements[cardId].SetToggleState(false);
                _cardCollectionService.ChangeCardInDeckState(cardId, false);
            }
        }

        private CardCollectionElement GetCollectionElement() {
            var element = _cardCollectionPool.Get();
            element.gameObject.SetActive(false);

            return element;
        }

        public override async UniTask Dispose() {
            _cardCollectionService.SaveCardCollection();
            foreach (var cardCollectionElement in _cardCollectionElements.Values) {
                _cardCollectionPool.Release(cardCollectionElement);
            }
            
            _cardCollectionElements.Clear();
        }
    }
}