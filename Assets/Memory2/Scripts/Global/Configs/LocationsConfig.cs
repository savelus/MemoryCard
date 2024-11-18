using System;
using System.Collections.Generic;
using Memory2.Scripts.Core.Utils;
using Memory2.Scripts.Global.Data;
using Memory2.Scripts.Global.MVP.Views;
using UnityEngine;

namespace Memory2.Scripts.Global.Configs {
    [Serializable]
    public class LocationsConfig {
        public List<LocationData> Locations;
        [SerializeField] private List<SpriteWithId> LocationButtonVisuals;
        public LocationButton LocationsButtonPrefab;
        public LevelButton LevelButtonPrefab;
        [SerializeField] private Sprite ClosedButtonSprite;

        private Dictionary<int, LocationData> _locationsMap;
        private Dictionary<string, SpriteWithId> _locationButtonVisualsMap;

        public Dictionary<int, LocationData> GetLocationsMap() {
            if (_locationsMap == null) {
                InitLocationsMap();
            }

            return _locationsMap;
        }

        public Sprite GetLocationButtonVisual(string buttonId) {
            if (_locationButtonVisualsMap == null) {
                InitLocationVisualsMap();
            }

            _locationButtonVisualsMap!.TryGetValue(buttonId, out var spriteWithId);
            return spriteWithId?.Sprite;
        }
        
        public int GetLevelsCountOnLocation(int location) {
            if (_locationsMap == null) {
                InitLocationsMap();
            }

            return _locationsMap[location].LevelIds.Count;
        }
        
        private void InitLocationsMap() {
            _locationsMap = new();
            foreach (var locationData in Locations) {
                _locationsMap[locationData.Id] = locationData;
            }
        }

        private void InitLocationVisualsMap() {
            _locationButtonVisualsMap = new();
            foreach (var locationData in LocationButtonVisuals) {
                _locationButtonVisualsMap[locationData.Id] = locationData;
            }
        }

        public Sprite GetClosedButtonSprite() => ClosedButtonSprite;
    }
}