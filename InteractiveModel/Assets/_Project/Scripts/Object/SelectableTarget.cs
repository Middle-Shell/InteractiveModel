using UnityEngine;

namespace _Project.Scripts.Object
{
    public class SelectableTarget : MonoBehaviour
    {
        private ObjectData _objectData;

        private void Awake()
        {
            _objectData.Transform = transform;
            _objectData.MeshRenderer = GetComponent<MeshRenderer>();
            _objectData.GameObject = this.gameObject;
            _objectData.IsActive = true;
            _objectData.IsVisible = GetComponent<MeshRenderer>().enabled;
            _objectData.Name = gameObject.name;
        
            SceneMediator.OnObjectUIChangeState.AddListener(OnObjectUIChangeState);
        }


        private void Start()
        {
            SceneMediator.NotifyObjectSpawn(_objectData);
        }

        private void OnObjectUIChangeState(ObjectData objectData)
        {
            objectData.GameObject.name = objectData.Name;
            objectData.GameObject.SetActive(objectData.IsActive);
            objectData.MeshRenderer.enabled = objectData.IsVisible;
        }

        private void OnMouseDown()
        {
            SceneMediator.NotifyTargetSelected(_objectData);
        }
    }
}