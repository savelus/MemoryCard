using Cysharp.Threading.Tasks;
using Memory2.Scripts.Core.MVP.Base;
using Memory2.Scripts.Game.MVP.Data;
using Memory2.Scripts.Game.MVP.Interfaces;
using Memory2.Scripts.Game.Storages;
using Memory2.Scripts.Global.MVP.Context;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.MVP.Presenters {
    public class EndGamePresenter : BaseWindowPresenter<IEndGameView, EndGameData> {
        private PointStorage _pointStorage;
        private GameScope _gameScope;

        private const string WIN_TEXT = "Победа!";
        private const string LOSE_TEXT = "Поражение!";

        private static readonly Color WinColor = Color.green;
        private static readonly Color LoseColor = Color.red;

        [Inject]
        public void Construct(PointStorage pointStorage,
            GameScope gameScope) {
            _gameScope = gameScope;
            _pointStorage = pointStorage;
        }

        protected override async UniTask LoadContent() {
            View.SubscribeOnMenuButtonClick(WindowData.OnMenuButtonClick);
            View.SubscribeOnRestartButtonClick(WindowData.OnRestartButtonClick);

            var score = _pointStorage.Get().ToString("F1");
            var money = _gameScope.LevelData.Money.ToString("F1");

            if (WindowData.IsWin) {
                View.ShowWindow(WIN_TEXT, score, money, WinColor);
            }
            else {
                View.ShowWindow(LOSE_TEXT, score, money, LoseColor);
            }
        }

        public EndGamePresenter(ContextService service) : base(service) { }
    }
}