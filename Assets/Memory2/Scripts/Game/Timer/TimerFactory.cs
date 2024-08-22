using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Timer {
    public class TimerFactory : ITickable{
        private List<Timer> _timers = new();
        private Dictionary<TimerKey, Timer> _timersMap = new();

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
        }


        public void Tick() {
            var deltaTime = Time.deltaTime; 
            foreach (var timer in _timers) {
                timer.Tick(deltaTime);
            }
        }
    }
}