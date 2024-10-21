using Memory2.Scripts.Core.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Meta.MVP.View {
    public class LevelButton : MonoBehaviour {
        [SerializeField] private Button _button;
        [SerializeField] private TextMeshProUGUI _text;

        public void Initialize(string text, bool isOpen, UnityAction callback = null) {
            _text.text = text;
            _button.interactable = isOpen;
            _button.Subscribe(callback);
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}