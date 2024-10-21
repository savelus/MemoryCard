using Memory2.Scripts.Game.Global.MVP.Base;
using Memory2.Scripts.Game.Global.MVP.VisibilityMechanisms;
using Memory2.Scripts.Utils;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Core.View {
    public class EndGameView : BaseWindow, IEndGameView {
        [SerializeField] private CanvasGroup _group;
        [SerializeField] private TextMeshProUGUI _score;

        [SerializeField] private TextMeshProUGUI _money;
        
        [SerializeField] private Button _menuButton;
        [SerializeField] private Button _restartButton;
        
        protected override void OnEnable() {
            ChangeShowMechanism(new FadeShowMechanism(_group));
            ChangeHideMechanism(new FadeHideMechanism(_group));
        }
        
        public void ShowWindow(string title, string score, string money, Color color) {
            ChangeHeader(title);
            _score.text = score;
            _score.color = color;
            _money.text = money;
        }

        public void SubscribeOnMenuButtonClick(UnityAction callback) {
            _menuButton.Subscribe(callback);
        }

        public void SubscribeOnRestartButtonClick(UnityAction callback) {
            _restartButton.Subscribe(callback);
        }
    }
}
