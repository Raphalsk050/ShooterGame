
namespace Core.StateMachine
{
    public abstract class State
    {
        private State _previousState;
        private State _nextState;
        private State _currentState;

        protected State(State previousState, State nextState)
        {
            _previousState = previousState;
            _nextState = nextState;
        }

        public void OnEnteringState()
        {
            
        }
        
        public void OnStateEnter()
        {
            
        }

        public void OnExitingState()
        {
            
        }
        
        public void OnStateExit()
        {
            
        }
    }
}
