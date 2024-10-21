using System;
using Memory2.Scripts.Global.Enums;
using UnityEngine;

namespace Memory2.Scripts.Global.Configs.Cards {
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