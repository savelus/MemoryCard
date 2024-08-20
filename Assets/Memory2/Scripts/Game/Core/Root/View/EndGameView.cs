using Memory2.Scripts.Game.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Core.Root.View {
    public class EndGameView : MonoBehaviour {
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Button _menuButton;

        public void Init(UnityAction menuButtonAction) {
            _menuButton.Subscribe(menuButtonAction);
            Hide();
        }

        public void Show(string score) {
            _score.text = score;
            gameObject.SetActive(true);
        }

        public void Hide() {
            gameObject.SetActive(false);
        }
    }
}
