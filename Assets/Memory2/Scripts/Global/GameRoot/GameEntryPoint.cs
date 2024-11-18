using System.Collections;
using Memory2.Scripts.Core;
using Memory2.Scripts.Core.Utils;
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

        public void LoadMainMenuScene(SceneEnterParams enterParams = null) {
            _coroutines.StartCoroutine(LoadAndStartMainMenu(enterParams));
        }


        public void LoadGameplayScene(SceneEnterParams enterParams) {
            _coroutines.StartCoroutine(LoadAndStartGameplay(enterParams));
        }

        private void RunGame() {
            _coroutines.StartCoroutine(LoadAndStartMainMenu());
        }

        private IEnumerator LoadAndStartGameplay(SceneEnterParams enterParams) {
            _uiRootView.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.GAMEPLAY);

            var sceneEntryPoint = Object.FindFirstObjectByType<EntryPoint>();
            sceneEntryPoint.Run(_uiRootView, enterParams);

            _uiRootView.HideLoadingScreen();
        }

        private IEnumerator LoadAndStartMainMenu(SceneEnterParams enterParams = null) {
            _uiRootView.ShowLoadingScreen();

            yield return LoadScene(Scenes.BOOT);
            yield return LoadScene(Scenes.MAIN_MENU);

            var menuEntryPoint = Object.FindFirstObjectByType<EntryPoint>();
            menuEntryPoint.Run(_uiRootView, enterParams);

            _uiRootView.HideLoadingScreen();
        }

        private IEnumerator LoadScene(string sceneName) {
            yield return SceneManager.LoadSceneAsync(sceneName);
        }
    }
}