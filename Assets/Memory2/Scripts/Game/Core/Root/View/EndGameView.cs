using Memory2.Scripts.Game.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Core.Root.View {
    public class EndGameView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Button _menuButton;

        public void Init(UnityAction menuButtonAction) {
            _menuButton.Subscribe(menuButtonAction);
            Hide();
        }

        public void ShowWinWindow(string score) {
            _title.text = "Победа!";
            _score.text = score;
            _score.color = Color.green;
            gameObject.SetActive(true);
        }
        
        public void ShowLoseWindow(string score) {
            _title.text = "Поражение";
            _score.text = score;
            _score.color = Color.red;
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}
