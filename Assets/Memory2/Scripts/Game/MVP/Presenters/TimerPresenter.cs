using Memory2.Scripts.Game.MVP.View;
using Memory2.Scripts.Global.Timer;
using UnityEngine;

namespace Memory2.Scripts.Game.MVP.Presenters {
    public class TimerPresenter {
        private readonly GameTimerView _timerView;
        private readonly Timer _timer;
        private int _startTime;


        public TimerPresenter(GameTimerView timerView, TimerFactory timerFactory) {
            _timerView = timerView;
            _timer = timerFactory.GetTimer(TimerKey.Game);
            _timer.TimerStarted += OnTimerStarted;
            _timer.SecondPassed += OnTimerChanged;
        }

        public Transform GetTransform() => _timerView.transform;

        private void OnTimerStarted() {
            _startTime = _timer.SecondsLeft;
            OnTimerChanged();
        }

        private void OnTimerChanged() {
            var currentTime = _timer.SecondsLeft;
            var timePercent = (float)currentTime / _startTime;
            _timerView.SetTimer(currentTime.ToString(), timePercent);
        }
    }
}