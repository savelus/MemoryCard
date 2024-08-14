using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Core.Configs.Installers {
    [CreateAssetMenu(fileName = "CardsConfig", menuName = "Configs/CardsConfig")]
    public class ConfigInstaller : ScriptableObjectInstaller<ConfigInstaller> {
        [SerializeField] private CardsConfig _cardsConfig;
        
        public override void InstallBindings() {
            Container
                .Bind<CardsConfig>()
                .FromInstance(_cardsConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}