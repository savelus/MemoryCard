using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Game.Global.Configs.Cards;
using Memory2.Scripts.Game.Global.MVP.Base;
using Memory2.Scripts.Game.Global.MVP.Context;
using Memory2.Scripts.Game.Global.Services;
using Memory2.Scripts.Game.Global.Storages;
using Memory2.Scripts.Game.Meta.Configs;
using Memory2.Scripts.Game.Meta.Storages;
using Memory2.Scripts.Game.Meta.View.Shop;
using Memory2.Scripts.Utils.GameObjectPool;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Presenters.Shop {
    public sealed class ShopPresenter : BaseWindowPresenter<IShopWindow, ShopWindowData> {
        private CardsConfig _cardsConfig;
        private CardCollectionService _cardCollectionService;
        private ShopConfig _shopConfig;
        private ProgressStorage _progressStorage;
        private MoneyStorage _moneyStorage;

        private GameObjectPool<ShopElement> _shopElementsPool;

        private Dictionary<int, ShopElement> _activeElements;
        
        [Inject]
        public void Inject(CardsConfig cardsConfig, 
                             CardCollectionService cardCollectionService, 
                             ShopConfig shopConfig,
                             ProgressStorage progressStorage,
                             MoneyStorage moneyStorage) {
            _cardsConfig = cardsConfig;
            _cardCollectionService = cardCollectionService;
            _shopConfig = shopConfig;
            _progressStorage = progressStorage;
            _moneyStorage = moneyStorage;
        }

        protected override async UniTask LoadContent() {
            var parent = View.GetElementParent();
            _shopElementsPool = new(_shopConfig.ShopElementPrefab, 5, parent);
            _activeElements = new();

            View.OnClickCloseButton += OnClose;
            
            var currentLocation = _progressStorage.CurrentLocation;
            var currentLevel = _progressStorage.CurrentLevel;
            
            var allUnlockedCards = _shopConfig.GetUnlockedCardsId(currentLocation, currentLevel);

            var cardIndex = 0;
            foreach (var cardId in allUnlockedCards) {
                if (_cardCollectionService.HasCardInCollection(cardId)) continue;
                var cardData = _cardsConfig.GetCardDataById(cardId);
                var element = _shopElementsPool.Get();
                
                element.Init(true, cardData.Cost.ToString("F1"), cardData.CardName, cardData.Sprite, ()=> BuyCard(cardId));
                element.transform.SetSiblingIndex(cardIndex);
                element.gameObject.SetActive(true);
                
                _activeElements.Add(cardId, element);
                
                cardIndex++;
            }

            View.ShopIsClose(cardIndex == 0);
            
            _moneyStorage.ValueChanged += UpdateMoney;
            UpdateMoney(_moneyStorage.Get());
        }

        private void BuyCard(int cardId) {
            var cardCost = _cardsConfig.GetCardDataById(cardId).Cost;
            if(!_moneyStorage.Subtract(cardCost)) return;
            
            _cardCollectionService.BuyCard(cardId);
            
            var cardElement = _activeElements[cardId];
            _shopElementsPool.Release(cardElement);
            _activeElements.Remove(cardId);
        }

        private void OnClose() {
            foreach (var activeElement in _activeElements.Values) {
                _shopElementsPool.Release(activeElement);
            }
            _activeElements.Clear();
            _moneyStorage.ValueChanged -= UpdateMoney;
        }

        private void UpdateMoney(float money) {
            View.UpdateMoney($"{money:F1} монет");
        }

        public ShopPresenter(ContextService service) : base(service) { }
    }
}