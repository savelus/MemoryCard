using Memory2.Scripts.Global.Storages;
using Zenject;

namespace Memory2.Scripts.Global.Installers {
    public class StoragesInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<ProgressStorage>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<CardCollectionStorage>()
                .AsSingle()
                .NonLazy();
        }
    }
}