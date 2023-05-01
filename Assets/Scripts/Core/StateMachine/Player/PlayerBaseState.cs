namespace Core.StateMachine.Player
{
    public class PlayerBaseState : BaseState
    {
        protected PlayerStateMachine Context;
        protected PlayerStateFactory Factory;
        
        public PlayerBaseState(PlayerStateMachine context, PlayerStateFactory factory)
        {
            Context = context;
            Factory = factory;
        }
        
        public override void OnEnteringState()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStateEnter()
        {
            throw new System.NotImplementedException();
        }

        public override void OnExitingState()
        {
            throw new System.NotImplementedException();
        }

        public override void OnStateExit()
        {
            throw new System.NotImplementedException();
        }

        public override void UpdateState()
        {
            
        }

        protected void SwitchState(PlayerBaseState newState)
        {
            //finishes this state
            OnExitingState();
            
            
            
            
            //Initializes the given state
            newState.OnEnteringState();
            
            //Change the current state inside the State machine
            Context.CurrentState = newState;
        }

        protected virtual void CheckSwitchStates()
        {
            
        }
    }
}
