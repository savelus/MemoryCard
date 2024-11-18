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
using Memory2.Scripts.Meta.Configs;
using Memory2.Scripts.Meta.Configs.Installers;
using Memory2.Scripts.Meta.Data;
using UnityEditor;
using UnityEngine;

namespace Memory2.Scripts.Editor.GoogleImporter.Importers {
    public class ShopImporter : BaseImporter<ShopParser, ShopConfigInstaller> {
        protected override string Key => "ShopConfig";

        [MenuItem("Configs/Shop/Import shop config")]
        public static async void LoadCardsConfig() {
            var importer = new ShopImporter();
            await importer.LoadSettingsAsync();
        }

        protected override ShopParser CreateParser(ShopConfigInstaller config) => new(config.ShopConfig);
    }
    
    public class ShopParser : IGoogleSheetParser {
        private readonly ShopConfig _shopConfig;

        private UnlockCardInLevel _currentShopItem;
        public ShopParser(ShopConfig shopConfig) {
            _shopConfig = shopConfig;
            _shopConfig.Unlocks = new();
        }
        
        public void Parse(string header, string value) {
            switch (header) {
                case "Location":
                    _currentShopItem = new() { Location = int.Parse(value) };
                    _shopConfig.Unlocks.Add(_currentShopItem);
                    break;
                case "Level":
                    _currentShopItem.Level = int.Parse(value);
                    break;
                case "CardIds":
                    _currentShopItem.CardIds = value.Split(';').Select(int.Parse).ToList();
                    break;
            }
        }
    }
}