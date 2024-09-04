using Memory2.Scripts.Game.Global.Timer;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Global.GameRoot {
    [CreateAssetMenu(fileName = "ProjectScriptableInstaller", menuName = "Installers/ProjectScriptableInstaller")]
    public class ScriptableInstaller : ScriptableObjectInstaller {
        public override void InstallBindings() {
            Container
                .Bind<GameEntryPoint>()
                .AsSingle()
                .NonLazy();

            Container
                .BindInterfacesAndSelfTo<TimerFactory>()
                .AsSingle()
                .NonLazy();
        }
    }
}