using Memory2.Scripts.Game.Global.MVP.Enums;

namespace Memory2.Scripts.Game.Global.MVP.Context {
    public interface IContext {
        GameContext Context();
        void RegisterContext();
        void UnRegisterContext();
    }
}