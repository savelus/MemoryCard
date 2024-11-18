using Memory2.Scripts.Core.Enums;
using Memory2.Scripts.Core.MVP.Base;

namespace Memory2.Scripts.Core.Signals {
    public struct OpenWindowSignal {
        public WindowKey Key;
        public IWindowData Data;

        public OpenWindowSignal(WindowKey key, IWindowData data) {
            Key = key;
            Data = data;
        }
    }
}