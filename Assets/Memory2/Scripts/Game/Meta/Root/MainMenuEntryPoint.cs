using Memory2.Scripts.Game.Core.Root;
using Memory2.Scripts.Game.Global.Configs;
using Memory2.Scripts.Game.Global.GameRoot;
using Memory2.Scripts.Game.Global.MVP.Enums;
using Memory2.Scripts.Game.Global.MVP.Signals;
using Memory2.Scripts.Game.Meta.Presenters;
using Memory2.Scripts.Game.Meta.Presenters.CardCollection;
using Memory2.Scripts.Game.Meta.Presenters.LocationMap;
using Memory2.Scripts.Game.Meta.Presenters.Shop;
using Memory2.Scripts.Game.Meta.Root.View;
using Memory2.Scripts.Game.Meta.Storages;
using Memory2.Scripts.Game.Meta.View;
using Memory2.Scripts.Game.Meta.View.CardCollection;
using Memory2.Scripts.Game.Meta.View.Shop;
using R3;
using Unity.VisualScripting;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Root {
    public class MainMenuEntryPoint : MonoBehaviour {
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;
        private GameEntryPoint _gameEntryPoint;
        private LevelsConfig _levelsConfig;
        private MoneyStorage _moneyStorage;
        private SignalBus _signalBus;

        [Inject]
        public void Construct(GameEntryPoint gameEntryPoint,
                              LevelsConfig levelsConfig,
                              MoneyStorage moneyStorage,
                              SignalBus signalBus) {
            _gameEntryPoint = gameEntryPoint;
            _levelsConfig = levelsConfig;
            _moneyStorage = moneyStorage;
            _signalBus = signalBus;
        }
        
        public void Run(UIRootView uiRootView, MainMenuEnterParams enterParams) {
            var uiScene = Instantiate(_sceneUIRootPrefab);

            if (enterParams is { IsLevelSuccess: true }) {
                _moneyStorage.Add(enterParams.LevelData.Money);
                _moneyStorage.Save();
            }
            
            uiRootView.AttachSceneUI(uiScene.gameObject);
            
            uiScene.Bind(() => _gameEntryPoint.LoadGameplayScene(CreateGameplayEnterParams()),
                ()=>_signalBus.Fire(new OpenWindowSignal(WindowKey.LocationMap, new LocationMapData())),
                ()=>_signalBus.Fire(new OpenWindowSignal(WindowKey.CardCollection, new CardCollectionData())),
                ()=>_signalBus.Fire(new OpenWindowSignal(WindowKey.Shop, new ShopWindowData())));
        }

        private GameplayEnterParams CreateGameplayEnterParams() {
            return new(_levelsConfig.GetRandomLevel(), 0, 0);
        }
        
    }
}