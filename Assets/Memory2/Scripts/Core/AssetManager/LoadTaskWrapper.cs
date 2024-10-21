using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.AssetManager.Interfaces;

namespace Memory2.Scripts.Core.AssetManager {
    public class LoadTaskWrapper<TLoad> : ILoadTaskWrapper {
        public UniTask<TLoad> Task;
    }
}