using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Root.StateMachine.States;
using Memory2.Scripts.Game.Core.Services;
using Zenject;

namespace Memory2.Scripts.Game.Core.Installers {
    public class CoreInstaller : MonoInstaller {
        public override void InstallBindings() {
            InstallStateMachine();
            InstallServices();
            InstallConfigs();
        }

        private void InstallServices() {
            Container
                .Bind<CardInputService>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallConfigs() { }

        private void InstallStateMachine() {
            Container
                .Bind<StateMachine>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<InitializeCardState>()
                .AsSingle()
                .NonLazy();
        }
    }
}