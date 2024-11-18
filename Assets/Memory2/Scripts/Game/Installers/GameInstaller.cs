using Memory2.Scripts.Game.Services;
using Memory2.Scripts.Game.StateMachine.States;
using Zenject;

namespace Memory2.Scripts.Game.Installers {
    public class GameInstaller : MonoInstaller {
        public override void InstallBindings() {
            InstallContext();
            InstallGameScope();
            InstallStateMachine();
            InstallServices();
        }

        private void InstallContext() {
            Container
                .BindInterfacesAndSelfTo<GameContextProvider>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallGameScope() {
            Container
                .Bind<GameScope>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallServices() {
            Container
                .Bind<CardInputService>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EnemyService>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<DamageService>()
                .AsSingle()
                .NonLazy();
        }

        private void InstallStateMachine() {
            Container
                .Bind<StateMachine.Base.StateMachine>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<InitializeCardState>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<InitializeEnemyState>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<EndGameState>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<StartTimerState>()
                .AsSingle()
                .NonLazy();
        }
    }
}