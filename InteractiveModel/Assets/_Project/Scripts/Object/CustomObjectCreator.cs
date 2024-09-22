using UnityEditor;
using UnityEngine;

namespace _Project.Scripts.Object
{
    public class CustomObjectCreator : MonoBehaviour
    {
        [MenuItem("GameObject/Custom/CustomCube")]
        static void CreateCustomCube()
        {
            GameObject cubePrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/CustomGameObject/CustomCube.prefab"); 

            GameObject newObject = Instantiate(cubePrefab); 

            newObject.transform.position = Vector3.zero;
        }
    
        [MenuItem("GameObject/Custom/CustomCapsule")]
        static void CreateCustomCapsule()
        {
            GameObject capsulePrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/CustomGameObject/CustomCapsule.prefab"); 

            GameObject newObject = Instantiate(capsulePrefab); 

            newObject.transform.position = Vector3.zero;
        }
    
        [MenuItem("GameObject/Custom/CustomCylinder")]
        static void CreateCustomCylinder()
        {
            GameObject cylinderPrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/CustomGameObject/CustomCylinder.prefab"); 

            GameObject newObject = Instantiate(cylinderPrefab); 

            newObject.transform.position = Vector3.zero;
        }
    
        [MenuItem("GameObject/Custom/CustomSphere")]
        static void CreateCustomSphere()
        {
            GameObject spherePrefab = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/_Project/CustomGameObject/CustomSphere.prefab"); 

            GameObject newObject = Instantiate(spherePrefab); 

            newObject.transform.position = Vector3.zero;
        }
    }
}