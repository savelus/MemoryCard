using Memory2.Scripts.Core.StateMachine.Base;
using Memory2.Scripts.Game;
using Memory2.Scripts.Game.MVP.Presenters;
using Memory2.Scripts.Game.MVP.View;
using Memory2.Scripts.Global.Timer;

namespace Memory2.Scripts.Core.StateMachine.States {
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
            timer.Start(seconds);

            _uiGameplayRoot.AddTimer(_timerPresenter.GetTransform());
        }

        private void OnTimerEnded() {
            _stateMachine.ChangeState(_nextState);
        }
    }
}