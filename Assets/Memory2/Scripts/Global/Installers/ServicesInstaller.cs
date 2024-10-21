using Memory2.Scripts.Global.Services;
using Zenject;

namespace Memory2.Scripts.Global.Installers {
    public class ServicesInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<CardCollectionService>()
                .AsSingle()
                .NonLazy();
        }
    }
}