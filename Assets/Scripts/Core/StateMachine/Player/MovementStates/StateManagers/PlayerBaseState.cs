namespace Core.StateMachine.Player.MovementStates.StateManagers
{
    public class PlayerBaseState : BaseState
    {
        protected PlayerStateMachine Context;
        protected StateFactory Factory;
        
        public PlayerBaseState(PlayerStateMachine context, StateFactory factory)
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

        protected override void SwitchState(PlayerBaseState newState)
        {
            //finishes this state
            OnExitingState();
            
            //Initializes the given state
            newState.OnEnteringState();
            
            //Change the current state inside the State machine
            Context.CurrentState = newState;
        }

        protected override void CheckSwitchStates()
        {
            
        }
    }
}
