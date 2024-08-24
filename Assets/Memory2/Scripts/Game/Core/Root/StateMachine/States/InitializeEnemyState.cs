using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Services;
using Memory2.Scripts.Game.Timer;
using UnityEngine;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class InitializeEnemyState : State {
        private readonly EnemyService _enemyService;
        private readonly EndGameState _endGameState;
        private readonly StartTimerState _nextState;
        private readonly TimerFactory _timerFactory;

        public InitializeEnemyState(Base.StateMachine stateMachine, 
                                    EnemyService enemyService, 
                                    EndGameState endGameState,
                                    StartTimerState nextState,
                                    TimerFactory timerFactory
                                    ) : base(stateMachine) {
            _enemyService = enemyService;
            _endGameState = endGameState;
            _nextState = nextState;
            _timerFactory = timerFactory;
        }
        
        public override void Enter() {
            _enemyService.SpawnEnemy();
            _enemyService.EnemyDead += EndState;
            
            _stateMachine.ChangeState(_nextState);
        }

        private void EndState() {
            _enemyService.EnemyDead -= EndState;
            _stateMachine.ChangeState(_endGameState);
        }
    }
}