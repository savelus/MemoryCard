using System;
using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Timer;
using UnityEngine;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class StartTimerState : State {
        private readonly TimerFactory _timerFactory;
        private readonly EndGameState _nextState;

        public StartTimerState(Base.StateMachine stateMachine,
                               TimerFactory timerFactory,
                               EndGameState nextState) : base(stateMachine) {
            _timerFactory = timerFactory;
            _nextState = nextState;
        }

        public override void Enter() {
            var timer = _timerFactory.GetTimer(TimerKey.Game);
            timer.TimerEnded += OnTimerEnded;
            timer.SecondPassed += OnSecondPassed;
            timer.Start(30);
        }

        private void OnSecondPassed() {
            Debug.Log("Tick");
        }

        private void OnTimerEnded() {
            _stateMachine.ChangeState(_nextState);
        }
    }
}