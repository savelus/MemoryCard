using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Root.View;
using Memory2.Scripts.Game.Core.Services;
using Memory2.Scripts.Game.Core.Storages;
using Memory2.Scripts.Game.GameRoot;
using Memory2.Scripts.Game.Meta.Root;
using Memory2.Scripts.Game.Timer;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class EndGameState : State {
        private readonly GameEntryPoint _gameEntryPoint;
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly PointStorage _pointStorage;
        private readonly TimerFactory _timerFactory;
        private readonly EnemyService _enemyService;

        public EndGameState(Base.StateMachine stateMachine,
            GameEntryPoint gameEntryPoint,
            UIGameplayRoot uiGameplayRoot,
            PointStorage pointStorage,
            TimerFactory timerFactory,
            EnemyService enemyService) : base(stateMachine) {
            _gameEntryPoint = gameEntryPoint;
            _uiGameplayRoot = uiGameplayRoot;
            _pointStorage = pointStorage;
            _timerFactory = timerFactory;
            _enemyService = enemyService;
        }

        public override void Enter() {
            var isEnemyAlive = _enemyService.IsEnemyAlive;
            _timerFactory.ReleaseTimer(TimerKey.Game);
            var endGameView = _uiGameplayRoot.GetEndGameView();
            endGameView.SubscribeOnMenuButtonClick(OnMenuButtonClick);
            ShowEndGamePopUp(endGameView, isEnemyAlive);
        }

        private void ShowEndGamePopUp(EndGameView endGameView, bool isEnemyAlive) {
            if (!isEnemyAlive) {
                endGameView.ShowWinWindow(_pointStorage.GetPoints().ToString());
            }
            else {
                endGameView.ShowLoseWindow(_pointStorage.GetPoints().ToString());
            }
        }

        private void OnMenuButtonClick() {
            _gameEntryPoint.LoadMainMenuScene(CreateMainMenuEnterParams());
        }

        private MainMenuEnterParams CreateMainMenuEnterParams() {
            return new MainMenuEnterParams();
        }
    }
}