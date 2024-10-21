using System;
using Memory2.Scripts.Game.MVP.View;
using UnityEngine;

namespace Memory2.Scripts.Game.Configs {
    [Serializable]
    public class PrefabConfig {
        [SerializeField] private EnemyView _enemyView;

        public EnemyView GetEnemyPrefab() {
            return _enemyView;
        }
    }
}