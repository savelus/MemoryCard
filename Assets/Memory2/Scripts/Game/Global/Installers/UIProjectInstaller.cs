using Memory2.Scripts.Game.Global.GameRoot;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Global.Installers {
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
