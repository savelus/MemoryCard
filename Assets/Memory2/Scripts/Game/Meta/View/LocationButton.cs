using Memory2.Scripts.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public sealed class LocationButton : MonoBehaviour {
    [SerializeField] private Button _button;
    [SerializeField] private Image _image;

    public void Initialize(Sprite sprite, UnityAction callback) {
        _image.sprite = sprite;
        _button.Subscribe(callback);
        gameObject.SetActive(true);
    }

    public void Hide() {
        gameObject.SetActive(false);
    }
}