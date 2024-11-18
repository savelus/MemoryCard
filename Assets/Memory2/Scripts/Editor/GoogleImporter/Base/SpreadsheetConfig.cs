using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Memory2.Scripts.Editor.GoogleImporter.Base {
    [CreateAssetMenu(fileName = "SpreadsheetConfig", menuName = "Configs/Spreadsheet Config")]
    public class SpreadsheetConfig : ScriptableObject {
        public List<SheetConfig> Sheets = new();

        public SheetConfig GetConfig(string key) {
            if (key == "SpreadSheetConfig")
            {    return new() {
                    Key = "SpreadSheetConfig",
                    SpreadsheetId = "17zSSVc3toeQs5hfE971mbKdbSecftNUsQ_dze_IQimo",
                    SheetName = "Links"
                };}

            return Sheets.FirstOrDefault(sheet => sheet.Key == key);
        }
    }
}