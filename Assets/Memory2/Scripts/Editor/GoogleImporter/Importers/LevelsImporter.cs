using System;
using Memory2.Scripts.Editor.GoogleImporter.Base;
using Memory2.Scripts.Game.Configs;
using Memory2.Scripts.Game.Configs.Installers;
using Memory2.Scripts.Game.Data;
using Memory2.Scripts.Global.Configs;
using Memory2.Scripts.Global.Configs.Cards;
using Memory2.Scripts.Global.Configs.Installers;
using Memory2.Scripts.Global.Data;
using Memory2.Scripts.Global.Enums;
using UnityEditor;
using UnityEngine;

namespace Memory2.Scripts.Editor.GoogleImporter.Importers {
    public class LevelsImporter : BaseImporter<LevelsParser, LevelsConfigInstaller> {
        protected override string Key => "LevelsConfig";

        [MenuItem("Configs/Campaign/Import levels config")]
        public static async void LoadCardsConfig() {
            var importer = new LevelsImporter();
            await importer.LoadSettingsAsync();
        }

        protected override LevelsParser CreateParser(LevelsConfigInstaller config) => new(config.LevelsConfig);
    }
    
    public class LevelsParser : IGoogleSheetParser {
        private readonly LevelsConfig _levelsConfig;

        private LevelData _currentLevelData;
        public LevelsParser(LevelsConfig levelsConfig) {
            _levelsConfig = levelsConfig;
            _levelsConfig.Levels = new();
        }
        
        public void Parse(string header, string value) {
            switch (header) {
                case "Id":
                    _currentLevelData = new() { LevelId = int.Parse(value) };
                    _levelsConfig.Levels.Add(_currentLevelData);
                    break;
                case "Seconds":
                    _currentLevelData.Seconds = int.Parse(value);
                    break;
                case "EnemyId":
                    _currentLevelData.EnemyId = value;
                    break;
                case "Money":
                    _currentLevelData.Money = int.Parse(value);
                    break;
            }
        }
    }
}