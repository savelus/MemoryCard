using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Core.Storages {
    public sealed class PointStorage {
        public readonly string Key = "Points";
        public event UnityAction<int> PointsChanged;

        private int _points;
        
        public PointStorage() {
            _points = PlayerPrefs.GetInt(Key, 0);
        }

        public int GetPoints() {
            return _points;
        }
        
        public void AddPoints(int points) {
            _points += points;
            OnPointsChanged();
        }
        
        public bool SubtractPoints(int points) {
            if (points > _points) return false;
            _points -= points;
            OnPointsChanged();
            return true;
        }
        
        public void Save() {
            PlayerPrefs.SetInt(Key, _points);
            PlayerPrefs.Save();
        }

        private void OnPointsChanged() {
            PointsChanged?.Invoke(_points);
        }
    }
}