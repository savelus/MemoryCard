using System;
using Memory2.Scripts.Game.Core.Configs;
using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Core.Root.View;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Memory2.Scripts.Game.Core.Services {
    //TODO 1. Заспавнить и добавить на View врага
    //TODO 2. Метод получения урона
    //TODO 3. Окончание игры после смерти
    
    public sealed class EnemyService {
        private readonly PrefabConfig _prefabConfig;
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly EnemyConfig _enemyConfig;
        
        private EnemyPresenter _activeEnemy;

        public bool IsEnemyAlive { get; private set; }
        public event UnityAction EnemyDead; 
        
        public EnemyService(PrefabConfig prefabConfig, UIGameplayRoot uiGameplayRoot, EnemyConfig enemyConfig) {
            _prefabConfig = prefabConfig;
            _uiGameplayRoot = uiGameplayRoot;
            _enemyConfig = enemyConfig;
        }

        public void SpawnEnemy() {
            var enemyData = _enemyConfig.GetRandomEnemy();
            var enemyView = Object.Instantiate(_prefabConfig.GetEnemyPrefab());
            _uiGameplayRoot.AddEnemy(enemyView.transform);
            
            _activeEnemy = new EnemyPresenter(enemyView, enemyData);
            _activeEnemy.InitView();
            _activeEnemy.EnemyDead += OnEnemyDead;
            IsEnemyAlive = true;
        }
        
        public void DamageEnemy(int damage) {
            _activeEnemy.DamageEnemy(damage);
        }

        private void OnEnemyDead() {
            IsEnemyAlive = false;
            EnemyDead?.Invoke();
        }
    }
}