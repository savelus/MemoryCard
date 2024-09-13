using Memory2.Scripts.Game.Global.Storages.Root;
using Memory2.Scripts.Game.Meta.Configs;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Global.Storages {
    public class ProgressStorage : ISave, 
                                   IInitializable {
        private const string Key = "Progress";
        
        private readonly LocationsConfig _locationsConfig;

        private Vector2 _currentLocationWithLevel;

        public ProgressStorage(LocationsConfig locationsConfig) {
            _locationsConfig = locationsConfig;
        }
        
        void IInitializable.Initialize() {
            if (PlayerPrefs.HasKey(Key))
                _currentLocationWithLevel = JsonUtility.FromJson<Vector2>(PlayerPrefs.GetString(Key));
            else
                _currentLocationWithLevel = Vector2Int.zero;
        }

        public string GetKey() => Key;

        public Vector2 GetCurrentLocationWithLevel() {
            return _currentLocationWithLevel;
        }

        public int GetCurrentLocation() => (int)_currentLocationWithLevel.x;
        public int GetCurrentLevel() => (int)_currentLocationWithLevel.y;

        public void CompleteLevel() {
            var levelsCount = _locationsConfig.GetLevelsCountOnLocation((int)_currentLocationWithLevel.x);
            if (_currentLocationWithLevel.y + 1 >= levelsCount) {
                _currentLocationWithLevel.x++;
                _currentLocationWithLevel.y = 0;
            }
            else {
                _currentLocationWithLevel.y++;
            }
        }

        public void Save() {
            var json = JsonUtility.ToJson(_currentLocationWithLevel);
            PlayerPrefs.SetString(Key, json);
        }
    }
}