using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts
{
    public class UIAnimController : MonoBehaviour
    {
        [SerializeField]
        private Animator UIAnimator;

        [SerializeField] private Button hideButton;
        [SerializeField] private Button unHideButton;

        private void Start()
        {
            hideButton.onClick.AddListener(HideWindow);
            unHideButton.onClick.AddListener(UnHideWindow);
        }

        private void HideWindow()
        {
            SwitchButtonState(true);
        }

        private void UnHideWindow()
        {
            SwitchButtonState(false);
        }

        private void SwitchButtonState(bool isHide)
        {
            hideButton.gameObject.SetActive(!isHide);
            unHideButton.gameObject.SetActive(isHide);
            UIAnimator.SetBool("IsHide", isHide);
        }
    }
}
