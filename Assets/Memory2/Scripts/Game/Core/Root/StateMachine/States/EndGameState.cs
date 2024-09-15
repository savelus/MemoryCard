using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Root.View;
using Memory2.Scripts.Game.Core.Services;
using Memory2.Scripts.Game.Core.Storages;
using Memory2.Scripts.Game.Global.GameRoot;
using Memory2.Scripts.Game.Global.Storages;
using Memory2.Scripts.Game.Global.Timer;
using Memory2.Scripts.Game.Meta.Root;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public sealed class EndGameState : State {
        private readonly GameEntryPoint _gameEntryPoint;
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly PointStorage _pointStorage;
        private readonly TimerFactory _timerFactory;
        private readonly EnemyService _enemyService;
        private readonly GameScope _gameScope;
        private readonly ProgressStorage _progressStorage;

        private bool _isEnemyAlive;

        public EndGameState(Base.StateMachine stateMachine,
            GameEntryPoint gameEntryPoint,
            UIGameplayRoot uiGameplayRoot,
            PointStorage pointStorage,
            TimerFactory timerFactory,
            EnemyService enemyService,
            GameScope gameScope,
            ProgressStorage progressStorage) : base(stateMachine) {
            _gameEntryPoint = gameEntryPoint;
            _uiGameplayRoot = uiGameplayRoot;
            _pointStorage = pointStorage;
            _timerFactory = timerFactory;
            _enemyService = enemyService;
            _gameScope = gameScope;
            _progressStorage = progressStorage;
        }

        public override void Enter() {
            var isEnemyAlive = _enemyService.IsEnemyAlive;
            _timerFactory.ReleaseTimer(TimerKey.Game);
            if (!isEnemyAlive) {
                _progressStorage.CompleteLevel(_gameScope.Location, _gameScope.Level);
                _progressStorage.Save();
            }
            
            var endGameView = _uiGameplayRoot.GetEndGameView();
            endGameView.SubscribeOnMenuButtonClick(OnMenuButtonClick);
            endGameView.SubscribeOnRestartButtonClick(OnRestartButtonClick);
            
            ShowEndGamePopUp(endGameView, isEnemyAlive);
        }

        private void ShowEndGamePopUp(EndGameView endGameView, bool isEnemyAlive) {
            _isEnemyAlive = isEnemyAlive;
            if (!isEnemyAlive) {
                endGameView.ShowWinWindow(_pointStorage.Get().ToString("F1"), _gameScope.LevelData.Money.ToString());
            }
            else {
                endGameView.ShowLoseWindow(_pointStorage.Get().ToString("F1"));
            }
        }

        private void OnMenuButtonClick() {
            _gameEntryPoint.LoadMainMenuScene(CreateMainMenuEnterParams());
        }

        private void OnRestartButtonClick() {
            _gameEntryPoint.LoadGameplayScene(CreateGameSceneEnterParams());
        }

        private GameplayEnterParams CreateGameSceneEnterParams() {
            return new GameplayEnterParams(_gameScope.LevelData, _gameScope.Location, _gameScope.Level);
        }

        private MainMenuEnterParams CreateMainMenuEnterParams() {
            return new MainMenuEnterParams(_gameScope.LevelData, !_isEnemyAlive);
        }
    }
}