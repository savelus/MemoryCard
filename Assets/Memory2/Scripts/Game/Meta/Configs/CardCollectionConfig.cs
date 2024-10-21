using System;
using Memory2.Scripts.Game.Meta.View.CardCollection;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.Configs {
    [Serializable]
    public class CardCollectionConfig {
        [SerializeField] private CardCollectionElement _cardCollectionElementPrefab;

        public CardCollectionElement CardCollectionElementPrefab => _cardCollectionElementPrefab;
    }
}