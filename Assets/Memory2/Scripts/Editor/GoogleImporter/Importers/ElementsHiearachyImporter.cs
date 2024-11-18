using System;
using Memory2.Scripts.Editor.GoogleImporter.Base;
using Memory2.Scripts.Global.Configs.Cards;
using Memory2.Scripts.Global.Configs.Elements;
using Memory2.Scripts.Global.Configs.Installers;
using Memory2.Scripts.Global.Enums;
using UnityEditor;
using UnityEngine;

namespace Memory2.Scripts.Editor.GoogleImporter.Importers {
    public class ElementsHierarchyImporter : BaseImporter<ElementsHierarchyParser, ElementsConfigInstaller> {
        protected override string Key => "ElementsConfig";

        [MenuItem("Configs/Elements/Import elements hierarchy")]
        public static async void LoadCardsConfig() {
            var importer = new ElementsHierarchyImporter();
            await importer.LoadSettingsAsync();
        }
        
        protected override ElementsHierarchyParser CreateParser(ElementsConfigInstaller config) => new(config.ElementsHierarchyConfig);
    }
    
    public class ElementsHierarchyParser : IGoogleSheetParser {
        private readonly ElementsHierarchyConfig _elementsHierarchyConfig;

        private ElementsDependencies _elementsDependencies;
        public ElementsHierarchyParser(ElementsHierarchyConfig elementsHierarchyConfig) {
            _elementsHierarchyConfig = elementsHierarchyConfig;
            _elementsHierarchyConfig.Dependencies = new();
        }
        
        public void Parse(string header, string value) {
            switch (header) {
                case "Element":
                    _elementsDependencies = new(){Element = Enum.Parse<Element>(value)};
                    _elementsHierarchyConfig.Dependencies.Add(_elementsDependencies);
                    break;
                case "Dependencies":
                    var dependencies = value.Split(';');
                    _elementsDependencies.Dependencies = new Element[dependencies.Length];
                    for (var i = 0; i < dependencies.Length; i++) {
                        _elementsDependencies.Dependencies[i] = Enum.Parse<Element>(dependencies[i]);
                    }
                    break;
                
            }
        }
    }
}