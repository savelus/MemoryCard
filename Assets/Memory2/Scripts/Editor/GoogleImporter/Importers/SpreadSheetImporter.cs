using Memory2.Scripts.Editor.GoogleImporter.Base;
using UnityEditor;

namespace Memory2.Scripts.Editor.GoogleImporter.Importers {
    public class SpreadSheetImporter: BaseImporter<SpreadSheetParser, SpreadsheetConfig> {
        protected override string Key => "SpreadSheetConfig";
        
        [MenuItem("Configs/Import Links")]
        public static async void LoadCardsConfig() {
            var importer = new SpreadSheetImporter();
            await importer.LoadSettingsAsync();
        }
        
        protected override SpreadSheetParser CreateParser(SpreadsheetConfig config) => new(config);
    }

    public class SpreadSheetParser : IGoogleSheetParser {
        private readonly SpreadsheetConfig _config;
        private SheetConfig _sheetConfig;
        public SpreadSheetParser(SpreadsheetConfig config) {
            _config = config;
            config.Sheets = new();
        }
        
        public void Parse(string header, string value) {
            switch (header) {
                case "Id":
                    _sheetConfig = new(){Key = value};
                    _config.Sheets.Add(_sheetConfig);
                    break;
                case "ScriptableName":
                    _sheetConfig.ScriptableName = value;
                    break;
                case "SpreadSheetId":
                    _sheetConfig.SpreadsheetId = value;
                    break;
                case "SheetName":
                    _sheetConfig.SheetName = value;
                    break;
            }
        }
    }
}