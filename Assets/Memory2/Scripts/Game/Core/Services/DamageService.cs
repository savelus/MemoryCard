using Memory2.Scripts.Game.Core.Data;
using Memory2.Scripts.Game.Core.Storages;
using Memory2.Scripts.Game.Global.Configs.Elements;
using Memory2.Scripts.Game.Global.Enums;

namespace Memory2.Scripts.Game.Core.Services {
    public sealed class DamageService {
        private readonly EnemyService _enemyService;
        private readonly PointStorage _pointStorage;
        private readonly ElementsHierarchyConfig _elementsHierarchyConfig;
        private readonly DependencyPowerConfig _dependencyPowerConfig;

        public DamageService(EnemyService enemyService,
                             PointStorage pointStorage,
                             ElementsHierarchyConfig elementsHierarchyConfig,
                             DependencyPowerConfig dependencyPowerConfig) {
            _enemyService = enemyService;
            _pointStorage = pointStorage;
            _elementsHierarchyConfig = elementsHierarchyConfig;
            _dependencyPowerConfig = dependencyPowerConfig;
        }
        
        public void DamageByCards(CardData pairedCards) {
            var damage = pairedCards.Damage * GetCoefficient(pairedCards.Type, _enemyService.CurrentEnemyType);
            _pointStorage.Add(damage);
            _enemyService.DamageEnemy(damage);
        }

        private float GetCoefficient(Element cardElement, Element enemyElement) {
            var dependencyType = _elementsHierarchyConfig.GetCoefficient(cardElement, enemyElement);
            return _dependencyPowerConfig.GetCoefficient(dependencyType);
        }
    }
}