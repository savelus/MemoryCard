using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Meta.Data;
using Memory2.Scripts.Game.Meta.View.Shop;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.Configs {
    [Serializable]
    public sealed class ShopConfig {
        [SerializeField] private List<UnlockCardInLevel> _unlocks;
        [SerializeField] private ShopElement _shopElement;
        
        public ShopElement ShopElementPrefab => _shopElement;
        
        public IEnumerable<int> GetUnlockedCardsId(int openLocation, int openLevel) {
            List<int> unlockedCards = new();
            foreach (var unlock in _unlocks) {
                if (unlock.Location > openLocation) break;
                if (unlock.Level >= openLevel) continue;

                unlockedCards.AddRange(unlock.CardIds);
            }

            return unlockedCards;
        }
    }
}