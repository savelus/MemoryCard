using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Core.Configs.Installers {
    [CreateAssetMenu(fileName = "PrefabsConfig", menuName = "Configs/PrefabsConfig")]
    public class PrefabConfigInstaller : ScriptableObjectInstaller<PrefabConfigInstaller> {
        [SerializeField] private PrefabConfig _prefabConfig;
        public override void InstallBindings() {
            Container
                .Bind<PrefabConfig>()
                .FromInstance(_prefabConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}