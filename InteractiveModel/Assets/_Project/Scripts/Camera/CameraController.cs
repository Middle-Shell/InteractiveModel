using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Object;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts.Camera
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private CameraMovement cameraMovement;
        [SerializeField] private CameraRotation cameraRotation;
        [SerializeField] private CameraZoom cameraZoom;
        
        [SerializeField] private float smoothTime = 0.5f;

        private Transform Target { get; set; }

        private void Awake()
        {
            if(cameraMovement == null)
                cameraMovement = GetComponent<CameraMovement>();
            if(cameraRotation == null)
                cameraRotation = GetComponent<CameraRotation>();
            if(cameraZoom == null)
                cameraZoom = GetComponent<CameraZoom>();
            
            SceneMediator.OnTargetSelected.AddListener(OnTargetSelected);
        }

        private void Update()
        {
            cameraMovement.Move();
            cameraZoom.Zoom();
            cameraRotation.Rotate();

            if (cameraMovement.IsMoving)
            {
                SceneMediator.NotifyTargetSelected(new ObjectData());
            }
        }

        private void OnDestroy()
        {
            SceneMediator.OnTargetSelected.RemoveListener(OnTargetSelected);
        }
        
        private void SetTarget(Transform newTarget)
        {
            Target = newTarget;
            cameraRotation.SetTarget(newTarget);
            cameraZoom.SetTarget(newTarget);
        }

        private void OnTargetSelected(ObjectData target) 
        {
            StartCoroutine(CenterOnTarget(target.Transform)); 
            SetTarget(target.Transform);
        }

        private IEnumerator CenterOnTarget(Transform target)
        {
            if (target != null)
            {
                Vector3 startPosition = transform.position;
                Quaternion startRotation = transform.rotation;
                float timeElapsed = 0f;

                while (timeElapsed < smoothTime)
                {
                    transform.position = Vector3.Lerp(startPosition, target.position + Vector3.back * 5,
                        timeElapsed / smoothTime);

                    transform.rotation = Quaternion.Slerp(startRotation,
                        Quaternion.LookRotation(target.position - transform.position), timeElapsed / smoothTime);

                    timeElapsed += Time.deltaTime;

                    yield return null;
                }
            }
        }
    }
}