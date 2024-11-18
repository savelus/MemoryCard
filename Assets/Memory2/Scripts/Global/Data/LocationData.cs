using System;
using System.Collections.Generic;
using UnityEngine;

namespace Memory2.Scripts.Global.Data {
    [Serializable]
    public class LocationData {
        public int Id;
        public string Name;
        public string ButtonVisualId;
        public List<int> LevelIds;
    }
}