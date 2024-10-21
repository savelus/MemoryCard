using Zenject;

namespace Memory2.Scripts.Meta.Installers {
    public class MetaContextInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<MetaContextProvider>()
                .AsSingle();
        }
    }
}