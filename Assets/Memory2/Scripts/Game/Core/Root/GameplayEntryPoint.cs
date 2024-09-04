using Memory2.Scripts.Game.Core.Configs;
using Memory2.Scripts.Game.Core.Root.StateMachine.States;
using Memory2.Scripts.Game.Core.Root.View;
using Memory2.Scripts.Game.Global.GameRoot;
using Memory2.Scripts.Game.Meta.Root;
using R3;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Core.Root {
    public class GameplayEntryPoint : MonoBehaviour {
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
        
        public void Run(UIRootView uiRootView, GameplayEnterParams enterParams) {
            _gameScope.LevelData = enterParams.LevelData;
            uiRootView.AttachSceneUI(_uiGameplayRoot.gameObject);
            _uiGameplayRoot.Bind(() => _stateMachine.ChangeState(_endGameState));
            
            _stateMachine.ChangeState(_initializeCardState);
            
        }
    }
}