using Memory2.Scripts.Game.Core.Configs;
using Memory2.Scripts.Game.Core.Root.StateMachine.States;
using Memory2.Scripts.Game.Core.Root.View;
using Memory2.Scripts.Game.GameRoot;
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

        [Inject]
        public void Construct(StateMachine.Base.StateMachine stateMachine, 
                              InitializeCardState initializeCardState, 
                              EndGameState endGameState, 
                              UIGameplayRoot uiGameplayRoot,
                              GameEntryPoint gameEntryPoint) {
            _stateMachine = stateMachine;
            _endGameState = endGameState;
            _initializeCardState = initializeCardState;
            _uiGameplayRoot = uiGameplayRoot;
        }
        
        public void Run(UIRootView uiRootView, GameplayEnterParams enterParams) {
            uiRootView.AttachSceneUI(_uiGameplayRoot.gameObject);
            _uiGameplayRoot.Bind(() => _stateMachine.ChangeState(_endGameState));
            
            _stateMachine.ChangeState(_initializeCardState);
            
        }

    }
}