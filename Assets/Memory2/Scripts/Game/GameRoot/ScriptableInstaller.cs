using Memory2.Scripts.Game.Timer;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.GameRoot {
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