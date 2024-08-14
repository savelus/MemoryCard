using R3;
using UnityEngine;

namespace Memory2.Scripts.Game.Meta.Root.View {
    public class UIMainMenuRootBinder : MonoBehaviour {
        private Subject<Unit> _exitSceneSignalSubject;

        public void HandleGoToGameplayButtonClick() {
            _exitSceneSignalSubject?.OnNext(Unit.Default);
        }

        public void Bind(Subject<Unit> exitSceneSignalSubject) {
            _exitSceneSignalSubject = exitSceneSignalSubject;
        }
    }
}