using System;
using Memory2.Scripts.Editor.GoogleImporter.Base;
using Memory2.Scripts.Game.Configs;
using Memory2.Scripts.Game.Configs.Installers;
using Memory2.Scripts.Game.Data;
using Memory2.Scripts.Global.Configs.Cards;
using Memory2.Scripts.Global.Configs.Installers;
using Memory2.Scripts.Global.Enums;
using UnityEditor;
using UnityEngine;

namespace Memory2.Scripts.Editor.GoogleImporter.Importers {
    public class EnemyImporter : BaseImporter<EnemyParser, EnemyConfigInstaller> {
        protected override string Key => "EnemyConfig";

        [MenuItem("Configs/Enemy/Import enemy config")]
        public static async void LoadCardsConfig() {
            var importer = new EnemyImporter();
            await importer.LoadSettingsAsync();
        }

        protected override EnemyParser CreateParser(EnemyConfigInstaller config) => new(config.EnemyConfig);
    }
    
    public class EnemyParser : IGoogleSheetParser {
        private readonly EnemyConfig _enemyConfig;

        private EnemyData _currentEnemyData;
        public EnemyParser(EnemyConfig enemyConfig) {
            _enemyConfig = enemyConfig;
            _enemyConfig.Enemies = new();
        }
        
        public void Parse(string header, string value) {
            switch (header) {
                case "Name":
                    _currentEnemyData = new() { Name = value };
                    _enemyConfig.Enemies.Add(_currentEnemyData);
                    break;
                case "Type":
                    _currentEnemyData.Type = Enum.Parse<Element>(value);
                    break;
                case "Health":
                    _currentEnemyData.Health = int.Parse(value);
                    break;
                case "SpriteId":
                    _currentEnemyData.SpriteId = value;
                    break;
            }
        }
    }
}