using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UIListObject
{
    public class ListWindowController : MonoBehaviour
    {
        [SerializeField]
        private Toggle visibleToggle;
        [SerializeField]
        private Toggle activeToggle;

        private void Awake()
        {
            visibleToggle.onValueChanged.AddListener(SwitchAllVisibleToggle);
            activeToggle.onValueChanged.AddListener(SwitchAllActiveToggle);
        }

        private void SwitchAllActiveToggle(bool isOn)
        {
            SceneMediator.NotifyAllObjectSwitchActive(isOn);
        }
    
        private void SwitchAllVisibleToggle(bool isOn)
        {
            SceneMediator.NotifyAllObjectSwitchVisible(isOn);
        }
    }
}
