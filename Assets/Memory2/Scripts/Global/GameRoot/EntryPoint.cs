using Memory2.Scripts.Core;
using UnityEngine;

namespace Memory2.Scripts.Global.GameRoot {
    public abstract class EntryPoint : MonoBehaviour {
        public abstract void Run(UIRootView uiRootView, SceneEnterParams enterParams);
    }
}