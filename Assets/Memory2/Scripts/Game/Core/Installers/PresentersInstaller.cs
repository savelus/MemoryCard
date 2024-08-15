using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Core.Storages;
using Zenject;

namespace Memory2.Scripts.Game.Core.Installers {
    public class PresentersInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<PointsPresenter>()
                .AsSingle()
                .NonLazy();
        }
        
    }
}