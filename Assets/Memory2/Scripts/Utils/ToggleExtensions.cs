using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Utils {
    public static class ToggleExtensions {
        public static void Subscribe(this Toggle toggle, UnityAction<bool> callback) {
            toggle.onValueChanged.RemoveAllListeners();
            toggle.onValueChanged.AddListener(callback);
        }
    }
}