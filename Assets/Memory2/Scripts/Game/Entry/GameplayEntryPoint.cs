using Memory2.Scripts.Core.StateMachine.Base;
using Memory2.Scripts.Core.StateMachine.States;
using Memory2.Scripts.Game.MVP.View;
using Memory2.Scripts.Global.GameRoot;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Entry {
    public class GameplayEntryPoint : MonoBehaviour {
        private UIGameplayRoot _uiGameplayRoot;
        private StateMachine _stateMachine;
        private InitializeCardState _initializeCardState;
        private EndGameState _endGameState;
        private GameScope _gameScope;

        [Inject]
        public void Construct(StateMachine stateMachine,
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

        public void Run(UIRootView uiRootView, GameplayEnterParams enterParams) {
            _gameScope.LevelData = enterParams.LevelData;
            _gameScope.Level = enterParams.Level;
            _gameScope.Location = enterParams.Location;
            uiRootView.AttachSceneUI(_uiGameplayRoot.gameObject);
            _uiGameplayRoot.Bind(() => _stateMachine.ChangeState(_endGameState));

            _stateMachine.ChangeState(_initializeCardState);
        }
    }
}