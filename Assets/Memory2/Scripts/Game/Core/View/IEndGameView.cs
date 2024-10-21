using Memory2.Scripts.Game.Global.MVP.WindowService;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Core.View {
    public interface IEndGameView : IWindowView {
        void SubscribeOnMenuButtonClick(UnityAction callback);
        void SubscribeOnRestartButtonClick(UnityAction callback);
        void ShowWindow(string title, string score, string money, Color color);
    }
}