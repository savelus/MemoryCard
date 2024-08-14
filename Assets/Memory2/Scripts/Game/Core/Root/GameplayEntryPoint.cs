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
        private StateMachine.Base.StateMachine _stateMachine;
        private UIGameplayRoot _uiGameplayRoot;
        private InitializeCardState _initializeCardState;

        [Inject]
        public void Construct(StateMachine.Base.StateMachine stateMachine, InitializeCardState initializeCardState, UIGameplayRoot uiGameplayRoot) {
            _stateMachine = stateMachine;
            _initializeCardState = initializeCardState;
            _uiGameplayRoot = uiGameplayRoot;
        }
        
        public Observable<GameplayExitParams> Run(UIRootView uiRootView, GameplayEnterParams enterParams) {
            uiRootView.AttachSceneUI(_uiGameplayRoot.gameObject);

            var exitSceneSignalSubj = new Subject<Unit>();
            _uiGameplayRoot.Bind(exitSceneSignalSubj);
            
            Debug.Log($"GAMEPLAY ENTRY POINT. Results:  save file name = {enterParams?.SaveFileName}, level number = {enterParams?.LevelNumber}");
            
            var mainMenuEnterParams = new MainMenuEnterParams("Fatality");
            var exitParams = new GameplayExitParams(mainMenuEnterParams);
            
            _stateMachine.ChangeState(_initializeCardState);
            
            var exitToMainMenuSceneSignal = exitSceneSignalSubj.Select(_ => exitParams);
            
            return exitToMainMenuSceneSignal;
        }

    }
}