using Memory2.Scripts.Core.Enums;

namespace Memory2.Scripts.Core.Signals {
    public class PreloadWindowSignal {
        public WindowKey Key;

        public PreloadWindowSignal(WindowKey key) {
            Key = key;
        }
    }
}