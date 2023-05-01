using Core.StateMachine.Player.MovementStates;

namespace Core.StateMachine.Player
{
    public class PlayerStateFactory : StateFactory
    {
        public PlayerStateFactory(PlayerStateMachine currentContext) : base(currentContext)
        {
            
        }

        public PlayerBaseState Idle()
        {
            return new IdleState(Context, this);
        }
        
        public PlayerBaseState Walk()
        {
            return new WalkState(Context, this);
        }

        public PlayerBaseState Run()
        {
            return new RunState(Context, this);
        }

        public PlayerBaseState Crouch()
        {
            return new CrouchState(Context, this);
        }

        public PlayerBaseState Prone()
        {
            return new ProneState(Context, this);
        }
    }
}
