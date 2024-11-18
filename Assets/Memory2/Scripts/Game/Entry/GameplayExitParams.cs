using Memory2.Scripts.Core;
using Memory2.Scripts.Global.GameRoot;

namespace Memory2.Scripts.Game.Entry {
    public class GameplayExitParams {
        public SceneEnterParams MainMenuEnterParams { get; }

        public GameplayExitParams(SceneEnterParams mainMenuEnterParams) {
            MainMenuEnterParams = mainMenuEnterParams;
        }
    }
}