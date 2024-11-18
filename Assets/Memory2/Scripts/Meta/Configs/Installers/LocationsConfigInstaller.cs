using Memory2.Scripts.Global;
using Memory2.Scripts.Global.Configs;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Memory2.Scripts.Meta.Configs.Installers {
    [CreateAssetMenu(fileName = "LocationsConfig", menuName = "Configs/Locations")]
    public class LocationsConfigInstaller : ScriptableObjectInstaller<LocationsConfigInstaller> {
        public LocationsConfig LocationsConfig;

        public override void InstallBindings() {
            Container
                .Bind<LocationsConfig>()
                .FromInstance(LocationsConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}