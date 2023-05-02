using Core.StateMachine.Player.MovementStates.StateManagers;
using UnityEngine;

namespace Core.StateMachine.Player.MovementStates.States
{
    public class IdleState : PlayerBaseState
    {
        public IdleState(PlayerStateMachine context, PlayerStateFactory factory) : base(context, factory)
        {
        }

        public override void OnEnteringState()
        {
            Debug.Log("Entered in idle state");
            OnStateEnter();
        }

        public override void OnStateEnter()
        {
            Context.SetPlayerSpeed(1f);
        }

        public override void OnExitingState()
        {
        }

        public override void OnStateExit()
        {
            
        }

        public override void UpdateState()
        {
            CheckSwitchStates();
        }
        
        protected override void CheckSwitchStates()
        {
            if (Mathf.Abs(Context.GetPlayerVelocity()) > 0.5f)
            {
                SwitchState(((PlayerStateFactory)Factory).Walk());
            }
        }
    }
}
