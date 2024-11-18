using System;
using System.Linq;
using Memory2.Scripts.Editor.GoogleImporter.Base;
using Memory2.Scripts.Game.Configs;
using Memory2.Scripts.Game.Configs.Installers;
using Memory2.Scripts.Game.Data;
using Memory2.Scripts.Global.Configs;
using Memory2.Scripts.Global.Configs.Cards;
using Memory2.Scripts.Global.Configs.Installers;
using Memory2.Scripts.Global.Data;
using Memory2.Scripts.Global.Enums;
using Memory2.Scripts.Meta.Configs.Installers;
using UnityEditor;
using UnityEngine;

namespace Memory2.Scripts.Editor.GoogleImporter.Importers {
    public class LocationsImporter : BaseImporter<LocationsParser, LocationsConfigInstaller> {
        protected override string Key => "LocationsConfig";

        [MenuItem("Configs/Campaign/Import locations config")]
        public static async void LoadCardsConfig() {
            var importer = new LocationsImporter();
            await importer.LoadSettingsAsync();
        }

        protected override LocationsParser CreateParser(LocationsConfigInstaller config) => new(config.LocationsConfig);
    }
    
    public class LocationsParser : IGoogleSheetParser {
        private readonly LocationsConfig _locationsConfig;

        private LocationData _currentLocationData;
        public LocationsParser(LocationsConfig locationsConfig) {
            _locationsConfig = locationsConfig;
            _locationsConfig.Locations = new();
        }
        
        public void Parse(string header, string value) {
            switch (header) {
                case "Id":
                    _currentLocationData = new() { Id = int.Parse(value) };
                    _locationsConfig.Locations.Add(_currentLocationData);
                    break;
                case "Name":
                    _currentLocationData.Name = value;
                    break;
                case "ButtonVisualId":
                    _currentLocationData.ButtonVisualId = value;
                    break;
                case "LevelIds":
                    _currentLocationData.LevelIds = value.Split(';').Select(int.Parse).ToList();
                    break;
            }
        }
    }
}