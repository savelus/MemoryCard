﻿using Memory2.Scripts.Game.GameRoot;

namespace Memory2.Scripts.Game.Meta.Root {
    public class MainMenuExitParams {
        public SceneEnterParams TargetSceneEnterParams { get; }
        
        public MainMenuExitParams(SceneEnterParams targetSceneEnterParams) {
            TargetSceneEnterParams = targetSceneEnterParams;
        }
    }
}