using Memory2.Scripts.Game.Storages;
using Zenject;

namespace Memory2.Scripts.Game.Installers {
    public class StoragesInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<PointStorage>()
                .AsSingle()
                .NonLazy();
        }
    }
}