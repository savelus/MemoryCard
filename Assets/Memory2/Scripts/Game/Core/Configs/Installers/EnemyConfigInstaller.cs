﻿using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Core.Configs.Installers {
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfigInstaller : ScriptableObjectInstaller<EnemyConfigInstaller> {
        [SerializeField] private EnemyConfig _enemyConfig;
        
        public override void InstallBindings() {
            Container
                .Bind<EnemyConfig>()
                .FromInstance(_enemyConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}