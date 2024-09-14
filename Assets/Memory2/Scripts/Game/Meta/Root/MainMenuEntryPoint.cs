using Memory2.Scripts.Game.Core.Root;
using Memory2.Scripts.Game.Global.Configs;
using Memory2.Scripts.Game.Global.GameRoot;
using Memory2.Scripts.Game.Meta.Presenters;
using Memory2.Scripts.Game.Meta.Root.View;
using Memory2.Scripts.Game.Meta.View;
using R3;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Root {
    public class MainMenuEntryPoint : MonoBehaviour {
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;
        private GameEntryPoint _gameEntryPoint;
        private LevelsConfig _levelsConfig;
        private LocationMapPresenter _locationMapPresenter;
        private LocationMapView _locationMapView;
        private LocationView _locationView;

        [Inject]
        public void Construct(GameEntryPoint gameEntryPoint,
                              LevelsConfig levelsConfig,
                              LocationMapPresenter locationMapPresenter,
                              LocationMapView locationMapView,
                              LocationView locationView) {
            _gameEntryPoint = gameEntryPoint;
            _levelsConfig = levelsConfig;
            _locationMapPresenter = locationMapPresenter;
            _locationMapView = locationMapView;
            _locationView = locationView;

        }
        public void Run(UIRootView uiRootView, MainMenuEnterParams enterParams) {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRootView.AttachSceneUI(uiScene.gameObject);
            uiRootView.AddSceneUI(_locationMapView.transform);
            uiRootView.AddSceneUI(_locationView.transform);
            _locationMapView.Close();
            _locationView.Close();

            uiScene.Bind(() => _gameEntryPoint.LoadGameplayScene(CreateGameplayEnterParams()),
                ()=> _locationMapPresenter.Open());

        }

        private GameplayEnterParams CreateGameplayEnterParams() {
            return new GameplayEnterParams(_levelsConfig.GetRandomLevel(), 0, 0);
        }
        
    }
}