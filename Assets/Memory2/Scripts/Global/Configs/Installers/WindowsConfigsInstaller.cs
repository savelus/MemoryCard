using UnityEngine;
using Zenject;

namespace Memory2.Scripts.Global.Configs.Installers {
    [CreateAssetMenu(fileName = "Windows Config", menuName = "Configs/Windows Config")]
    public class WindowsConfigsInstaller : ScriptableObjectInstaller<WindowsConfigsInstaller> {
        public WindowsConfigs WindowsConfig;

        public override void InstallBindings() {
            Container
                .BindInterfacesAndSelfTo<WindowsConfigs>()
                .FromInstance(WindowsConfig)
                .AsSingle();
        }
    }
}