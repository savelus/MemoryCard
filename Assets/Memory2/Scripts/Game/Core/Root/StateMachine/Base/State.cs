namespace Memory2.Scripts.Game.Core.Root.StateMachine.Base {
    public abstract class State {
        protected readonly StateMachine _stateMachine;

        public State(StateMachine stateMachine) {
            _stateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
    }
}