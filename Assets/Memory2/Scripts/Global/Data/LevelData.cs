using System;

namespace Memory2.Scripts.Global.Data {
    [Serializable]
    public sealed class LevelData {
        public int LevelId;
        public int Seconds;
        public string EnemyId;
        public int Money;
    }
}