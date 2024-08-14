using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Extensions {
    public static class ButtonExtensions {
        public static void Subscribe(this Button button, UnityAction callback) {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(callback);
        }
    }
}