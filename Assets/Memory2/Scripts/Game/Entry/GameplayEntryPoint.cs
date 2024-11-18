using Memory2.Scripts.Core;
using Memory2.Scripts.Game.MVP.View;
using Memory2.Scripts.Game.StateMachine.States;
using Memory2.Scripts.Global.GameRoot;
using Zenject;

namespace Memory2.Scripts.Game.Entry {
    public class GameplayEntryPoint : EntryPoint {
        private UIGameplayRoot _uiGameplayRoot;
        private StateMachine.Base.StateMachine _stateMachine;
        private InitializeCardState _initializeCardState;
        private EndGameState _endGameState;
        private GameScope _gameScope;

        [Inject]
        public void Construct(StateMachine.Base.StateMachine stateMachine,
            InitializeCardState initializeCardState,
            EndGameState endGameState,
            UIGameplayRoot uiGameplayRoot,
            GameEntryPoint gameEntryPoint,
            GameScope gameScope) {
            _stateMachine = stateMachine;
            _endGameState = endGameState;
            _initializeCardState = initializeCardState;
            _uiGameplayRoot = uiGameplayRoot;
            _gameScope = gameScope;
        }

        public override void Run(UIRootView uiRootView, SceneEnterParams enterParams) {
            var gameplayEnterParams = (GameplayEnterParams) enterParams; 
            _gameScope.LevelData = gameplayEnterParams.LevelData;
            _gameScope.Level = gameplayEnterParams.Level;
            _gameScope.Location = gameplayEnterParams.Location;
            uiRootView.AttachSceneUI(_uiGameplayRoot.gameObject);
            _uiGameplayRoot.Bind(() => _stateMachine.ChangeState(_endGameState));

            _stateMachine.ChangeState(_initializeCardState);
        }
    }
}