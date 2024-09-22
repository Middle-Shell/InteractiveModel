using UnityEngine;

namespace _Project.Scripts.Camera
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 10f;

        private Vector3 _lastMousePosition;
        public bool IsMoving { get; private set; }


        public void Move()
        {
            if (Input.GetMouseButton(1)) 
            {
                Vector3 delta = Input.mousePosition - _lastMousePosition;
                transform.Translate(-delta.x * moveSpeed * Time.deltaTime, 
                    -delta.y * moveSpeed * Time.deltaTime, 
                    0f, Space.World); 
                IsMoving = true;
            }
            else
            {
                IsMoving = false;
            }
            _lastMousePosition = Input.mousePosition; 
        }
    }
}