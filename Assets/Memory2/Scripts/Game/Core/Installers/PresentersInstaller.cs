using Memory2.Scripts.Game.Core.Presenters;
using Memory2.Scripts.Game.Core.Storages;
using Zenject;

namespace Memory2.Scripts.Game.Core.Installers {
    public class PresentersInstaller : MonoInstaller {
        public override void InstallBindings() {
            InstallPointStorage();
                
            Container
                .BindInterfacesAndSelfTo<PointsPresenter>()
                .AsSingle()
                .NonLazy();
        }
        
        private void InstallPointStorage() {
            Container
                .Bind<PointStorage>()
                .AsSingle()
                .NonLazy();
        }
    }
}