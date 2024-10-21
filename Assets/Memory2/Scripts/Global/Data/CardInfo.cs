using Memory2.Scripts.Global.Configs.Cards;
using Memory2.Scripts.Global.Enums;
using UnityEngine;

namespace Memory2.Scripts.Global.Data {
    public class CardInfo {
        public int Id { get; }
        public Element Type { get; }
        public int Damage { get; }
        public Color Color { get; }
        public Sprite Sprite { get; }
        public int CardLevel { get; set; }
        public bool InDeck { get; set; }
        public string CardName { get; set; }

        public CardInfo(CardData data) {
            Id = data.Id;
            Type = data.Type;
            Damage = data.Damage;
            Color = data.Color;
            Sprite = data.Sprite;
            CardName = data.CardName;
        }
    }
}