using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Root.StateMachine.States;
using Memory2.Scripts.Game.Core.Services;
using Zenject;

namespace Memory2.Scripts.Game.Core.Installers {
    public class CoreInstaller : MonoInstaller {
        public override void InstallBindings() {
            InstallContext();
            InstallGameScope();
            InstallStateMachine();
            InstallServices();
        }

        private void InstallContext() {
            Container
                .BindInterfacesAndSelfTo<CoreContextProvider>()
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
                .Bind<StateMachine>()
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