using Core.StateMachine.Player;
using Core.StateMachine.Player.MovementStates.StateManagers;

namespace Core.StateMachine
{
    public class StateFactory
    {
        protected PlayerStateMachine Context;

        public StateFactory(PlayerStateMachine currentContext)
        {
            Context = currentContext;
        }
    }
}
