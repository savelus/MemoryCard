using System.Collections.Generic;
using UnityEngine;

namespace Memory2.Scripts.Utils.GameObjectPool {
    public class GameObjectPool<T> where T : MonoBehaviour {
        private T _prefab;
        private readonly Transform _parent;

        private Stack<T> _elements = new();

        public GameObjectPool(T prefab, int initialCount, Transform parent = null) {
            _prefab = prefab;
            _parent = parent;

            for (int i = 0; i < initialCount; i++) {
                Create();
            }
        }

        public T Get() {
            if (_elements.Count == 0) {
                Create();
            }

            return _elements.Pop();
        }

        public void Release(T element) {
            element.gameObject.SetActive(false);
            _elements.Push(element);
        }

        private void Create() {
            var element = Object.Instantiate(_prefab, _parent, false);

            element.gameObject.SetActive(false);
            _elements.Push(element);
        }
    }
}