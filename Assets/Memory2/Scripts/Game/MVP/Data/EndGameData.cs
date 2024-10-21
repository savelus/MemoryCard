using Memory2.Scripts.Core.MVP.Base;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.MVP.Data {
    public class EndGameData : IWindowData {
        public UnityAction OnMenuButtonClick;
        public UnityAction OnRestartButtonClick;
        public bool IsWin;
    }
}