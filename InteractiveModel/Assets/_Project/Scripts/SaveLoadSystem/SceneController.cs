using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using _Project.Scripts.Object;
using UnityEngine;

namespace _Project.Scripts.SaveLoadSystem
{
    public class SceneController : MonoBehaviour
    {
        [SerializeField] private Material basicMaterial;
        [SerializeField] private string saveFilePath = "sceneData.dat";

        private List<GameObject> _sceneObjects = new List<GameObject>();

        private void Awake()
        {
            SceneMediator.OnObjectSpawn.AddListener(OnObjectSpawn);
        }

        private void OnObjectSpawn(ObjectData objectData)
        {
            _sceneObjects.Add(objectData.GameObject);
        }

        public void SaveScene()
        {
            SceneData sceneData = new SceneData();

            foreach (GameObject obj in _sceneObjects)
            {
                sceneData.objectData.Add(CreateObjectDataFromGameObject(obj));
            }

            SaveSceneData(sceneData);
        }

        public void LoadScene()
        {
            SceneMediator.NotifyClearScene();
            ClearScene();

            SceneData sceneData = LoadSceneData();
            if (sceneData != null)
            {
                LoaderObject loader = gameObject.AddComponent<LoaderObject>();
                foreach (SceneData.ObjectDataSerialize data in sceneData.objectData)
                {
                    LoadObjectFromData(data, loader);
                }
                Destroy(loader);
                SceneMediator.NotifyLoadScene();
            }
        }

        private SceneData LoadSceneData()
        {
            if (File.Exists(saveFilePath))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                FileStream stream = File.Open(saveFilePath, FileMode.Open);
                SceneData sceneData = (SceneData) formatter.Deserialize(stream);
                stream.Close();
                return sceneData;
            }

            return null;
        }

        private void SaveSceneData(SceneData sceneData)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = File.Create(saveFilePath);
            formatter.Serialize(stream, sceneData);
            stream.Close();
        }

        private SceneData.ObjectDataSerialize CreateObjectDataFromGameObject(GameObject obj)
        {
            PrimitiveType primitiveType = GetPrimitiveType(obj);
            Color currentColor = obj.GetComponent<MeshRenderer>().material.color;
            Vector3 currentPosition = obj.transform.position;

            return new SceneData.ObjectDataSerialize()
            {
                name = obj.name,

                colorR = currentColor.r,
                colorG = currentColor.g,
                colorB = currentColor.b,
                colorA = currentColor.a,

                posX = currentPosition.x,
                posY = currentPosition.y,
                posZ = currentPosition.z,

                primitiveType = primitiveType,
                isActive = obj.activeSelf,
                isMeshEnabled = obj.GetComponent<MeshRenderer>().enabled,
            };
        }

        private PrimitiveType GetPrimitiveType(GameObject obj)
        {
            MeshFilter meshFilter = obj.GetComponent<MeshFilter>();
            if (meshFilter != null && meshFilter.sharedMesh != null)
            {
                switch (meshFilter.sharedMesh.name)
                {
                    case "Sphere":
                        return PrimitiveType.Sphere;
                    case "Cube":
                        return PrimitiveType.Cube;
                    case "Capsule":
                        return PrimitiveType.Capsule;
                    case "Cylinder":
                        return PrimitiveType.Cylinder;
                    case "Quad":
                        return PrimitiveType.Quad;
                    case "Plane":
                        return PrimitiveType.Plane;
                    default:
                        Debug.LogWarning("Unknown primitive type: " + meshFilter.sharedMesh.name);
                        break;
                }
            }

            return PrimitiveType.Cube;
        }

        private void LoadObjectFromData(SceneData.ObjectDataSerialize data, LoaderObject loader)
        {
            StartCoroutine(loader.InitObject(data, basicMaterial));
        }
        
        private void ClearScene()
        {
            foreach (GameObject obj in _sceneObjects)
            {
                Destroy(obj);
            }

            _sceneObjects.Clear();
        }
    }
}