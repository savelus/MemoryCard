using Memory2.Scripts.Core.Storages;
using Memory2.Scripts.Global.Storages.Root;
using UnityEngine;
using UnityEngine.Events;
using Zenject;

namespace Memory2.Scripts.Meta.Storages {
    public class MoneyStorage : IStorage<float>, IInitializable {
        public event UnityAction<float> ValueChanged;

        private float _value;
        private const string Key = "Money";

        void IInitializable.Initialize() => _value = PlayerPrefs.GetFloat(Key, 0);

        public string GetKey() => Key;
        public void Save() => PlayerPrefs.SetFloat(Key, _value);

        public float Get() => _value;

        public void Set(float value) {
            _value = value;
            ValueChanged?.Invoke(_value);
            Save();
        }

        public void Add(float value) {
            _value += value;
            ValueChanged?.Invoke(_value);
            Save();
        }

        public bool Subtract(float value) {
            if (_value < value) return false;

            _value -= value;
            ValueChanged?.Invoke(_value);
            Save();

            return true;
        }
    }
}