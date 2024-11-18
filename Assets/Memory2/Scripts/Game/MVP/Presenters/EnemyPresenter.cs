using Memory2.Scripts.Game.Data;
using Memory2.Scripts.Game.MVP.View;
using Memory2.Scripts.Global.Enums;
using UnityEngine;
using UnityEngine.Events;

namespace Memory2.Scripts.Game.MVP.Presenters {
    public class EnemyPresenter {
        private readonly EnemyView _enemyView;
        private readonly EnemyData _enemyData;
        private readonly Sprite _enemyVisual;

        private float _currentHealth;

        public event UnityAction<float> HealthChanged;
        public event UnityAction EnemyDead;

        public Element GetEnemyType => _enemyData.Type;

        public EnemyPresenter(EnemyView enemyView, EnemyData enemyData, Sprite enemyVisual) {
            _enemyView = enemyView;
            _enemyData = enemyData;
            _enemyVisual = enemyVisual;
            _currentHealth = _enemyData.Health;
        }

        public void InitView(Sprite elementSprite) {
            _enemyView.InitView(_enemyData.Name, _enemyData.Health.ToString(), _enemyVisual, elementSprite);
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