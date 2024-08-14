using Memory2.Scripts.Game.Core.Root.View;
using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Game.Core.Configs.Installers {
    [CreateAssetMenu(fileName = "PrefabsConfig", menuName = "Configs/PrefabsConfig")]
    public class PrefabConfigInstaller : ScriptableObjectInstaller<PrefabConfigInstaller>  {
        [SerializeField] private UIGameplayRoot _uiGameplayRoot;
        public override void InstallBindings() {
            Container
                .Bind<UIGameplayRoot>()
                .FromComponentInNewPrefab(_uiGameplayRoot)
                .AsSingle();
        }
    }
}