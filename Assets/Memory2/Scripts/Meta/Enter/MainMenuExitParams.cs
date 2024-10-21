using Memory2.Scripts.Core;

namespace Memory2.Scripts.Meta.Enter {
    public class MainMenuExitParams {
        public SceneEnterParams TargetSceneEnterParams { get; }

        public MainMenuExitParams(SceneEnterParams targetSceneEnterParams) {
            TargetSceneEnterParams = targetSceneEnterParams;
        }
    }
}