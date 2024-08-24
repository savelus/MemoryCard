using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Root.View;
using Memory2.Scripts.Game.Core.Services;
using Memory2.Scripts.Game.Core.Storages;
using Memory2.Scripts.Game.Timer;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class EndGameState : State {
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly PointStorage _pointStorage;
        private readonly TimerFactory _timerFactory;
        private readonly EnemyService _enemyService;

        public EndGameState(Base.StateMachine stateMachine, 
                            UIGameplayRoot uiGameplayRoot, 
                            PointStorage pointStorage,
                            TimerFactory timerFactory,
                            EnemyService enemyService) : base(stateMachine) {
            _uiGameplayRoot = uiGameplayRoot;
            _pointStorage = pointStorage;
            _timerFactory = timerFactory;
            _enemyService = enemyService;
        }

        public override void Enter() {
            var isEnemyAlive = _enemyService.IsEnemyAlive;
            _timerFactory.ReleaseTimer(TimerKey.Game);
            _uiGameplayRoot.ShowEndGamePopUp(_pointStorage.GetPoints(), isEnemyAlive);
        }
    }
}