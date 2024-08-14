using Memory2.Scripts.Game.Core.View;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Core.Installers {
    [CreateAssetMenu(fileName = "CoreViewsConfig", menuName = "Configs/CoreViews")]
    public class CoreViewsInstaller : ScriptableObjectInstaller {
        [SerializeField] private PointsView _pointsView;
        public override void InstallBindings() {
            Container
                .Bind<PointsView>()
                .FromComponentInNewPrefab(_pointsView)
                .AsSingle();
        }
    }
}