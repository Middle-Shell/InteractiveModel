using UnityEngine;

namespace _Project.Scripts.Camera
{
    public class CameraZoom : MonoBehaviour
    {
        [SerializeField] private float zoomSpeed = 5f;
        
        private Transform _target;

        public void SetTarget(Transform newTarget)
        {
            _target = newTarget;
        }

        public void Zoom()
        {
            float scrollInput = Input.GetAxis("Mouse ScrollWheel");
            transform.Translate(transform.forward * scrollInput * zoomSpeed * Time.deltaTime, Space.World);
        }
    }
}