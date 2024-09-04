using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Services;
using Memory2.Scripts.Game.Global.Timer;
using UnityEngine;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class InitializeEnemyState : State {
        private readonly EnemyService _enemyService;
        private readonly EndGameState _endGameState;
        private readonly StartTimerState _nextState;
        private readonly GameScope _gameScope;

        public InitializeEnemyState(Base.StateMachine stateMachine, 
                                    EnemyService enemyService, 
                                    EndGameState endGameState,
                                    StartTimerState nextState,
                                    GameScope gameScope) : base(stateMachine) {
            _enemyService = enemyService;
            _endGameState = endGameState;
            _nextState = nextState;
            _gameScope = gameScope;
        }
        
        public override void Enter() {
            var enemyId = _gameScope.LevelData.EnemyId;
            _enemyService.SpawnEnemy(enemyId);
            _enemyService.EnemyDead += EndState;
            
            _stateMachine.ChangeState(_nextState);
        }

        private void EndState() {
            _enemyService.EnemyDead -= EndState;
            _stateMachine.ChangeState(_endGameState);
        }
    }
}