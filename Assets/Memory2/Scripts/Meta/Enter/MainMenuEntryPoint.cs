using Memory2.Scripts.Core;
using Memory2.Scripts.Core.Enums;
using Memory2.Scripts.Core.Signals;
using Memory2.Scripts.Global.Configs;
using Memory2.Scripts.Global.GameRoot;
using Memory2.Scripts.Meta.Data;
using Memory2.Scripts.Meta.MVP.Data;
using Memory2.Scripts.Meta.MVP.View;
using Memory2.Scripts.Meta.Storages;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Meta.Enter {
    public class MainMenuEntryPoint : EntryPoint {
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

        public override void Run(UIRootView uiRootView, SceneEnterParams enterParams) {
            var mainMenuEnterParams = (MainMenuEnterParams) enterParams;
            var uiScene = Instantiate(_sceneUIRootPrefab);

            if (mainMenuEnterParams is { IsLevelSuccess: true }) {
                _moneyStorage.Add(mainMenuEnterParams.LevelData.Money);
                _moneyStorage.Save();
            }

            uiRootView.AttachSceneUI(uiScene.gameObject);

            uiScene.Bind(() => _gameEntryPoint.LoadGameplayScene(CreateGameplayEnterParams()),
                () => _signalBus.Fire(new OpenWindowSignal(WindowKey.LocationMap, new LocationMapData())),
                () => _signalBus.Fire(new OpenWindowSignal(WindowKey.CardCollection, new CardCollectionData())),
                () => _signalBus.Fire(new OpenWindowSignal(WindowKey.Shop, new ShopWindowData())));
        }

        private SceneEnterParams CreateGameplayEnterParams() {
            return new GameplayEnterParams(_levelsConfig.GetRandomLevel(), 0, 0);
        }
    }
}