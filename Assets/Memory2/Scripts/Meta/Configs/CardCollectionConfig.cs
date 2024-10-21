using System;
using Memory2.Scripts.Meta.MVP.View.CardCollection;
using UnityEngine;

namespace Memory2.Scripts.Meta.Configs {
    [Serializable]
    public class CardCollectionConfig {
        [SerializeField] private CardCollectionElement _cardCollectionElementPrefab;

        public CardCollectionElement CardCollectionElementPrefab => _cardCollectionElementPrefab;
    }
}