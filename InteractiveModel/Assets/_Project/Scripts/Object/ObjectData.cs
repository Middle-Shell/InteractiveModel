using UnityEngine;

namespace _Project.Scripts.Object
{
    public struct ObjectData
    {
        public Transform Transform;
        public MeshRenderer MeshRenderer;
        public GameObject GameObject;
        public bool IsVisible;
        public bool IsActive;
        public string Name;
    
        public static bool operator ==(ObjectData c1, ObjectData c2)
        {
            return c1.Equals(c2);
        }
        public static bool operator !=(ObjectData c1, ObjectData c2)
        {
            return !c1.Equals(c2);
        }

    }
}
