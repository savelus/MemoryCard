using Memory2.Scripts.Global.GameRoot;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Global.Installers {
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