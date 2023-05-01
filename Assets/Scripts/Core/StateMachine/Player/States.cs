namespace Core.StateMachine.Player
{
    public class States
    {
        public PlayerWeaponStates WeaponStates;
        public PlayerMovementStates MovementStates;
        public PlayerActionStates ActionStates;
        public enum PlayerWeaponStates
        {
            Unarmed = 0,
            Rifle = 1,
            Pistol = 2
        }

        public enum PlayerMovementStates
        {
            Walk = 0,
            Run = 1,
            Sprint = 2,
            Crouch = 3,
            Prone = 4
        }

        public enum PlayerActionStates
        {
            Idle = 0,
            Aiming = 1
        }
    }
}
