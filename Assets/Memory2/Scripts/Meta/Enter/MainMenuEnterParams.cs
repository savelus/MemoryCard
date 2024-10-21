using Memory2.Scripts.Global.Data;

namespace Memory2.Scripts.Meta.Enter {
    public class MainMenuEnterParams {
        public LevelData LevelData;
        public bool IsLevelSuccess;

        public MainMenuEnterParams(LevelData levelData, bool isLevelSuccess) {
            IsLevelSuccess = isLevelSuccess;
            LevelData = levelData;
        }
    }
}