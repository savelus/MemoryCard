using System.Collections.Generic;
using Memory2.Scripts.Game.Core;
using Memory2.Scripts.Game.Core.Root;
using Memory2.Scripts.Game.Global.Configs;
using Memory2.Scripts.Game.Global.GameRoot;
using Memory2.Scripts.Game.Global.Storages;
using Memory2.Scripts.Game.Meta.Configs;
using Memory2.Scripts.Game.Meta.Data;
using Memory2.Scripts.Game.Meta.View;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.Presenters {
    public class LocationPresenter {
        private readonly LocationView _locationView;
        private readonly LocationsConfig _locationsConfig;
        private readonly GameEntryPoint _gameEntryPoint;
        private readonly LevelsConfig _levelsConfig;
        private readonly ProgressStorage _progressStorage;

        private List<LevelButton> _levelButtons = new ();

        public LocationPresenter(LocationView locationView, 
                                 LocationsConfig locationsConfig,
                                 GameEntryPoint gameEntryPoint,
                                 LevelsConfig levelsConfig,
                                 ProgressStorage progressStorage) {
            _locationView = locationView;
            _locationsConfig = locationsConfig;
            _gameEntryPoint = gameEntryPoint;
            _levelsConfig = levelsConfig;
            _progressStorage = progressStorage;
        }
        
        public void Open(int locationDataId) {
            var locationData = _locationsConfig.GetLocationsMap()[locationDataId];
            _locationView.SetLabel(locationData.Name);
            _locationView.SubscribeOnCloseButton(OnCloseButtonClicked);
            
            SpawnButtons(locationData);
            
            _locationView.Open();
        }

        private void SpawnButtons(LocationData locationData) {
            _levelButtons.Clear();
            var currentLevel = _progressStorage.GetCurrentLevel();
            
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

                _locationView.AddLevel(button.transform);
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
            _locationView.Close();
        }
    }
}