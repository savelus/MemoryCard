using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Configs.Installers {
    [CreateAssetMenu(fileName = "EnemyConfig", menuName = "Configs/EnemyConfig")]
    public class EnemyConfigInstaller : ScriptableObjectInstaller<EnemyConfigInstaller> {
        public EnemyConfig EnemyConfig;
        [SerializeField] private EnemyVisualConfig _enemyVisualConfig;

        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<EnemyConfig>()
                .FromInstance(EnemyConfig)
                .AsSingle()
                .NonLazy();
            
            Container
                .BindInterfacesAndSelfTo<EnemyVisualConfig>()
                .FromInstance(_enemyVisualConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}