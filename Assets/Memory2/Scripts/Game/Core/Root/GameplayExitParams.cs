using Memory2.Scripts.Game.Meta.Root;

namespace Memory2.Scripts.Game.Core.Root {
    public class GameplayExitParams {
        public MainMenuEnterParams MainMenuEnterParams { get; }

        public GameplayExitParams(MainMenuEnterParams mainMenuEnterParams) {
            MainMenuEnterParams = mainMenuEnterParams;
        }
    }
}