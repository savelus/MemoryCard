using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Meta.Presenters;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Installers {
    public class PresentersInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<LocationMapPresenter>()
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<LocationPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}