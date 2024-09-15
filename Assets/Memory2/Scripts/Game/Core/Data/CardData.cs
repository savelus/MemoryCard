﻿using System;
using Memory2.Scripts.Game.Global.Enums;
using UnityEngine;

namespace Memory2.Scripts.Game.Core.Data {
    [Serializable]
    public class CardData {
        public int Id;
        public Element Type;
        public int Damage;
        public Color Color;
        public Sprite Sprite;
    }
}