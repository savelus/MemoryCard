using System;
using Memory2.Scripts.Game.Global.MVP.Enums;
using TypeReferences;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace Memory2.Scripts.Game.Global.Configs {
    [Serializable]
    public class WindowConfig {
        public string Uid;
        public AssetReference PrefabReference;
        public WindowKey Key;
        public TypeReference Controller => _controller;
        public int Priority;
        public bool IsFullScreen;
        public bool CanClose;
        public GameContext Context;
        
        [TypeOptions(ShowAllTypes = true)]
        [SerializeField] private TypeReference _controller;
    }
}