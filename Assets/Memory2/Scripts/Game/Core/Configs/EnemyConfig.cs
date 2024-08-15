using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Core.Data;

namespace Memory2.Scripts.Game.Core.Configs {
    [Serializable]
    public class EnemyConfig {
        public List<EnemyData> Enemies = new();
        
        public EnemyData GetRandomEnemy() {
            var index =  UnityEngine.Random.Range(0, Enemies.Count);
            return Enemies[index];
        }
    }
}