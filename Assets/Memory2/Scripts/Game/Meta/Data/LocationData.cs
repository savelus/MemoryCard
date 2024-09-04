using System;
using System.Collections.Generic;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.Data {
    [Serializable]
    public class LocationData {
        public int Id;
        public string Name;
        public Sprite ButtonSprite;
        public List<int> LevelIds;
    }
}