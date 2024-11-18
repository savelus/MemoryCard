using Memory2.Scripts.Global.Configs.Elements;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Memory2.Scripts.Global.Configs.Installers {
    [CreateAssetMenu(fileName = "ElementsConfig", menuName = "Configs/Elements")]
    public class ElementsConfigInstaller : ScriptableObjectInstaller<ElementsConfigInstaller> {
        public ElementsHierarchyConfig ElementsHierarchyConfig;
        [SerializeField] private DependencyPowerConfig _dependencyPowerConfig;
        [SerializeField] private ElementsIconConfig _elementsIconConfig;

        public override void InstallBindings() {
            Container
                .Bind<ElementsHierarchyConfig>()
                .FromInstance(ElementsHierarchyConfig)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<DependencyPowerConfig>()
                .FromInstance(_dependencyPowerConfig)
                .AsSingle()
                .NonLazy();

            Container
                .Bind<ElementsIconConfig>()
                .FromInstance(_elementsIconConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}