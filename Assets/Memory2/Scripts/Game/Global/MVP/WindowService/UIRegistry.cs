using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Global.MVP.Enums;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Global.MVP.WindowService {
    [Serializable]
    public class UIContainerToGameObjectElement {
        public UIContainerType Key;
        public GameObject Holder;
    }

    public class UIRegistry : MonoBehaviour {
        [SerializeField]
        private List<UIContainerToGameObjectElement> _containers = new();

        private void Awake() {
            DontDestroyOnLoad(gameObject);
        }

        [Inject]
        private void Construct(WindowService windowService) {
            windowService.RegisterContainers(_containers);
        }
    }
}
