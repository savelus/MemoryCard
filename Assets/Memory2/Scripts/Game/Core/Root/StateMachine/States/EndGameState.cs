using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Services;
using Memory2.Scripts.Game.Global.GameRoot;
using Memory2.Scripts.Game.Global.MVP.Enums;
using Memory2.Scripts.Game.Global.MVP.Signals;
using Memory2.Scripts.Game.Global.Storages;
using Memory2.Scripts.Game.Global.Timer;
using Memory2.Scripts.Game.Meta.Root;
using Zenject;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public sealed class EndGameState : State {
        private readonly GameEntryPoint _gameEntryPoint;
        private readonly TimerFactory _timerFactory;
        private readonly EnemyService _enemyService;
        private readonly GameScope _gameScope;
        private readonly ProgressStorage _progressStorage;
        private readonly SignalBus _signalBus;

        private bool _isEnemyAlive;

        public EndGameState(Base.StateMachine stateMachine,
                            GameEntryPoint gameEntryPoint,
                            TimerFactory timerFactory,
                            EnemyService enemyService,
                            GameScope gameScope,
                            ProgressStorage progressStorage,
                            SignalBus signalBus) : base(stateMachine) {
            _gameEntryPoint = gameEntryPoint;
            _timerFactory = timerFactory;
            _enemyService = enemyService;
            _gameScope = gameScope;
            _progressStorage = progressStorage;
            _signalBus = signalBus;
        }

        public override void Enter() {
            var isEnemyAlive = _enemyService.IsEnemyAlive;
            _timerFactory.ReleaseTimer(TimerKey.Game);
            if (!isEnemyAlive) {
                _progressStorage.CompleteLevel(_gameScope.Location, _gameScope.Level);
                _progressStorage.Save();
            }
            
            _signalBus.Fire(new OpenWindowSignal(WindowKey.EndGame, 
                new EndGameData {IsWin = !_isEnemyAlive, OnMenuButtonClick = OnMenuButtonClick, OnRestartButtonClick = OnRestartButtonClick}));
        }

        private void OnMenuButtonClick() {
            _gameEntryPoint.LoadMainMenuScene(CreateMainMenuEnterParams());
        }

        private void OnRestartButtonClick() {
            _gameEntryPoint.LoadGameplayScene(CreateGameSceneEnterParams());
        }

        private GameplayEnterParams CreateGameSceneEnterParams() {
            return new(_gameScope.LevelData, _gameScope.Location, _gameScope.Level);
        }

        private MainMenuEnterParams CreateMainMenuEnterParams() {
            return new(_gameScope.LevelData, !_isEnemyAlive);
        }
    }
}