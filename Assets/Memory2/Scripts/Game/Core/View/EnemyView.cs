using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Core.View {
    public class EnemyView : MonoBehaviour {
        [SerializeField] private Image _image;
        [SerializeField] private Image _element;
        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private TextMeshProUGUI _name;

        public void InitView(string enemyName, string health, Sprite enemy, Sprite element) {
            SetName(enemyName);
            SetHealth(health);
            SetImage(enemy);
            SetElement(element);
        }

        public void SetElement(Sprite element) {
            _element.sprite = element;
        }

        public void SetName(string enemyName) {
            _name.text = enemyName;
        }
        
        public void SetHealth(string health) {
            _health.text = health;
        }
        
        public void SetImage(Sprite sprite) {
            _image.sprite = sprite;
        }
    }
}