﻿using Memory2.Scripts.Game.Core.Configs;
using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Core.Root.View;
using UnityEngine;

namespace Memory2.Scripts.Game.Core.Services {
    //TODO 1. Заспавнить и добавить на View врага
    //TODO 2. Метод получения урона
    //TODO 3. Окончание игры после смерти
    
    public class EnemyService {
        private readonly PrefabConfig _prefabConfig;
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly EnemyConfig _enemyConfig;

        public EnemyService(PrefabConfig prefabConfig, UIGameplayRoot uiGameplayRoot, EnemyConfig enemyConfig) {
            _prefabConfig = prefabConfig;
            _uiGameplayRoot = uiGameplayRoot;
            _enemyConfig = enemyConfig;
        }

        public void SpawnEnemy() {
            var enemyData = _enemyConfig.GetRandomEnemy();
            var enemyView = Object.Instantiate(_prefabConfig.GetEnemyPrefab());
            _uiGameplayRoot.AddEnemy(enemyView.transform);
            
            var enemyPresenter = new EnemyPresenter(enemyView, enemyData);
            enemyPresenter.InitView();
        }
    }
}