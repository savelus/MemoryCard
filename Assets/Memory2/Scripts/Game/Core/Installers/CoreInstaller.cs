using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Root.StateMachine.States;
using Memory2.Scripts.Game.Core.Services;
using Zenject;

namespace Memory2.Scripts.Game.Core.Installers {
    public class CoreInstaller : MonoInstaller {
        public override void InstallBindings() {
            InstallGameScope();
            InstallStateMachine();
            InstallServices();
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