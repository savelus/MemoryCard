using Memory2.Scripts.Game.MVP.View;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Installers {
    [CreateAssetMenu(fileName = "CoreViewsConfig", menuName = "Configs/CoreViews")]
    public class GameViewsInstaller : ScriptableObjectInstaller {
        [SerializeField] private UIGameplayRoot _uiGameplayRoot;
        [SerializeField] private PointsView _pointsView;
        [SerializeField] private GameTimerView _timerView;

        public override void InstallBindings() {
            Container
                .Bind<UIGameplayRoot>()
                .FromComponentInNewPrefab(_uiGameplayRoot)
                .AsSingle();

            Container
                .Bind<GameTimerView>()
                .FromComponentInNewPrefab(_timerView)
                .AsSingle();
        }
    }
}