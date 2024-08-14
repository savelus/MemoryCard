using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.View;
using UnityEngine;

namespace Memory2.Scripts.Game.Core.Configs {
    [Serializable]
    public class CardsConfig {
        public int CardCount;
        public Color CardBackSideColor;
        public CardView CardPrefab;
        public List<CardData> Cards = new();
    }
}