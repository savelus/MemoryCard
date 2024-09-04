using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Meta.Data;
using Memory2.Scripts.Game.Meta.View;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Configs {
    [Serializable]
    public class LocationsConfig {
        [SerializeField] private List<LocationData> Locations;
        public LocationButton LocationsButtonPrefab;
        public LevelButton LevelButtonPrefab;


        private Dictionary<int, LocationData> _locationsMap;

        public Dictionary<int, LocationData> GetLocationsMap() {
            if (_locationsMap == null) {
                InitLocationsMap();
            }
            return _locationsMap;
        }

        private void InitLocationsMap() {
            _locationsMap = new Dictionary<int, LocationData>();
            foreach (var locationData in Locations) {
                _locationsMap[locationData.Id] = locationData;
            }
        }
    }
}