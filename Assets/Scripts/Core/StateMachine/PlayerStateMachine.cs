using Core.StateMachine.Player;
using UnityEngine;

namespace Core.StateMachine
{
    public class PlayerStateMachine : MonoBehaviour
    {
        private static float _playerVelocity;
        private float _currentMovementSpeed;
        private static Animator _animator;
        private static readonly int Velocity = Animator.StringToHash("Velocity");

        public BaseState CurrentState { get; set; }

        public PlayerStateFactory States { get; set; }

        public CharacterController PlayerController { get; set; }

        public static void OnAnyVelocityChanged(float velocity)
        {
            _playerVelocity = velocity;
            //_animator.SetFloat(Velocity, velocity);
        }

        public void SetPlayerSpeed(float speed)
        {
            Controller.Speed = speed;
        }

        public float GetPlayerVelocity()
        {
            return _playerVelocity;
        }
        
        private void Awake()
        {
            States = new PlayerStateFactory(this);
            _animator = GetComponent<Animator>();
            PlayerController = GetComponent<CharacterController>();
            
        }
        
        private void Start()
        {
            CurrentState = States.Idle();
            CurrentState.OnEnteringState();
        }

        private void Update()
        {
            CurrentState.UpdateState();
        }
    }
}
