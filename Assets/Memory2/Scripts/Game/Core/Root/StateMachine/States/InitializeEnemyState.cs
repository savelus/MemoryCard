using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Services;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class InitializeEnemyState : State {
        private readonly EnemyService _enemyService;

        public InitializeEnemyState(Base.StateMachine stateMachine, EnemyService enemyService) : base(stateMachine) {
            _enemyService = enemyService;
        }
        
        public override void Enter() {
            _enemyService.SpawnEnemy();
        }
    }
}