using System;
using System.Collections.Generic;
using System.Linq;
using Memory2.Scripts.Core.MVP;
using Memory2.Scripts.Global.MVP.Enums;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Global.Configs {
    [Serializable]
    public class WindowsConfigs : IInitializable {
        [SerializeField] private List<WindowConfig> _windowsConfig;

        public Dictionary<WindowKey, WindowConfig> WindowsConfig;

        public void Initialize() {
            WindowsConfig = _windowsConfig.ToDictionary(m => m.Key, m => m);

            foreach (var window in _windowsConfig) {
                if (String.IsNullOrEmpty(window.Uid)) {
                    window.Uid = Guid.NewGuid().ToString();
                }
            }
        }
    }
}