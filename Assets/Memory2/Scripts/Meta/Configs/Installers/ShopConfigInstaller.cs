using Memory2.Scripts.Meta.MVP.View.Shop;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Memory2.Scripts.Meta.Configs.Installers {
    [CreateAssetMenu(fileName = "ShopConfig", menuName = "Configs/ShopConfig")]
    public class ShopConfigInstaller : ScriptableObjectInstaller<ShopConfigInstaller> {
        public ShopConfig ShopConfig;

        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<ShopConfig>()
                .FromInstance(ShopConfig)
                .AsSingle();
        }
    }
}