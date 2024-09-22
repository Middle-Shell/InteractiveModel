using _Project.Scripts.Object;
using UnityEngine;
using UnityEngine.Events;

namespace _Project.Scripts
{
    public class SceneMediator : MonoBehaviour
    {
        public static UnityEvent<ObjectData> OnTargetSelected = new UnityEvent<ObjectData>();

        public static void NotifyTargetSelected(ObjectData target) 
        {
            OnTargetSelected.Invoke(target); 
        }
    
        public static UnityEvent<ObjectData> OnObjectSpawn = new UnityEvent<ObjectData>();

        public static void NotifyObjectSpawn(ObjectData target) 
        {
            OnObjectSpawn.Invoke(target); 
        }
    
        public static UnityEvent<ObjectData> OnObjectUIChangeState = new UnityEvent<ObjectData>();

        public static void NotifyObjectUIChangeState(ObjectData target) 
        {
            OnObjectUIChangeState.Invoke(target); 
        }
    
        public static UnityEvent<bool> OnAllObjectSwitchActive = new UnityEvent<bool>();

        public static void NotifyAllObjectSwitchActive(bool isOn) 
        {
            OnAllObjectSwitchActive.Invoke(isOn); 
        }
    
        public static UnityEvent<bool> OnAllObjectSwitchVisible = new UnityEvent<bool>();

        public static void NotifyAllObjectSwitchVisible(bool isOn) 
        {
            OnAllObjectSwitchVisible.Invoke(isOn); 
        }
    
        public static UnityEvent OnClearScene = new UnityEvent();

        public static void NotifyClearScene() 
        {
            OnClearScene.Invoke(); 
        }
    
        public static UnityEvent OnLoadScene = new UnityEvent();

        public static void NotifyLoadScene() 
        {
            OnLoadScene.Invoke(); 
        }
    }
}
