using System.Threading.Tasks;
using Memory2.Scripts.Game.Global.Storages;
using Memory2.Scripts.Game.Global.Storages.Root;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Core.Storages {
    public sealed class PointStorage : ISave {
        private const string Key = "Points";
        public event UnityAction<int> ValueChanged;

        private int _points;
        
        public PointStorage() {
            _points = PlayerPrefs.GetInt(Key, 0);
        }

        public int Get() {
            return _points;
        }

        public void Set(int points) {
            _points = points;
            OnPointsChanged();
        }
        public void Add(int points) {
            _points += points;
            OnPointsChanged();
        }
        
        public bool Subtract(int points) {
            if (points > _points) return false;
            _points -= points;
            OnPointsChanged();
            return true;
        }

        public string GetKey() {
            return Key;
        }

        public void Save() {
            PlayerPrefs.SetInt(Key, _points);
            PlayerPrefs.Save();
        }

        private void OnPointsChanged() {
            ValueChanged?.Invoke(_points);
        }
    }
}