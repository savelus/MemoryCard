using Memory2.Scripts.Game.MVP.Presenters;
using Zenject;

namespace Memory2.Scripts.Game.Installers {
    public class PresentersInstaller : MonoInstaller {
        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<TimerPresenter>()
                .AsSingle()
                .NonLazy();
        }
    }
}