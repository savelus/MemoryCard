using Memory2.Scripts.Game.Storages;
using Memory2.Scripts.Global.Storages.Root;
using Zenject;

namespace Memory2.Scripts.Game.Installers {
    public class StoragesInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<PointStorage>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<StorageController>()
                .AsSingle()
                .NonLazy();
        }
    }
}