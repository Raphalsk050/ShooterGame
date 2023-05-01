namespace Core.StateMachine
{
    public interface IState
    {
        void OnEnteringState();

        void OnStateEnter();

        void OnExitingState();

        void OnStateExit();
    }
}
