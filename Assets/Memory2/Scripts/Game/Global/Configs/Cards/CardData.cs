using System;
using Memory2.Scripts.Game.Global.Enums;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.Configs.Cards {
    [Serializable]
    public struct CardData {
        public int Id;
        public string CardName;
        public Element Type;
        public int Damage;
        public Color Color;
        public Sprite Sprite;
        public float Cost;
    }
}