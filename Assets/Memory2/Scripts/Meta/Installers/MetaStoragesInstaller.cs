using Memory2.Scripts.Global.Storages;
using Memory2.Scripts.Meta.Storages;
using Zenject;

namespace Memory2.Scripts.Meta.Installers {
    public class MetaStoragesInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<MoneyStorage>()
                .AsSingle()
                .NonLazy();
        }
    }
}