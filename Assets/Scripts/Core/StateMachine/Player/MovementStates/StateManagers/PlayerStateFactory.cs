using Core.StateMachine.Player.MovementStates.States;

namespace Core.StateMachine.Player.MovementStates.StateManagers
{
    public class PlayerStateFactory : StateFactory
    {
        private IdleState _idleState;
        private IdleState _walkState;
        private IdleState _runState;
        private IdleState _crouchState;
        private IdleState _proneState;
        
        public PlayerStateFactory(PlayerStateMachine currentContext) : base(currentContext)
        {
            
        }

        public PlayerBaseState Idle()
        {
            if (_idleState == null)
            {
                return new IdleState(Context, this);
            }

            return _idleState;
        }
        
        public PlayerBaseState Walk()
        {
            if (_walkState == null)
            {
                return new WalkState(Context, this);
            }

            return _walkState;
        }

        public PlayerBaseState Run()
        {
            if (_runState == null)
            {
                return new RunState(Context, this);
            }

            return _runState;
        }

        public PlayerBaseState Crouch()
        {
            if (_crouchState == null)
            {
                return new CrouchState(Context, this);
            }

            return _crouchState;
        }

        public PlayerBaseState Prone()
        {
            if (_proneState == null)
            {
                return new ProneState(Context, this);
            }

            return _proneState;
        }
    }
}
