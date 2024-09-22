using System.Collections;
using _Project.Scripts.SaveLoadSystem;
using UnityEngine;

namespace _Project.Scripts.Object
{
    public class LoaderObject : MonoBehaviour
    {
        public IEnumerator InitObject(SceneData.ObjectDataSerialize data, Material basicMaterial)
        {
            GameObject obj = GameObject.CreatePrimitive(data.primitiveType);
            
            obj.AddComponent<InitObject>().Init(data.name, new Vector3(data.posX, data.posY, data.posZ), basicMaterial, new Color(data.colorR, data.colorG, data.colorB, data.colorA), data.isMeshEnabled);
            /*obj.name = data.name;
            obj.transform.position = new Vector3(data.posX, data.posY, data.posZ);

            obj.GetComponent<MeshRenderer>().material = basicMaterial;
            obj.GetComponent<MeshRenderer>().material.color = new Color(data.colorR, data.colorG, data.colorB, data.colorA);
            obj.GetComponent<MeshRenderer>().enabled = data.isMeshEnabled;

            obj.AddComponent<SelectableTarget>();
            */
            
            yield return new WaitForEndOfFrame();
            obj.SetActive(data.isActive);
        }
    }
}