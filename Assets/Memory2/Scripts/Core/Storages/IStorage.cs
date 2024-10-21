using UnityEngine.Events;

namespace Memory2.Scripts.Core.Storages {
    public interface IStorage<T> : ISave {
        event UnityAction<T> ValueChanged;
        T Get();
        void Set(T value);
        void Add(T value);
        bool Subtract(T value);
    }
}