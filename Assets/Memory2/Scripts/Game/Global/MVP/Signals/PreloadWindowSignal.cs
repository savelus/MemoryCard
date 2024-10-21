using Memory2.Scripts.Game.Global.MVP.Enums;

namespace Memory2.Scripts.Game.Global.MVP.Signals {
    public class PreloadWindowSignal {
        public WindowKey Key;

        public PreloadWindowSignal(WindowKey key) {
            Key = key;
        }
    }
}