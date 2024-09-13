using Memory2.Scripts.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Meta.View {
    public sealed class LocationButton : MonoBehaviour {
        [SerializeField] private Button _button;
        [SerializeField] private Image _image;

        public void Initialize(Sprite sprite, bool isActive, UnityAction callback) {
            _image.sprite = sprite;
            _button.interactable = isActive;
            _button.Subscribe(callback);
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}