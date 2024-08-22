using System;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Timer {
    public class Timer {
        public event Action TimerEnded;
        public event Action TimerStopped;
        public event Action TimerResumed;
        public event Action SecondPassed;

        public float TimeLeft => _timeLeft;
        public int SecondsLeft => _secondsLeft;
        
        private int _duration;
        private float _timeLeft;
        private int _secondsLeft;
        private bool _isPlaying;

        public void Start(int duration) {
            _duration = duration;
            _timeLeft = duration;
            _secondsLeft = duration;
            _isPlaying = true;
        }

        public void Stop() {
            _isPlaying = false;
            TimerStopped?.Invoke();
        }

        public void Resume() {
            _isPlaying = true;
            TimerResumed?.Invoke();
        }

        public void Tick(float deltaTime) {
            if (!_isPlaying) return;

            _timeLeft -= deltaTime;
            if ((int)_timeLeft < _secondsLeft) {
                _secondsLeft = (int)_timeLeft;
                SecondPassed?.Invoke();
            }

            if (_timeLeft <= 0) {
                _timeLeft = 0;
                Stop();
                TimerEnded?.Invoke();
            }
        }
    }
}