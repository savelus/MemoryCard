using System;
using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Root.View;
using Memory2.Scripts.Game.Global.Timer;
using UnityEngine;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class StartTimerState : State {
        private readonly TimerFactory _timerFactory;
        private readonly TimerPresenter _timerPresenter;
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly EndGameState _nextState;
        private readonly GameScope _gameScope;

        public StartTimerState(Base.StateMachine stateMachine,
                               TimerFactory timerFactory,
                               TimerPresenter timerPresenter,
                               UIGameplayRoot uiGameplayRoot,
                               EndGameState nextState,
                               GameScope gameScope) : base(stateMachine) {
            _timerFactory = timerFactory;
            _timerPresenter = timerPresenter;
            _uiGameplayRoot = uiGameplayRoot;
            _nextState = nextState;
            _gameScope = gameScope;
        }

        public override void Enter() {
            var seconds = _gameScope.LevelData.Seconds;
            var timer = _timerFactory.GetTimer(TimerKey.Game);
            timer.TimerEnded += OnTimerEnded;
            timer.SecondPassed += OnSecondPassed;
            timer.Start(seconds);
            
            _uiGameplayRoot.AddTimer(_timerPresenter.GetTransform());
        }

        private void OnSecondPassed() {
            Debug.Log("Tick");
        }

        private void OnTimerEnded() {
            _stateMachine.ChangeState(_nextState);
        }
    }
}