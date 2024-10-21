using Cysharp.Threading.Tasks;
using Memory2.Scripts.Game.Global.MVP.AssetManager.Interfaces;

namespace Memory2.Scripts.Game.Global.MVP.AssetManager {
    public class LoadTaskWrapper<TLoad> : ILoadTaskWrapper {
        public UniTask<TLoad> Task;
    }
}