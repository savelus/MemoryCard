using Memory2.Scripts.Game.Global.MVP.WindowService;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Core.Presenters {
    public class EndGameData : IWindowData {
        public UnityAction OnMenuButtonClick;
        public UnityAction OnRestartButtonClick;
        public bool IsWin;
    }
}