using System;
using UnityEngine;
using UnityEngine.Events;

namespace Core.Camera
{
    public class SpringArm : MonoBehaviour
    {
        public Vector3 targetOffset;
        public Controller controller;
        
        private void RotateAroundCharacter(Quaternion quaternion)
        {
            transform.rotation = quaternion;
        }
        
        private void OnDrawGizmosSelected()
        {
            if (!transform.GetChild(0) || Application.isPlaying) return;
            Vector3 selfPosition = transform.position;
            Vector3 absoluteOffset = selfPosition + targetOffset;
            //SetChildPosition();
            SetChildRotation();
            Gizmos.DrawLine(selfPosition,absoluteOffset);
        }

        private void Update()
        {
            transform.rotation = controller.GetControlRotation();
            if (!transform.GetChild(0)) return;

            //SetChildPosition();
            
            SetChildRotation();
        }

        private void SetChildPosition()
        {
            Vector3 selfPosition = transform.position;
            Vector3 absoluteOffset = selfPosition + targetOffset;
            transform.GetChild(0).position = absoluteOffset;
        }

        private void SetChildRotation()
        {
            transform.GetChild(0).LookAt(transform);
        }
    }
}
