using System.Collections;
using Memory2.Scripts.Core.Utils;
using Memory2.Scripts.Game.Entry;
using Memory2.Scripts.Meta.Enter;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Memory2.Scripts.Global.GameRoot {
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
        }

        public void LoadMainMenuScene(MainMenuEnterParams enterParams = null) {
            _coroutines.StartCoroutine(LoadAndStartMainMenu(enterParams));
        }

        public void LoadGameplayScene(GameplayEnterParams enterParams) {
            _coroutines.StartCoroutine(LoadAndStartGameplay(enterParams));
        }

        private void RunGame() {
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }

        private IEnumerator LoadAndStartGameplay(GameplayEnterParams enterParams) {
            _uiRootView.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.GAMEPLAY);

            var sceneEntryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();
            sceneEntryPoint.Run(_uiRootView, enterParams);

            _uiRootView.HideLoadingScreen();
        }

        private IEnumerator LoadAndStartMainMenu(MainMenuEnterParams enterParams = null) {
            _uiRootView.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MAIN_MENU);

            var menuEntryPoint = Object.FindFirstObjectByType<MainMenuEntryPoint>();
            menuEntryPoint.Run(_uiRootView, enterParams);

            _uiRootView.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName) {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}