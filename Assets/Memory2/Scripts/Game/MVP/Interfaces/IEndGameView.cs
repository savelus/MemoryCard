using Memory2.Scripts.Core.MVP.Base;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.MVP.Interfaces {
    public interface IEndGameView : IWindowView {
        void SubscribeOnMenuButtonClick(UnityAction callback);
        void SubscribeOnRestartButtonClick(UnityAction callback);
        void ShowWindow(string title, string score, string money, Color color);
    }
}