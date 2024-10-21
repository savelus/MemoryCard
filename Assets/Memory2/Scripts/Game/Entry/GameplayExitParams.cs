using Memory2.Scripts.Meta.Enter;

namespace Memory2.Scripts.Game.Entry {
    public class GameplayExitParams {
        public MainMenuEnterParams MainMenuEnterParams { get; }

        public GameplayExitParams(MainMenuEnterParams mainMenuEnterParams) {
            MainMenuEnterParams = mainMenuEnterParams;
        }
    }
}