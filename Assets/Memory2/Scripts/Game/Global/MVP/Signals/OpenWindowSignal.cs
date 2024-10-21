using Memory2.Scripts.Game.Global.MVP.Enums;
using Memory2.Scripts.Game.Global.MVP.WindowService;

namespace Memory2.Scripts.Game.Global.MVP.Signals {
    public struct OpenWindowSignal {
        public WindowKey Key;
        public IWindowData Data;

        public OpenWindowSignal(WindowKey key, IWindowData data) {
            Key = key;
            Data = data;
        }
    }
}
