using System;
using System.Collections.Generic;
using Memory2.Scripts.Core.Utils;
using Memory2.Scripts.Global.Enums;
using UnityEngine;

namespace Memory2.Scripts.Global.Configs.Elements {
    [Serializable]
    public class DependencyPowerConfig {
        [SerializeField] private List<DependencyPowerWithCoef> _dependencyPowers;

        private Dictionary<DependencyPower, float> _dependencyPowerMap;

        public float GetCoefficient(DependencyPower power) {
            if (_dependencyPowerMap.IsNullOrEmpty()) {
                InitMap();
            }

            return _dependencyPowerMap![power];
        }

        private void InitMap() {
            _dependencyPowerMap = new();
            foreach (var dependencyPowerWithCoef in _dependencyPowers) {
                _dependencyPowerMap[dependencyPowerWithCoef.Power] = dependencyPowerWithCoef.Coef;
            }
        }
    }
}