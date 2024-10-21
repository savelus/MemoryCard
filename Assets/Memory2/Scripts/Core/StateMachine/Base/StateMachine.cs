namespace Memory2.Scripts.Core.StateMachine.Base {
    public sealed class StateMachine {
        private State _currentState;

        public void ChangeState(State state) {
            _currentState?.Exit();
            state.Enter();

            _currentState = state;
        }
    }
}