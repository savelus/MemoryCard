﻿
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Core.View {
    public class CardView : MonoBehaviour {
        public event UnityAction CardClicked;
        
        [SerializeField] private TextMeshProUGUI _damage;
        [SerializeField] private Image _image;
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _root;
        private void Awake() {
            _button.onClick.AddListener(()=> CardClicked?.Invoke());
        }

        public void ChangeColor(Color color) {
            _image.color = color;
        }
        
        public void ChangeSprite(Sprite sprite) {
            _image.sprite = sprite;
        }
        
        public void ChangeDamage(int power) {
            _damage.text = power.ToString();
        }

        public void Disable() {
            _root.SetActive(false);
        }

        public void OpenCard(Color frontSideColor) {
            _root.SetActive(true);
            _image.color = frontSideColor;
            _damage.gameObject.SetActive(true);
        }
        
        public void CloseCard(Color backSideColor) {
            _root.SetActive(true);
            _image.color = backSideColor;
            _damage.gameObject.SetActive(false);
        }
    }
}