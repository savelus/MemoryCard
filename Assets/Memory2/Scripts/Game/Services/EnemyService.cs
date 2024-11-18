using Memory2.Scripts.Game.Configs;
using Memory2.Scripts.Game.MVP.Presenters;
using Memory2.Scripts.Game.MVP.View;
using Memory2.Scripts.Global.Configs.Elements;
using Memory2.Scripts.Global.Enums;
using UnityEngine.Events;
using Object = UnityEngine.Object;

namespace Memory2.Scripts.Game.Services {
    public sealed class EnemyService {
        private readonly PrefabConfig _prefabConfig;
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly EnemyConfig _enemyConfig;
        private readonly EnemyVisualConfig _enemyVisualConfig;
        private readonly ElementsIconConfig _elementsIconConfig;
        private readonly GameScope _gameScope;

        private EnemyPresenter _activeEnemy;

        public bool IsEnemyAlive { get; private set; }
        public event UnityAction EnemyDead;

        public Element CurrentEnemyType => _activeEnemy.GetEnemyType;

        public EnemyService(PrefabConfig prefabConfig,
                            UIGameplayRoot uiGameplayRoot,
                            EnemyConfig enemyConfig,
                            EnemyVisualConfig enemyVisualConfig,
                            ElementsIconConfig elementsIconConfig) {
            _prefabConfig = prefabConfig;
            _uiGameplayRoot = uiGameplayRoot;
            _enemyConfig = enemyConfig;
            _enemyVisualConfig = enemyVisualConfig;
            _elementsIconConfig = elementsIconConfig;
        }

        public void SpawnEnemy(string enemyId) {
            var enemyData = _enemyConfig.GetEnemyById(enemyId);
            var enemySprite = _enemyVisualConfig.GetEnemyVisual(enemyData.SpriteId);
            var enemyView = Object.Instantiate(_prefabConfig.GetEnemyPrefab());
            _uiGameplayRoot.AddEnemy(enemyView.transform);

            var elementSprite = _elementsIconConfig.GetSprite(enemyData.Type);
            _activeEnemy = new EnemyPresenter(enemyView, enemyData, enemySprite);
            _activeEnemy.InitView(elementSprite);
            _activeEnemy.EnemyDead += OnEnemyDead;
            IsEnemyAlive = true;
        }

        public void DamageEnemy(float damage) {
            _activeEnemy.DamageEnemy(damage);
        }

        private void OnEnemyDead() {
            IsEnemyAlive = false;
            EnemyDead?.Invoke();
        }
    }
}