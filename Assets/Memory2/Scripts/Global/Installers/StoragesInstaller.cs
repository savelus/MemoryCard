using Memory2.Scripts.Global.Storages;
using Memory2.Scripts.Global.Storages.Root;
using Zenject;

namespace Memory2.Scripts.Global.Installers {
    public class StoragesInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<CardCollectionStorage>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ProgressStorage>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<StorageController>()
                .AsSingle()
                .NonLazy();
        }
    }
}