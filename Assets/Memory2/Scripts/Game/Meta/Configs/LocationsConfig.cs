using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Meta.Data;
using Memory2.Scripts.Game.Meta.View;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.Configs {
    [Serializable]
    public class LocationsConfig {
        [SerializeField] private List<LocationData> Locations;
        public LocationButton LocationsButtonPrefab;
        public LevelButton LevelButtonPrefab;
        [SerializeField] private Sprite ClosedButtonSprite;

        private Dictionary<int, LocationData> _locationsMap;

        public Dictionary<int, LocationData> GetLocationsMap() {
            if (_locationsMap == null) {
                InitLocationsMap();
            }

            return _locationsMap;
        }

        public int GetLevelsCountOnLocation(int location) {
            if (_locationsMap == null) {
                InitLocationsMap();
            }
            
            return _locationsMap[location].LevelIds.Count;
        }
        
        private void InitLocationsMap() {
            _locationsMap = new Dictionary<int, LocationData>();
            foreach (var locationData in Locations) {
                _locationsMap[locationData.Id] = locationData;
            }
        }

        public Sprite GetClosedButtonSprite() => ClosedButtonSprite;
    }
}