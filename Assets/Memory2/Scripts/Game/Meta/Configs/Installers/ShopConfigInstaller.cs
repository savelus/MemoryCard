﻿using Memory2.Scripts.Game.Meta.View.Shop;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Configs.Installers {
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Configs/ShopConfig")]
    public class ShopConfigInstaller : ScriptableObjectInstaller<ShopConfigInstaller> {
        [SerializeField] private ShopWindow _shopWindow;
        [SerializeField] private ShopConfig _shopConfig;
        
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<ShopConfig>()
                .FromInstance(_shopConfig)
                .AsSingle();
        }
    }
}