using System;
using UnityEngine.Serialization;

namespace Memory2.Scripts.Game.Global.Data {
    [Serializable]
    public sealed class LevelData {
        public int LevelId;
        public int Seconds;
        public string EnemyId;
        public int Money;
    }
}