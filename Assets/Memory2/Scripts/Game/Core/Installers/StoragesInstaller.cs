using Memory2.Scripts.Game.Core.Storages;
using Zenject;

namespace Memory2.Scripts.Game.Core.Installers {
    public class StoragesInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .Bind<PointStorage>()
                .AsSingle()
                .NonLazy();
        }
    }
}