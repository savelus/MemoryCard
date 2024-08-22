using Memory2.Scripts.Game.Core.Root.StateMachine.Base;
using Memory2.Scripts.Game.Core.Root.View;
using Memory2.Scripts.Game.Core.Storages;

namespace Memory2.Scripts.Game.Core.Root.StateMachine.States {
    public class EndGameState : State {
        private readonly UIGameplayRoot _uiGameplayRoot;
        private readonly PointStorage _pointStorage;

        public EndGameState(Base.StateMachine stateMachine, UIGameplayRoot uiGameplayRoot, PointStorage pointStorage) : base(stateMachine) {
            _uiGameplayRoot = uiGameplayRoot;
            _pointStorage = pointStorage;
        }

        public override void Enter() {
            _uiGameplayRoot.ShowEndGamePopUp(_pointStorage.GetPoints());
        }
    }
}