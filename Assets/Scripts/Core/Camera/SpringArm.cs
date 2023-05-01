using UnityEngine;

namespace Core.Camera
{
    public class SpringArm : MonoBehaviour
    {
        public Controller controller;

        private void RotateAroundCharacter(Quaternion quaternion)
        {
            transform.rotation = quaternion;
        }
        
        private void Update()
        {
            transform.rotation = controller.GetControlRotation();
        }
    }
}
