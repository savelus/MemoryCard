using Memory2.Scripts.Game.GameRoot;

namespace Memory2.Scripts.Game.Core.Root {
    public class GameplayEnterParams : SceneEnterParams {
        
        public string SaveFileName { get; }
        public int LevelNumber { get; }
        
        public GameplayEnterParams(string saveFileName, int levelNumber) : base(Scenes.GAMEPLAY) {
            SaveFileName = saveFileName;
            LevelNumber = levelNumber;
        }
    }
}