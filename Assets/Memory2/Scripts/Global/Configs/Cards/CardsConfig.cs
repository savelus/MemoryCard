using System;
using System.Collections.Generic;
using System.Linq;
using Memory2.Scripts.Core.Utils;
using Memory2.Scripts.Global.MVP.Views;
using UnityEngine;
using UnityEngine.Serialization;

namespace Memory2.Scripts.Global.Configs.Cards {
    [Serializable]
    public class CardsConfig {
        public int CardCount;
        public Color CardBackSideColor;
        public CardView CardPrefab;

        public List<CardData> Cards = new();
        [SerializeField] private List<int> _startCards = new();

        private Dictionary<int, CardData> _cardsMap;

        // public List<CardInfo> GetCards() {
        //     return _cards.Select(cardData => new CardInfo(cardData)).ToList();
        // }

        public List<int> GetStartCards() {
            return _startCards;
        }

        public IEnumerable<CardData> GetAllCards() {
            return Cards;
        }

        public CardData GetCardDataById(int id) {
            if (_cardsMap.IsNullOrEmpty()) InitCardsMap();
            if (_cardsMap.TryGetValue(id, out var value)) return value;

            throw new NullReferenceException($"Not found card with ID: {id} into cardsConfig");
        }

        private void InitCardsMap() {
            _cardsMap = Cards.ToDictionary(x => x.Id);
        }
    }
}