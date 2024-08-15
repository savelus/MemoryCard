using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.View;
using R3;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.Core.Presenters {
    public class EnemyPresenter {
        private readonly EnemyView _enemyView;
        private readonly EnemyData _enemyData;

        private int _currentHealth;

        public event UnityAction<int> HealthChanged;
        public event UnityAction EnemyDead;
        
        public EnemyPresenter(EnemyView enemyView, EnemyData enemyData) {
            _enemyView = enemyView;
            _enemyData = enemyData;
            _currentHealth = _enemyData.Health;
        }
        
        public void InitView() {
            _enemyView.InitView(_enemyData.Name, _enemyData.Health.ToString(), _enemyData.Sprite);
            HealthChanged += value => _enemyView.SetHealth(value.ToString());
        }

        public void DamageEnemy(int damage) {
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