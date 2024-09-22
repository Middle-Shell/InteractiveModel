using UnityEngine;

namespace _Project.Scripts.Object
{
    public class InitObject : MonoBehaviour
    {
        public void Init(string newName, Vector3 position, Material material, Color color, bool isMeshEnabled)
        {
            name = newName;
            transform.position = position;

            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();

            meshRenderer.material = material;
            meshRenderer.material.color = color;
            meshRenderer.enabled = isMeshEnabled;

            gameObject.AddComponent<SelectableTarget>();
            
            Destroy(this);
        }
    }
}