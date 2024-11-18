using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Memory2.Scripts.Global.Configs.Installers {
    [CreateAssetMenu(fileName = "LevelsConfig", menuName = "Configs/Levels")]
    public class LevelsConfigInstaller : ScriptableObjectInstaller<LevelsConfigInstaller> {
        [FormerlySerializedAs("_levelsConfig")]
        public LevelsConfig LevelsConfig;

        public override void InstallBindings() {
            Container
                .Bind<LevelsConfig>()
                .FromInstance(LevelsConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}