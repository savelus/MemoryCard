using System;
using Memory2.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Core.Root.View {
    public class EndGameView : MonoBehaviour {
        
        [SerializeField] private TextMeshProUGUI _title;
        [SerializeField] private TextMeshProUGUI _score;
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton;


        public void SubscribeOnMenuButtonClick(UnityAction callback) {
            _menuButton.Subscribe(callback);
        }
        
        public void SubscribeOnRestartButtonClick(UnityAction callback) {
            _restartButton.Subscribe(callback);
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
