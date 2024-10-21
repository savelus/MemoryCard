using System;
using System.Collections.Generic;
using Memory2.Scripts.Core.Utils;
using Memory2.Scripts.Global.Enums;
using UnityEngine;

namespace Memory2.Scripts.Global.Configs.Elements {
    [Serializable]
    public class ElementsIconConfig {
        [SerializeField] private List<ElementsWithIcon> _elementPairs;

        private Dictionary<Element, Sprite> _elementMap;

        public Sprite GetSprite(Element type) {
            if (_elementMap.IsNullOrEmpty()) InitMap();
            if (_elementMap.TryGetValue(type, out var sprite)) return sprite;

            throw new ArgumentException($"Not found sprite for elementType {type} into ElementsIconConfig");
        }

        private void InitMap() {
            _elementMap = new();
            foreach (var elementsWithIcon in _elementPairs) {
                _elementMap[elementsWithIcon.Type] = elementsWithIcon.Sprite;
            }
        }
    }
}