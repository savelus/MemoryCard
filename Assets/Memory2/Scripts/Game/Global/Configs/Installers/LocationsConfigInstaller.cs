using Memory2.Scripts.Game.Meta.Configs;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Global.Configs.Installers {
    [CreateAssetMenu(fileName = "LocationsConfig", menuName = "Configs/Locations")]
    public class LocationsConfigInstaller : ScriptableObjectInstaller<LocationsConfigInstaller> {
        [SerializeField] private LocationsConfig _locationsConfig;

        public override void InstallBindings() {
            Container
                .Bind<LocationsConfig>()
                .FromInstance(_locationsConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}