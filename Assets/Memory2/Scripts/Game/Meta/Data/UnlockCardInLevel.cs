using System;
using System.Collections.Generic;

namespace Memory2.Scripts.Game.Meta.Data {
    [Serializable]
    public sealed class UnlockCardInLevel {
        public int Location;
        public int Level;
        public List<int> CardIds;
    }
}