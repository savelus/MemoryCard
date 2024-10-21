using Memory2.Scripts.Core.AssetManager;
using Memory2.Scripts.Core.Signals;
using Memory2.Scripts.Global.GameRoot;
using Memory2.Scripts.Global.MVP.Context;
using Memory2.Scripts.Global.MVP.WindowService;
using Memory2.Scripts.Global.Timer;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Global.Installers {
    [CreateAssetMenu(fileName = "ProjectScriptableInstaller", menuName = "Installers/ProjectScriptableInstaller")]
    public class ScriptableInstaller : ScriptableObjectInstaller {
        public override void InstallBindings() {
            SignalBusInstaller.Install(Container);

            Container
                .Bind<GameEntryPoint>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<TimerFactory>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<AddressableAssetService>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<ContextService>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<ProjectContextProvider>()
                .AsSingle();

            Container
                .BindInterfacesAndSelfTo<WindowService>()
                .AsSingle()
                .NonLazy();

            Container
                .Bind<WindowFactory>()
                .AsSingle()
                .NonLazy();

            InstallSignals();
        }

        private void InstallSignals() {
            Container
                .DeclareSignal<PreloadWindowSignal>();

            Container
                .DeclareSignal<OpenWindowSignal>();

            Container
                .DeclareSignal<CloseWindowSignal>();
        }
    }
}