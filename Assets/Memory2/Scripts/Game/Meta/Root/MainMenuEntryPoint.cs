using Memory2.Scripts.Game.Core.Root;
using Memory2.Scripts.Game.GameRoot;
using Memory2.Scripts.Game.Meta.Root.View;
using R3;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Root {
    public class MainMenuEntryPoint : MonoBehaviour {
        [SerializeField] private UIMainMenuRootBinder _sceneUIRootPrefab;
        private GameEntryPoint _gameEntryPoint;

        [Inject]
        public void Construct(GameEntryPoint gameEntryPoint) {
            _gameEntryPoint = gameEntryPoint;
            
        }
        public void Run(UIRootView uiRootView, MainMenuEnterParams enterParams) {
            var uiScene = Instantiate(_sceneUIRootPrefab);
            uiRootView.AttachSceneUI(uiScene.gameObject);

            uiScene.Bind(() => _gameEntryPoint.LoadGameplayScene(CreateGameplayEnterParams()));

        }

        private GameplayEnterParams CreateGameplayEnterParams() {
            return new GameplayEnterParams();
        }
        
    }
}