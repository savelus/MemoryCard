using Memory2.Scripts.Core.Enums;

namespace Memory2.Scripts.Core.Signals {
    public struct CloseWindowSignal {
        public WindowKey Key;

        public CloseWindowSignal(WindowKey key) {
            Key = key;
        }
    }
}