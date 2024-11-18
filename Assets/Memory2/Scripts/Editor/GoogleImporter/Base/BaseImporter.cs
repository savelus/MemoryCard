using Cysharp.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Memory2.Scripts.Editor.GoogleImporter.Base {
    public abstract class BaseImporter<TParser, TConfig> where TParser : IGoogleSheetParser
                                                       where TConfig : ScriptableObject {
        private static readonly SpreadsheetConfig _spreadsheetConfig = FindScriptableObject<SpreadsheetConfig>("SpreadsheetConfig");
        protected abstract string Key { get; }
        private const string CREDENTIALS_PATH = "unity-configs-d61a87e72e67.json";
        protected TConfig ConfigInstaller;

        protected async UniTask LoadSettingsAsync() {
            var sheetConfig = _spreadsheetConfig.GetConfig(Key);
            
            if (sheetConfig == null) {
                Debug.LogWarning($"Sheet with key {Key} not found in SpreadsheetConfig.");
                return;
            }
            
            ConfigInstaller = FindScriptableObject<TConfig>(sheetConfig.ScriptableName);
            var sheetsImporter = new GoogleSheetsImporter(CREDENTIALS_PATH, sheetConfig.SpreadsheetId);
            var parser = CreateParser(ConfigInstaller);
            await sheetsImporter.DownloadAndParseSheet(sheetConfig.SheetName, parser);
        }
        protected abstract TParser CreateParser(TConfig config);
        
        protected static T FindScriptableObject<T>(string assetName) where T : ScriptableObject {
            var guids = AssetDatabase.FindAssets($"{assetName} t:{typeof(T).Name}");

            foreach (var guid in guids) {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                var asset = AssetDatabase.LoadAssetAtPath<T>(path);

                if (asset != null) {
                    return asset;
                }
            }

            Debug.LogWarning($"ScriptableObject {assetName} типа {typeof(T).Name} не найден.");
            return null;
        }
        
    }
}