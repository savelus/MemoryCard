using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Services;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class InitializeEnemyState : State {
        private readonly EnemyService _enemyService;
        private readonly DeadEnemyState _deadEnemyState;

        public InitializeEnemyState(Base.StateMachine stateMachine, EnemyService enemyService, DeadEnemyState deadEnemyState) : base(stateMachine) {
            _enemyService = enemyService;
            _deadEnemyState = deadEnemyState;
        }
        
        public override void Enter() {
            _enemyService.SpawnEnemy();
            _enemyService.SubscribeOnGameEnded(EndState);
        }

        private void EndState() {
            _stateMachine.ChangeState(_deadEnemyState);
        }
    }
}