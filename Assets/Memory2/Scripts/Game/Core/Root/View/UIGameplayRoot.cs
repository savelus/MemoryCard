using Memory2.Scripts.Game.Extensions;
using R3;
using UnityEngine;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Core.Root.View {
    public class UIGameplayRoot : MonoBehaviour {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Transform _cardRoot;
        [SerializeField] private Transform _enemyRoot;
        [SerializeField] private EndGameView _endGameView;
        
        private Subject<Unit> _exitSceneSignalSubject;

        public void Bind(Subject<Unit> exitSceneSignalSubject) {
            _exitSceneSignalSubject = exitSceneSignalSubject;
            _exitButton.Subscribe(() => _exitSceneSignalSubject?.OnNext(Unit.Default));
            _endGameView.Init(() => _exitSceneSignalSubject?.OnNext(Unit.Default));
        }
        
        public void AddCard(Transform card) {
            card.SetParent(_cardRoot, false);
        }
        
        public void AddEnemy(Transform enemy) {
            enemy.SetParent(_enemyRoot, false);
        }
        
        public void ShowEndGamePopUp(int score) {
            _endGameView.Show(score.ToString());
        }
    }
}