using Memory2.Scripts.Game.Core.Root;
using Memory2.Scripts.Game.GameRoot;
using Memory2.Scripts.Game.Meta.Root.View;
using R3;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.Root {
    public class MainMenuEntryPoint : MonoBehaviour {
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;

        public Observable<MainMenuExitParams> Run(UIRootView uiRootView, MainMenuEnterParams enterParams) {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRootView.AttachSceneUI(uiScene.gameObject);

            var exitSignalSubject = new Subject<Unit>();
            uiScene.Bind(exitSignalSubject);
            
            Debug.Log($"MAIN MENU ENTRY POINT. Results: {enterParams?.Result}");

            var gameplayEnterParams = new GameplayEnterParams("FileName", 5);
            var mainMenuExitParams = new MainMenuExitParams(gameplayEnterParams);
            
            var exitToGameplaySceneSignal = exitSignalSubject.Select(_ => mainMenuExitParams);
            return exitToGameplaySceneSignal;
        }
    }
}