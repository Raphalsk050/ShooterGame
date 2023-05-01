using System;
using Animation;
using Core.StateMachine;
using UnityEngine;
using UnityEngine.Events;


namespace Core
{
    [RequireComponent(typeof(CharacterController))]
    public class Controller : MonoBehaviour
    {
        //public fields
        public float mouseSensitivity;
        public bool lookToRotation;
        public bool rotateTowardsMovement;

        //delegates
        public delegate void OnVelocityChanged(float currentVelocity);
        public OnVelocityChanged VelocityChanged;
        public delegate void OnMovementVectorInputChangedDelegate(Vector2 currentVelocity);
        public OnMovementVectorInputChangedDelegate OnMovementVectorInputChanged;
        
        //private fields
        private Quaternion _controllerRotation;
        private Quaternion _controllerYaw;
        private Quaternion _controllerPitch;
        private static Vector3 _movementVector;
        private static float _mouseX;
        private static float _mouseY;
        private Vector3 _velocity;
        private float _lastVelocity;
        private Vector3 _lastMousePosition;
        private Quaternion _currentVelocityDirection;
        private Vector3 _lastPosition;
        private Transform _playerMeshTransform;
        private CharacterController _characterController;
        private readonly float _gravity = 9.8f;
        private readonly float _jumpSpeed = 5f;
        private float _verticalSpeed;

        public static float Speed { get; set; } = 10f;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _verticalSpeed = 0f;
            _playerMeshTransform = GameObject.FindWithTag("PlayerMesh").transform;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            
            VelocityChanged += AnimationManager.OnAnyVelocityChanged;
            VelocityChanged += PlayerStateMachine.OnAnyVelocityChanged;
        }

        private void OnApplicationQuit()
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        private void LateUpdate()
        {
            RotateMeshWithControllerRotation();
            RotateTowardsMovement();
        }


        private void Update()
        {
            var verticalDirection = _controllerYaw * Vector3.forward * Input.GetAxisRaw("Vertical");
            var horizontalDirection = _controllerYaw * Vector3.right * Input.GetAxisRaw("Horizontal");
            
            MouseXPosition();
            MouseYPosition();
            UseControllerRotation();
            Jump();
            CompareVelocity();
            _playerMeshTransform.position = transform.position + Vector3.up * -1f;
            _verticalSpeed -= _gravity * Time.deltaTime;

            var upDirection = new Vector3(0, 1, 0) * _verticalSpeed;
            var groundVelocity = (verticalDirection + horizontalDirection).normalized * Speed;
            _movementVector = groundVelocity + upDirection;
            
            if (verticalDirection.magnitude != 0 || horizontalDirection.magnitude != 0)
            {
                OnMovementVectorInputChanged?.Invoke(groundVelocity);
            }
            
            _characterController.Move(_movementVector * Time.deltaTime);
        }

        private void MouseXPosition()
        {
            _mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        }

        private void CompareVelocity()
        {
            var currentVelocity = _velocity.magnitude;
            if (_lastVelocity != currentVelocity)
            {
                VelocityChanged?.Invoke(currentVelocity);
                _lastVelocity = _velocity.magnitude;
            }
        }

        private void MouseYPosition()
        {
            _mouseY = Mathf.Clamp(_mouseY - Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime, -85, 85);
        }

        private void Jump()
        {
            if (_characterController.isGrounded)
            {
                _verticalSpeed = 0;
                if (Input.GetKeyDown("space")) _verticalSpeed = _jumpSpeed;
            }
        }

        private void UseControllerRotation()
        {
            _controllerRotation = Quaternion.Euler(new Vector3(_mouseY, _mouseX, 0));
            _controllerYaw = Quaternion.Euler(new Vector3(0, _mouseX, 0));
            _controllerPitch = Quaternion.Euler(new Vector3(_mouseY, 0, 0));
        }

        private void RotateMeshWithControllerRotation()
        {
            if (lookToRotation)
            {
                var playerMeshRotation = _playerMeshTransform.rotation;
                playerMeshRotation = new Quaternion(playerMeshRotation.x, _controllerRotation.y, playerMeshRotation.z,
                    _controllerRotation.w);
                _playerMeshTransform.rotation = playerMeshRotation;
            }
        }

        private void RotateTowardsMovement()
        {
            if (!rotateTowardsMovement) return;

            var controllerVelocity = _characterController.velocity;
            var playerMeshRotation = _playerMeshTransform.rotation;
            _velocity = new Vector3(controllerVelocity.x, 0, controllerVelocity.z);

            if (_velocity.magnitude > 0)
            {
                var vector = new Vector3(_velocity.x * 700f, 0, _velocity.z);
                var finalPoint = _playerMeshTransform.right * Input.GetAxis("Mouse X") * Speed;
                Debug.DrawLine(transform.position, transform.position + _velocity);
                _currentVelocityDirection = Quaternion.LookRotation(_velocity + finalPoint, Vector3.up);
                _playerMeshTransform.rotation =
                    Quaternion.Slerp(playerMeshRotation, _currentVelocityDirection, Time.deltaTime * 10f);
            }
        }

        public Quaternion GetControlRotation()
        {
            return _controllerRotation;
        }
    }
}