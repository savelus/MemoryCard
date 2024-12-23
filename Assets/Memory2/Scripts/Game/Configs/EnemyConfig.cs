﻿using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Data;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Configs {
    [Serializable]
    public class EnemyConfig : IInitializable {
        private Dictionary<string, EnemyData> _enemies;
        public List<EnemyData> Enemies;

        void IInitializable.Initialize() {
            _enemies = new();
            foreach (var enemyData in Enemies) {
                _enemies.Add(enemyData.Name, enemyData);
            }
        }

        public EnemyData GetRandomEnemy() {
            var index = UnityEngine.Random.Range(0, Enemies.Count);
            return Enemies[index];
        }

        public EnemyData GetEnemyById(string enemyId) {
            if (_enemies.TryGetValue(enemyId, out var enemyData)) {
                return enemyData;
            }

            Debug.LogError($"Enemy with id {enemyId} not found.");

            if (_enemies is { Count: > 0 }) {
                return GetRandomEnemy();
            }

            throw new Exception("No enemies loaded.");
        }
    }
}