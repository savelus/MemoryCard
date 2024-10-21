﻿using UnityEngine;

namespace Memory2.Scripts.Global.GameRoot {
    public class UIRootView : MonoBehaviour {
        [SerializeField] private GameObject _loadingScreen;
        [SerializeField] private Transform _uiSceneContainer;

        private void Awake() {
            HideLoadingScreen();
        }

        public void ShowLoadingScreen() {
            _loadingScreen.SetActive(true);
        }

        public void HideLoadingScreen() {
            _loadingScreen.SetActive(false);
        }

        public void AttachSceneUI(GameObject sceneUI) {
            ClearSceneUI();

            sceneUI.transform.SetParent(_uiSceneContainer, false);
        }

        public void AddSceneUI(Transform sceneUI) {
            sceneUI.transform.SetParent(_uiSceneContainer, false);
        }

        private void ClearSceneUI() {
            var childCount = _uiSceneContainer.childCount;
            for (int i = 0; i < childCount; i++) {
                Destroy(_uiSceneContainer.GetChild(i).gameObject);
            }
        }
    }
}