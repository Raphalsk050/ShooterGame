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
