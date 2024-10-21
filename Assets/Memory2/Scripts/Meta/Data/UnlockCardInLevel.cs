using System;
using System.Collections.Generic;

namespace Memory2.Scripts.Meta.Data {
    [Serializable]
    public sealed class UnlockCardInLevel {
        public int Location;
        public int Level;
        public List<int> CardIds;
    }
}