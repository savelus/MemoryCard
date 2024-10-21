using System;
using Memory2.Scripts.Global.Enums;
using UnityEngine;

namespace Memory2.Scripts.Game.Data {
    [Serializable]
    public class EnemyData {
        public string Name;
        public Element Type;
        public int Health;
        public Sprite Sprite;
    }
}