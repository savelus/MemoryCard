using System;
using Memory2.Scripts.Editor.GoogleImporter.Base;
using Memory2.Scripts.Global.Configs.Cards;
using Memory2.Scripts.Global.Configs.Installers;
using Memory2.Scripts.Global.Enums;
using UnityEditor;
using UnityEngine;

namespace Memory2.Scripts.Editor.GoogleImporter.Importers {
    public class CardsConfigImporter : BaseImporter<CardsParser, CardsConfigInstaller> {
        protected override string Key => "CardsConfig";

        [MenuItem("Configs/Cards/Import Cards config")]
        public static async void LoadCardsConfig() {
            var importer = new CardsConfigImporter();
            await importer.LoadSettingsAsync();
        }

        protected override CardsParser CreateParser(CardsConfigInstaller config) => new(config._cardsConfig);
    }
    
    public class CardsParser : IGoogleSheetParser {
        private readonly CardsConfig _cardsConfig;

        private CardData _currentCardData;
        public CardsParser(CardsConfig cardsConfig) {
            _cardsConfig = cardsConfig;
            _cardsConfig.Cards = new();
        }
        
        public void Parse(string header, string value) {
            switch (header) {
                case "Id":
                    _currentCardData = new(){Id = int.Parse(value)};
                    _cardsConfig.Cards.Add(_currentCardData);
                    break;
                case "Name":
                    _currentCardData.CardName = value;
                    break;
                case "Type":
                    _currentCardData.Type = Enum.Parse<Element>(value);
                    break;
                case "Damage":
                    _currentCardData.Damage = int.Parse(value);
                    break;
                case "Color":
                    ColorUtility.TryParseHtmlString(value, out var color);
                    _currentCardData.Color = color;
                    break;
                case "Cost":
                    _currentCardData.Cost = int.Parse(value);
                    break;
            }
        }
    }
}