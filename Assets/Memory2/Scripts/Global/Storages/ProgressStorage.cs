﻿using Memory2.Scripts.Core.Storages;
using Memory2.Scripts.Global.Configs;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Global.Storages {
    public class ProgressStorage : ISave,
        IInitializable {
        private const string Key = "Progress";

        private readonly LocationsConfig _locationsConfig;

        private int _currentLocation;
        private int _currentLevel;

        public int CurrentLocation => _currentLocation;
        public int CurrentLevel => _currentLevel;

        public ProgressStorage(LocationsConfig locationsConfig) {
            _locationsConfig = locationsConfig;
        }

        void IInitializable.Initialize() {
            _currentLocation = PlayerPrefs.HasKey(Key + nameof(_currentLocation))
                ? PlayerPrefs.GetInt(Key + nameof(_currentLocation))
                : 0;

            _currentLevel = PlayerPrefs.HasKey(Key + nameof(_currentLevel))
                ? PlayerPrefs.GetInt(Key + nameof(_currentLevel))
                : 0;
        }

        public string GetKey() => Key;


        public void CompleteLevel(int passedLocation, int passedLevel) {
            if (passedLocation != _currentLocation || passedLevel != _currentLevel) return;

            var levelsCount = _locationsConfig.GetLevelsCountOnLocation(_currentLocation);
            if (_currentLevel + 1 >= levelsCount) {
                _currentLocation++;
                _currentLevel = 0;
            }
            else {
                _currentLevel++;
            }
        }

        public void Save() {
            PlayerPrefs.SetInt(Key + nameof(_currentLocation), _currentLocation);
            PlayerPrefs.SetInt(Key + nameof(_currentLevel), _currentLevel);
        }
    }
}