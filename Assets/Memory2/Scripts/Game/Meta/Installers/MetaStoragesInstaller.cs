using Memory2.Scripts.Game.Meta.Storages;
using Zenject;

namespace Memory2.Scripts.Game.Meta.Installers {
    public class MetaStoragesInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<MoneyStorage>()
                .AsSingle()
                .NonLazy();
        }
    }
}