using System;
using System.Collections.Generic;
using Memory2.Scripts.Core.Utils;
using Memory2.Scripts.Global.Data;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Configs {
    [Serializable]
    public class EnemyVisualConfig : IInitializable{
        private Dictionary<string, Sprite> _enemyVisualsMap;
        [SerializeField] private List<SpriteWithId> _enemyVisuals;
        public void Initialize() {
            _enemyVisualsMap = new();
            foreach (var spriteWithId in _enemyVisuals) {
                _enemyVisualsMap.Add(spriteWithId.Id, spriteWithId.Sprite);
            }
        }

        public Sprite GetEnemyVisual(string enemyId) {
            return _enemyVisualsMap[enemyId];
        }
    }
}