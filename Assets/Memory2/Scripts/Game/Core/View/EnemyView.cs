using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Core.View {
    public class EnemyView : MonoBehaviour {
        [SerializeField] private Image _image;
        [SerializeField] private TextMeshProUGUI _health;
        [SerializeField] private TextMeshProUGUI _name;

        public void InitView(string enemyName, string health, Sprite sprite) {
            SetName(enemyName);
            SetHealth(health);
            SetImage(sprite);
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