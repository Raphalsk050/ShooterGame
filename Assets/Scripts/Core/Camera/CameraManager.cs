using System;
using UnityEngine;

namespace Core.Camera
{
    public class CameraManager : MonoBehaviour
    {
        private GameObject _aimCamera;
        private GameObject _moveCamera;

        private void Start()
        {
            _aimCamera = GameObject.Find("AimCamera");
            _moveCamera = GameObject.Find("MoveCamera");

            _aimCamera.SetActive(false);
            _moveCamera.SetActive(true);
        }

        private void Update()
        {
            //set aim mode
            if (Input.GetKey(KeyCode.Mouse1) && !_aimCamera.activeInHierarchy)
            {
                _aimCamera.SetActive(true);
                _moveCamera.SetActive(false);
            }

            if (Input.GetKeyUp(KeyCode.Mouse1) && _aimCamera.activeInHierarchy)
            {
                _aimCamera.SetActive(false);
                _moveCamera.SetActive(true);
            }
        }
    }
}
