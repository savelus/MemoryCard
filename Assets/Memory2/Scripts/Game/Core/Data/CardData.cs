using System;
using UnityEngine;

namespace Memory2.Scripts.Game.Core.Data {
    [Serializable]
    public class CardData {
        public int Id;
        public int Damage;
        public Color Color;
        public Sprite Sprite;
    }
}