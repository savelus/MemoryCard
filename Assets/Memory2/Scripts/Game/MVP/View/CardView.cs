using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.MVP.View {
    public class CardView : MonoBehaviour {
        private event UnityAction CardClicked;

        [SerializeField] private TextMeshProUGUI _damage;
        [SerializeField] private Image _image;
        [SerializeField] private Image _element;
        [SerializeField] private Button _button;
        [SerializeField] private GameObject _root;
        [SerializeField] private GameObject _openSide;

        private void Awake() {
            _button.onClick.AddListener(() => CardClicked?.Invoke());
        }

        public void SubscribeOnCardClicked(UnityAction callback) {
            CardClicked = null;
            CardClicked += callback;
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

        public void OpenCard(Color frontSideColor, Sprite element) {
            _root.SetActive(true);
            _image.color = frontSideColor;
            _element.sprite = element;
            _openSide.SetActive(true);
        }

        public void CloseCard(Color backSideColor) {
            _root.SetActive(true);
            _image.color = backSideColor;
            _openSide.SetActive(false);
        }
    }
}