﻿using Memory2.Scripts.Core;
using Memory2.Scripts.Global.Data;

namespace Memory2.Scripts.Global.GameRoot {
    public class GameplayEnterParams : SceneEnterParams {
        public LevelData LevelData { get; private set; }
        public int Location { get; private set; }
        public int Level { get; private set; }

        public GameplayEnterParams(LevelData levelData, int location, int level) : base(Scenes.GAMEPLAY) {
            LevelData = levelData;
            Location = location;
            Level = level;
        }
    }
}