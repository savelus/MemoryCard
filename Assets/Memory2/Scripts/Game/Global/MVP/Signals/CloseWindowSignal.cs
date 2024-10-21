using Memory2.Scripts.Game.Global.MVP.Enums;

namespace Memory2.Scripts.Game.Global.MVP.Signals {
    public struct CloseWindowSignal {
        public WindowKey Key;

        public CloseWindowSignal(WindowKey key) {
            Key = key;
        }
    }
}
