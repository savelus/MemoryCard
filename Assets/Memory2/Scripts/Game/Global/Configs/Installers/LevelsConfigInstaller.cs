using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Global.Configs.Installers {
    [CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/Levels")]
    public class LevelsConfigInstaller : ScriptableObjectInstaller<LevelsConfigInstaller> {
        public LevelsConfig _levelsConfig;
        
        public override void InstallBindings() {
            Container
                .Bind<LevelsConfig>()
                .FromInstance(_levelsConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}