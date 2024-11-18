using Memory2.Scripts.Core.Enums;

namespace Memory2.Scripts.Core.MVP.Context {
    public interface IContext {
        GameContext Context();
        void RegisterContext();
        void UnRegisterContext();
    }
}