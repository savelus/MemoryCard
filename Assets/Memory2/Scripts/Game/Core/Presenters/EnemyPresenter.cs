using Memory2.Scripts.Game.Core.Configs;
using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.View;
using Memory2.Scripts.Game.Global.Data;
using Memory2.Scripts.Game.Global.Enums;
using R3;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Core.Presenters {
    public class EnemyPresenter {
        private readonly EnemyView _enemyView;
        private readonly EnemyData _enemyData;

        private float _currentHealth;

        public event UnityAction<float> HealthChanged;
        public event UnityAction EnemyDead;

        public Element GetEnemyType => _enemyData.Type;

        public EnemyPresenter(EnemyView enemyView, EnemyData enemyData) {
            _enemyView = enemyView;
            _enemyData = enemyData;
            _currentHealth = _enemyData.Health;
        }

        public void InitView(Sprite elementSprite) {
            _enemyView.InitView(_enemyData.Name, _enemyData.Health.ToString(), _enemyData.Sprite, elementSprite);
            HealthChanged += value => _enemyView.SetHealth(value.ToString("F1"));
        }

        public void DamageEnemy(float damage) {
            if (_currentHealth <= damage) {
                _currentHealth = 0;
                HealthChanged?.Invoke(_currentHealth);
                Dead();
                return;
            }

            _currentHealth -= damage;
            HealthChanged?.Invoke(_currentHealth);
        }

        private void Dead() {
            Debug.Log("Dead");
            HealthChanged = null;
            EnemyDead?.Invoke();
        }
    }
}