using Memory2.Scripts.Game.Meta.Presenters.CardCollection;
using Memory2.Scripts.Game.Meta.Presenters.LocationMap;
using Memory2.Scripts.Game.Meta.Presenters.Shop;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Installers {
    public class PresentersInstaller : MonoInstaller {
        public override void InstallBindings() {
            // Container
            //     .BindInterfacesAndSelfTo<LocationMapPresenter>()
            //     .AsSingle()
            //     .NonLazy();
            //
            // Container
            //     .BindInterfacesAndSelfTo<LocationPresenter>()
            //     .AsSingle()
            //     .NonLazy();
            //
            // Container
            //     .BindInterfacesAndSelfTo<CardCollectionPresenter>()
            //     .AsSingle()
            //     .NonLazy();
            //
            // Container
            //     .BindInterfacesAndSelfTo<ShopPresenter>()
            //     .AsSingle()
            //     .NonLazy();
        }
    }
}