using Core.StateMachine.Player;
using Core.StateMachine.Player.MovementStates.StateManagers;
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
        protected abstract void SwitchState(PlayerBaseState newState);
        protected abstract void CheckSwitchStates();
    }
}
