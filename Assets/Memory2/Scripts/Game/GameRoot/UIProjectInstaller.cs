using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.GameRoot {
    public class UIProjectInstaller : MonoInstaller {
        [SerializeField] private UIRootView _uiIRootView;

        public override void InstallBindings() {
            Container
                .Bind<UIRootView>()
                .FromComponentInNewPrefab(_uiIRootView)
                .AsSingle()
                .NonLazy();
        }
    }
}
