using Memory2.Scripts.Game.Global.Storages;
using Zenject;

namespace Memory2.Scripts.Game.Global.Configs.Installers {
    public class StoragesInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<ProgressStorage>()
                .AsSingle()
                .NonLazy();

        }
    }
}