using System.Collections;
using UnityEngine;

namespace Core.StateMachine.Player.MovementStates
{
    public class WalkState : PlayerBaseState
    {
        public WalkState(PlayerStateMachine context, PlayerStateFactory factory) : base(context, factory)
        {
            
        }
        
        public override void OnEnteringState()
        {
            Debug.Log("Entering on walk state");
            OnStateEnter();
        }

        public override void OnStateEnter()
        {
        }

        public override void OnExitingState()
        {
            
        }

        public override void OnStateExit()
        {
        }

        public override void UpdateState()
        {
            float lastSpeed = Context.PlayerController.velocity.magnitude;
            float newSpeed = Mathf.Lerp(lastSpeed, 1.6f, Time.deltaTime * 3f);
            Context.SetPlayerSpeed(newSpeed);
            CheckSwitchStates();
        }

        protected override void CheckSwitchStates()
        {
            if (Mathf.Abs(Context.GetPlayerVelocity()) < 0.5f)
            {
                SwitchState(Factory.Idle());
            }

            else if (Input.GetKey(KeyCode.LeftShift))
            {
                SwitchState(Factory.Run());
            }
        }
    }
}
