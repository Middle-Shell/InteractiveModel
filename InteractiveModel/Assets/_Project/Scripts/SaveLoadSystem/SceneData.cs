using System.Collections.Generic;
using UnityEngine;

namespace _Project.Scripts.SaveLoadSystem
{
    [System.Serializable]
    public class SceneData 
    {
        public List<ObjectDataSerialize> objectData = new List<ObjectDataSerialize>();

        [System.Serializable]
        public class ObjectDataSerialize
        {
            public string name;
            public float colorR;
            public float colorG;
            public float colorB;
            public float colorA;
            public float posX;
            public float posY;
            public float posZ;
            public PrimitiveType primitiveType;
            public bool isActive;
            public bool isMeshEnabled;
        }
    }
}