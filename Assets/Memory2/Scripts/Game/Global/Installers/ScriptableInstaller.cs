using Memory2.Scripts.Game.Global.GameRoot;
using Memory2.Scripts.Game.Global.MVP.AssetManager;
using Memory2.Scripts.Game.Global.MVP.Context;
using Memory2.Scripts.Game.Global.MVP.Signals;
using Memory2.Scripts.Game.Global.MVP.WindowService;
using Memory2.Scripts.Game.Global.Timer;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Global.Installers {
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