using System;
using Memory2.Scripts.Game.Core.View;
using Memory2.Scripts.Utils;
using R3;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Memory2.Scripts.Game.Core.Root.View {
    public class UIGameplayRoot : MonoBehaviour {
        [SerializeField] private Button _exitButton;
        [SerializeField] private Transform _cardRoot;
        [SerializeField] private Transform _enemyRoot;
        [SerializeField] private Transform _timerRoot;

        public void Bind(UnityAction endGame) {
            _exitButton.Subscribe(endGame);
        }
        
        public void AddCard(Transform card) {
            card.SetParent(_cardRoot, false);
        }
        
        public void AddEnemy(Transform enemy) {
            enemy.SetParent(_enemyRoot, false);
        }

        public void AddTimer(Transform timerTransform) {
            timerTransform.SetParent(_timerRoot, false);
        }
    }
}