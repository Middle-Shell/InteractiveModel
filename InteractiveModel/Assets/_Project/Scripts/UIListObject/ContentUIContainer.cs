using _Project.Scripts.Object;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UIListObject
{
    public class ContentUIContainer : MonoBehaviour
    {
        [SerializeField] private Toggle visibleToggle;
        [SerializeField] private Toggle activeToggle;
        [SerializeField] private TMP_InputField nameInputField;

        [SerializeField] private GameObject activeBackground;

        private ObjectData _objectData;

        public void InitContent(ObjectData objectData)
        {
            _objectData = objectData;
            visibleToggle.isOn = objectData.IsVisible;
            activeToggle.isOn = objectData.GameObject.activeSelf;
            nameInputField.text = objectData.Name;

            visibleToggle.onValueChanged.AddListener(OnVisibleToggleChanged);
            activeToggle.onValueChanged.AddListener(OnActiveToggleChanged);
            nameInputField.onValueChanged.AddListener(OnNameChanged);

            SceneMediator.OnAllObjectSwitchActive.AddListener(SwitchActive);
            SceneMediator.OnAllObjectSwitchVisible.AddListener(SwitchVisible);
            SceneMediator.OnTargetSelected.AddListener(OnTargetSelected);
        }


        private void OnTargetSelected(ObjectData data)
        {
            if(data == _objectData)
                activeBackground.SetActive(true);
            else
                activeBackground.SetActive(false);
        }

        private void SwitchActive(bool isOn)
        {
            activeToggle.isOn = isOn;
        }

        private void SwitchVisible(bool isOn)
        {
            visibleToggle.isOn = isOn;
        }


        public void OnVisibleToggleChanged(bool isOn)
        {
            _objectData.IsVisible = isOn;
            SceneMediator.NotifyObjectUIChangeState(_objectData);
        }

        public void OnActiveToggleChanged(bool isOn)
        {
            _objectData.IsActive = isOn;
            SceneMediator.NotifyObjectUIChangeState(_objectData);
        }

        public void OnNameChanged(string text)
        {
            _objectData.Name = text;
            SceneMediator.NotifyObjectUIChangeState(_objectData);
        }
    }
}
