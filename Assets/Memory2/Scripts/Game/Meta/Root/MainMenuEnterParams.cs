using Memory2.Scripts.Game.Global.Data;

namespace Memory2.Scripts.Game.Meta.Root {
    public class MainMenuEnterParams {
        public LevelData LevelData;
        public bool IsLevelSuccess;

        public MainMenuEnterParams(LevelData levelData, bool isLevelSuccess) {
            IsLevelSuccess = isLevelSuccess;
            LevelData = levelData;
        }
    }
}