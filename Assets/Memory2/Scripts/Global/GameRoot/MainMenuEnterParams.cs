using Memory2.Scripts.Core;
using Memory2.Scripts.Global.Data;

namespace Memory2.Scripts.Global.GameRoot {
    public class MainMenuEnterParams : SceneEnterParams {
        public LevelData LevelData;
        public bool IsLevelSuccess;

        public MainMenuEnterParams(LevelData levelData, bool isLevelSuccess) : base(Scenes.MAIN_MENU) {
            IsLevelSuccess = isLevelSuccess;
            LevelData = levelData;
        }
    }
}