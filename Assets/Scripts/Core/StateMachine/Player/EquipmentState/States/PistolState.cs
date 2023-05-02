using Core.StateMachine.Player.MovementStates.StateManagers;

namespace Core.StateMachine.Player.EquipmentState.States
{
    public class PistolState : PlayerBaseState
    {
        public PistolState(PlayerStateMachine context, StateFactory factory) : base(context, factory)
        {
        }

        protected override void CheckSwitchStates()
        {
            base.CheckSwitchStates();
        }

        public override void OnEnteringState()
        {
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
        }
    }
}
