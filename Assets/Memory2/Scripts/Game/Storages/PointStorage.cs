using Memory2.Scripts.Core.Storages;
using Memory2.Scripts.Global.Storages.Root;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Storages {
    public sealed class PointStorage : ISave {
        private const string Key = "Points";
        public event UnityAction<float> ValueChanged;

        private float _points;

        public PointStorage() {
            _points = PlayerPrefs.GetFloat(Key, 0);
        }

        public float Get() {
            return _points;
        }

        public void Set(float points) {
            _points = points;
            OnPointsChanged();
        }

        public void Add(float points) {
            _points += points;
            OnPointsChanged();
        }

        public bool Subtract(float points) {
            if (points > _points) return false;
            _points -= points;
            OnPointsChanged();
            return true;
        }

        public string GetKey() {
            return Key;
        }

        public void Save() {
            PlayerPrefs.SetFloat(Key, _points);
            PlayerPrefs.Save();
        }

        private void OnPointsChanged() {
            ValueChanged?.Invoke(_points);
        }
    }
}