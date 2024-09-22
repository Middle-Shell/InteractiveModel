using UnityEngine;

namespace _Project.Scripts.Camera
{
    public class CameraRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 50f;
        
        private Transform _target;

        public void SetTarget(Transform newTarget)
        {
            _target = newTarget;
        }

        public void Rotate()
        {
            if (Input.GetMouseButton(2) && _target != null) 
            {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                transform.RotateAround(_target.position, Vector3.up, mouseX * rotationSpeed * Time.deltaTime);
                transform.RotateAround(_target.position, transform.right, -mouseY * rotationSpeed * Time.deltaTime);
            }
        }
    }
}