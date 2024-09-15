using System;
using Memory2.Scripts.Game.Global.Enums;
using UnityEngine;

namespace Memory2.Scripts.Game.Core.Data {
    [Serializable]
    public class EnemyData {
        public string Name;
        public Element Type;
        public int Health;
        public Sprite Sprite;
    }
}