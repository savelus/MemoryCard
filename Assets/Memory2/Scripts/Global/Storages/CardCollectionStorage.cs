﻿using System;
using System.Collections.Generic;
using Memory2.Scripts.Core.Storages;
using Memory2.Scripts.Global.Data;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Global.Storages {
    public sealed class CardCollectionStorage : ISave, IInitializable {
        private const string Key = "CardCollection";

        private UnlockedCards _unlockedCards = new();
        public string GetKey() => Key;

        public List<CardStorageData> GetCards() => _unlockedCards.Cards;

        public void Initialize() {
            if (!PlayerPrefs.HasKey(Key)) return;

            var json = PlayerPrefs.GetString(Key);
            _unlockedCards = JsonUtility.FromJson<UnlockedCards>(json);
        }

        public void Save() {
            var json = JsonUtility.ToJson(_unlockedCards);
            PlayerPrefs.SetString(Key, json);
        }

        public void UpdateUnlockedCards(List<CardStorageData> cards) {
            _unlockedCards.Cards = cards;
        }
    }

    [Serializable]
    public class UnlockedCards {
        public List<CardStorageData> Cards = new();
    }
}