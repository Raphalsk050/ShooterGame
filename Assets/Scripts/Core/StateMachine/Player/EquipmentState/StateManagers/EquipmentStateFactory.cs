using Core.StateMachine.Player.EquipmentState.States;
using Core.StateMachine.Player.MovementStates.StateManagers;

namespace Core.StateMachine.Player.EquipmentState.StateManagers
{
    public class EquipmentStateFactory : StateFactory
    {
        public EquipmentStateFactory(PlayerStateMachine currentContext) : base(currentContext)
        {
        }

        public PlayerBaseState PistolState()
        {
            return new PistolState(Context, this);
        }
    
        public PlayerBaseState RifleState()
        {
            return new PistolState(Context, this);
        }
    
        public PlayerBaseState UnarmedState()
        {
            return new PistolState(Context, this);
        }
    }
}
