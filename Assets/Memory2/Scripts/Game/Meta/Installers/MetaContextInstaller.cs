using Zenject;

namespace Memory2.Scripts.Game.Meta.Installers {
    public class MetaContextInstaller : MonoInstaller{
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<MetaContextProvider>()
                .AsSingle();
        }
    }
}