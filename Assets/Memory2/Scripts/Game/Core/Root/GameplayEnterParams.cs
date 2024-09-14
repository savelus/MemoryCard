using Memory2.Scripts.Game.Global.Data;
using Memory2.Scripts.Game.Global.GameRoot;

namespace Memory2.Scripts.Game.Core.Root {
    public class GameplayEnterParams : SceneEnterParams {
        public LevelData LevelData { get; private set; }
        public int Location { get; private set; }
        public int Level { get; private set; }
        public GameplayEnterParams(LevelData levelData, int location, int level) : base(Scenes.GAMEPLAY) {
            LevelData = levelData;
            Location = location;
            Level = level;
        }
    }
}