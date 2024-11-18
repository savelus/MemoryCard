using Memory2.Scripts.Global.Configs.Cards;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Global.Configs.Installers {
    [CreateAssetMenu(fileName = "CardsConfig", menuName = "Configs/CardsConfig")]
    public class CardsConfigInstaller : ScriptableObjectInstaller<CardsConfigInstaller> {
        public CardsConfig _cardsConfig;

        public override void InstallBindings() {
            Container
                .Bind<CardsConfig>()
                .FromInstance(_cardsConfig)
                .AsSingle()
                .NonLazy();
        }
    }
}