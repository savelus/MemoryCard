using Memory2.Scripts.Game.Core.Storages;
using Memory2.Scripts.Game.Global.Storages;
using Memory2.Scripts.Game.Global.Storages.Root;
using Zenject;

namespace Memory2.Scripts.Game.Core.Installers {
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