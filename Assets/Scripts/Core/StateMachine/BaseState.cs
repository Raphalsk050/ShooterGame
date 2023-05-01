using Core.StateMachine.Player;
using UnityEngine;

namespace Core.StateMachine
{
    public abstract class BaseState
    {
        public abstract void OnEnteringState();
        public abstract void OnStateEnter();
        public abstract void OnExitingState();
        public abstract void OnStateExit();
        public abstract void UpdateState();
    }
}
