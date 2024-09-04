using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Global.Data;

namespace Memory2.Scripts.Game.Global.Configs {
    [Serializable]
    public sealed class LevelsConfig {
        public List<LevelData> Levels;

        private Dictionary<int, LevelData> _levelsMap;
        public LevelData GetRandomLevel() {
            return Levels[UnityEngine.Random.Range(0, Levels.Count)];
        }

        public LevelData GetLevelById(int levelId) {
            if (_levelsMap == null || _levelsMap.Count == 0) {
                FillLevelsMap();
            }

            return _levelsMap[levelId];
        }

        private void FillLevelsMap() {
            _levelsMap = new Dictionary<int, LevelData>();
            for (var i = 0; i < Levels.Count; i++) {
                _levelsMap.Add(Levels[i].LevelId, Levels[i]);
            }
        }
    }
}