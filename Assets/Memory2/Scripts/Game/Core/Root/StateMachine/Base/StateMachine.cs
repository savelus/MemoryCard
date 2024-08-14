namespace Memory2.Scripts.Game.Core.Root.StateMachine.Base {
    public sealed class StateMachine {
        private State _currentState;

        public void ChangeState(State state) {
            _currentState?.Exit();
            state.Enter();
            
            _currentState = state;
        }
    }
}