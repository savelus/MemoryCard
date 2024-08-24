using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Timer {
    public class TimerFactory : ITickable{
        private List<Timer> _timers = new();
        private Dictionary<TimerKey, Timer> _timersMap = new();
        private int _timerIndex;
        private bool _tickStart;

        public Timer GetTimer(TimerKey key) {
            if (_timersMap.TryGetValue(key, out var timer)) {
                return timer;
            }

            timer = GetTimer();
            _timersMap.Add(key, timer);
            return timer;
        }
        
        public Timer GetTimer() {
            var timer = new Timer();
            _timers.Add(timer);
            return timer;
        }

        public void ReleaseTimer(Timer timer, TimerKey key = default) {
            timer.Stop();
            if (_timersMap.ContainsKey(key)) {
                _timersMap.Remove(key);
            }
            _timers.Remove(timer);
            if (_tickStart) _timerIndex--;
        }

        public void ReleaseTimer(TimerKey key) {
            if (_timersMap.TryGetValue(key, out var timer)) {
                timer.Stop();
                _timers.Remove(timer);
                _timersMap.Remove(key);
            }
            
        }
        public void Tick() {
            _tickStart = true;
            var deltaTime = Time.deltaTime;
            for (_timerIndex = 0; _timerIndex < _timers.Count; _timerIndex++) {
                var timer = _timers[_timerIndex];
                timer.Tick(deltaTime);
            }
            
            _tickStart = false;
        }
    }
}