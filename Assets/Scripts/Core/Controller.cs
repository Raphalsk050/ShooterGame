using System;
using Animation;
using UnityEngine;
using UnityEngine.Events;


namespace Core
{
    [RequireComponent(typeof(CharacterController))]
    public class Controller : MonoBehaviour
    {
        public float mouseSensitivity;
        public bool lookToRotation;
        public bool rotateTowardsMovement;
        public float speed = 10f;
        
        private Quaternion _controllerRotation;
        private static Vector3 _movementVector;
        private static float _mouseX;
        private static float _mouseY;
        private Vector3 _velocity;
        private Vector3 _lastMousePosition;
        private Quaternion _currentVelocityDirection;
        private Vector3 _lastPosition;
        private Transform _playerMeshTransform;
        private CharacterController _characterController;
        private readonly float _gravity = 9.8f;
        private readonly float _jumpSpeed = 5f;
        private float _verticalSpeed;
        private AnimationManager _animationManager;
        
        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
            _verticalSpeed = 0f;
            _animationManager = GameObject.Find("PlayerMesh").GetComponent<AnimationManager>();
            _playerMeshTransform = GameObject.FindWithTag("PlayerMesh").transform;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
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
            var verticalDirection = _controllerRotation * Vector3.forward * Input.GetAxisRaw("Vertical");
            var horizontalDirection = _controllerRotation * Vector3.right * Input.GetAxisRaw("Horizontal");
            MouseXPosition();
            MouseYPosition();
            UseControllerRotation();
            Jump();
            

            _verticalSpeed -= _gravity * Time.deltaTime;
            
            var upDirection = new Vector3(0, 1, 0) * _verticalSpeed;
            var groundVelocity = (verticalDirection + horizontalDirection).normalized * speed;
            _movementVector = groundVelocity + upDirection;
            _characterController.Move(_movementVector * Time.deltaTime);
        }

        private void MouseXPosition()
        {
            _mouseX += Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        }

        private void MouseYPosition()
        {
            _mouseY = Mathf.Clamp(_mouseY - Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime, -90f,60f);
        }

        private void Jump()
        {
            if (_characterController.isGrounded)
            {
                _verticalSpeed = 0;
                if (Input.GetKeyDown("space"))
                {
                    _verticalSpeed = _jumpSpeed;
                }
            }
        }
        
        private void UseControllerRotation()
        {
            _controllerRotation = Quaternion.Euler(new Vector3(_mouseY,_mouseX,0));
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
            _velocity = new Vector3(controllerVelocity.x,0,controllerVelocity.z);
            
            if (_velocity.magnitude > 0)
            {
                _currentVelocityDirection = Quaternion.LookRotation(_velocity, Vector3.up);
                _playerMeshTransform.rotation = Quaternion.Slerp(playerMeshRotation, _currentVelocityDirection, Time.deltaTime * 5f);
                
            }
        }
        
        public Quaternion GetControlRotation()
        {
            return _controllerRotation;
        }
    }
}
