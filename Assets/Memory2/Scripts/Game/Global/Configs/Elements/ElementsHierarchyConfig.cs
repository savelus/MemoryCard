using System;
using System.Collections.Generic;
using Memory2.Scripts.Game.Global.Enums;
using Memory2.Scripts.Utils;
using UnityEngine;

namespace Memory2.Scripts.Game.Global.Configs.Elements {
    [Serializable]
    public class ElementsHierarchyConfig {
        [SerializeField] private List<ElementsDependencies> Dependencies;
        
        private Dictionary<Element, HashSet<Element>> ElementsDependencies;

        public DependencyPower GetCoefficient(Element attacker, Element defender) {
            if (ElementsDependencies.IsNullOrEmpty()) InitMap();

            if (ElementsDependencies!.TryGetValue(attacker, out var weaknessElements)) {
                if (weaknessElements.Contains(defender)) return DependencyPower.Strong;
            }
            else if (ElementsDependencies.TryGetValue(defender, out weaknessElements)) {
                if (weaknessElements.Contains(attacker)) return DependencyPower.Weakness;
            }

            return DependencyPower.Normal;
        }

        private void InitMap() {
            ElementsDependencies = new();

            foreach (var dependency in Dependencies) {
                var addedCount = ElementsDependencies.GetOrAdd(dependency.Element).AddRange(dependency.Dependencies);
                if (addedCount != dependency.Dependencies.Length) {
                    Debug.LogError($"some dependencies not uniq into {dependency.Element}");
                }
            }
        }
    }
}