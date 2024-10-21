using Cysharp.Threading.Tasks;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Memory2.Scripts.Game.Global.MVP.AssetManager.Interfaces
{
    public interface IAddressable<T> where T : class
    { 
        UniTask<T> Task { get; }
        AsyncOperationStatus Status { get; }
    }
}