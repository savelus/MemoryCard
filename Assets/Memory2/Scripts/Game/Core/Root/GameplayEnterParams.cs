using Memory2.Scripts.Game.Global.Data;
using Memory2.Scripts.Game.Global.GameRoot;

namespace Memory2.Scripts.Game.Core.Root {
    public class GameplayEnterParams : SceneEnterParams {
        public LevelData LevelData { get; private set; }
        public GameplayEnterParams(LevelData levelData) : base(Scenes.GAMEPLAY) {
            LevelData = levelData;
        }
    }
}