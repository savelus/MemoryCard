using Memory2.Scripts.Game.Meta.View;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Installers {
    [CreateAssetMenu(fileName = "MetaViewsConfig", menuName = "Configs/MetaViews")]
    public class MetaViewsInstaller : ScriptableObjectInstaller {
        [SerializeField] private LocationMapView _locationMapView;
        [SerializeField] private LocationView _locationView;

        public override void InstallBindings() {
            Container
                .Bind<LocationMapView>()
                .FromComponentInNewPrefab(_locationMapView)
                .AsSingle();
            
            Container
                .Bind<LocationView>()
                .FromComponentInNewPrefab(_locationView)
                .AsSingle();
        }
    }
}