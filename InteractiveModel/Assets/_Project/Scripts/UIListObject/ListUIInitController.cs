using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Object;
using UnityEngine;

namespace _Project.Scripts.UIListObject
{
    public class ListUIInitController : MonoBehaviour
    {
        private List<ObjectData> _sceneObjectsData = new List<ObjectData>();
        private List<GameObject> _contentContainers= new List<GameObject>();

        [SerializeField] private GameObject prefabContent;
        [SerializeField] private Transform contentContainerTransform;
    
        private void Awake()
        {
            SceneMediator.OnObjectSpawn.AddListener(OnObjectSpawn);
            SceneMediator.OnClearScene.AddListener(OnClearScene);
            SceneMediator.OnLoadScene.AddListener(InitUIList);
        }
        
        private void Start()
        {
            StartCoroutine(DelayInitUIList());
        }
        
        private void InitUIList()
        {
            StartCoroutine(DelayInitUIList());
        }

        private void OnObjectSpawn(ObjectData objectData)
        {
            _sceneObjectsData.Add(objectData);
        }
    
        private void OnClearScene()
        {
            _sceneObjectsData.Clear();
            foreach (var container in _contentContainers)
            {
                Destroy(container);
            }
            _contentContainers.Clear();
        }
    
        IEnumerator DelayInitUIList()
        {
            yield return new WaitForEndOfFrame();
            foreach (var objectData in _sceneObjectsData)
            {
                GameObject obj = Instantiate(prefabContent, contentContainerTransform);
                obj.GetComponent<ContentUIContainer>().InitContent(objectData);
                _contentContainers.Add(obj);
            }
        }
    }
}
