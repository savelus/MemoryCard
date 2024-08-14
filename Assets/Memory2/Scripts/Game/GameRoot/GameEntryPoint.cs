using System.Collections;
using Memory2.Scripts.Game.Core.Root;
using Memory2.Scripts.Game.Meta.Root;
using Memory2.Scripts.Utils;
using R3;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Memory2.Scripts.Game.GameRoot {
    public class GameEntryPoint {
        private static GameEntryPoint _instance;
        private readonly Coroutines _coroutines;
        private UIRootView _uiRootView;
        //
        // [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        // public static void AutoStartGame() {
        //     _instance = new GameEntryPoint();
        //     _instance.RunGame();
        // }
        
        private GameEntryPoint(UIRootView uiRootView) {
            
            _uiRootView = uiRootView;
            _coroutines = new GameObject("[COROUTINES]").AddComponent<Coroutines>();
            Object.DontDestroyOnLoad(_coroutines.gameObject);
            RunGame();
            // var prefabUIRoot = Resources.Load<UIRootView>("UIRoot");
            // _uiRootView = Object.Instantiate(prefabUIRoot);
            // Object.DontDestroyOnLoad(_uiRootView.gameObject);
        }
        
        private void RunGame() {
#if UNITY_EDITOR
            var sceneName = SceneManager.GetActiveScene().name;
            if (sceneName == Scenes.GAMEPLAY) {
                var gameplayEnterParams = new GameplayEnterParams("FileNamee", 4);
                _coroutines.StartCoroutine(LoadAndStartGameplay(gameplayEnterParams));
                return;
            }
            
            if (sceneName == Scenes.MAIN_MENU) {
                _coroutines.StartCoroutine(LoadAndStartMainMenu());
                return;
            }

            if (sceneName != Scenes.BOOT) {
                return;
            }
#endif
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }

        private IEnumerator LoadAndStartGameplay(GameplayEnterParams enterParams) {
            _uiRootView.ShowLoadingScreen();
            
            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.GAMEPLAY);

            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            sceneEntryPoint.Run(_uiRootView, enterParams).Subscribe(gameplayExitParams => {
                _coroutines.StartCoroutine(LoadAndStartMainMenu(gameplayExitParams.MainMenuEnterParams));
            });

            _uiRootView.HideLoadingScreen();
        }
        
        private IEnumerator LoadAndStartMainMenu(MainMenuEnterParams enterParams = null) {
            _uiRootView.ShowLoadingScreen();
            
            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MAIN_MENU);
            
            var sceneEntryPoint = Object.FindFirstObjectByType<MainMenuEntryPoint>();
            sceneEntryPoint.Run(_uiRootView, enterParams).Subscribe(mainMenuExitParams => {
                var targetSceneName = mainMenuExitParams.TargetSceneEnterParams.SceneName;
                if (targetSceneName == Scenes.GAMEPLAY) {
                    _coroutines.StartCoroutine(LoadAndStartGameplay(mainMenuExitParams.TargetSceneEnterParams.As<GameplayEnterParams>()));
                }
            });
            
            
            _uiRootView.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName) {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}