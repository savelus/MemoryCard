using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Global;
using Memory2.Scripts.Global.Configs;
using Memory2.Scripts.Global.Data;
using Memory2.Scripts.Global.GameRoot;
using Memory2.Scripts.Global.MVP.Context;
using Memory2.Scripts.Global.MVP.Views;
using Memory2.Scripts.Global.Storages;
using Memory2.Scripts.Meta.Configs;
using Memory2.Scripts.Meta.MVP.Data;
using Memory2.Scripts.Meta.MVP.Interfaces;
using Memory2.Scripts.Meta.MVP.View;
using Memory2.Scripts.Meta.Storages;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Meta.MVP.Presenters.LocationMap {
    public class LocationPresenter : BaseWindowPresenter<ILocationView, LocationWindowData> {
        private LocationsConfig _locationsConfig;
        private GameEntryPoint _gameEntryPoint;
        private LevelsConfig _levelsConfig;
        private ProgressStorage _progressStorage;

        private List<LevelButton> _levelButtons = new();

        [Inject]
        public void Inject(LocationsConfig locationsConfig,
            GameEntryPoint gameEntryPoint,
            LevelsConfig levelsConfig,
            ProgressStorage progressStorage) {
            _locationsConfig = locationsConfig;
            _gameEntryPoint = gameEntryPoint;
            _levelsConfig = levelsConfig;
            _progressStorage = progressStorage;
        }

        protected override async UniTask LoadContent() {
            var locationData = _locationsConfig.GetLocationsMap()[WindowData.LocationDataId];
            View.SetLabel(locationData.Name);
            View.OnClickCloseButton += OnCloseButtonClicked;

            SpawnButtons(locationData);
        }

        private void SpawnButtons(LocationData locationData) {
            _levelButtons.Clear();
            var currentLocation = _progressStorage.CurrentLocation;
            var currentLevel = _progressStorage.CurrentLevel;
            if (currentLocation > locationData.Id) {
                currentLevel = locationData.LevelIds.Count + 1;
            }

            var buttonPrefab = _locationsConfig.LevelButtonPrefab;
            for (var i = 0; i < locationData.LevelIds.Count; i++) {
                var button = Object.Instantiate(buttonPrefab);
                var levelId = locationData.LevelIds[i];
                if (currentLevel >= i) {
                    button.Initialize(levelId.ToString(), true, () => OnLevelClicked(levelId, locationData.Id));
                }
                else {
                    button.Initialize(levelId.ToString(), false);
                }

                View.AddLevel(button.transform);
                _levelButtons.Add(button);
            }
        }

        private void OnLevelClicked(int levelId, int locationDataId) {
            _gameEntryPoint.LoadGameplayScene(new GameplayEnterParams(_levelsConfig.GetLevelById(levelId), locationDataId, levelId));
        }

        private void OnCloseButtonClicked() {
            foreach (var levelButton in _levelButtons) {
                Object.Destroy(levelButton.gameObject);
            }

            _levelButtons.Clear();
        }

        public LocationPresenter(ContextService service) : base(service) { }
    }
}