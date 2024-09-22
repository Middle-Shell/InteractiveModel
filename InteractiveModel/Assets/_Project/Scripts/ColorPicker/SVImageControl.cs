using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace _Project.Scripts.ColorPicker
{
    public class SVImageControl : MonoBehaviour, IDragHandler, IPointerClickHandler
    {
        [SerializeField] private Image pickerImage;

        private Picker _picker;

        private RectTransform _rectTransform, _pickerTransform;
        private IDragHandler _dragHandlerImplementation;
        private IPointerClickHandler _pointerClickHandlerImplementation;

        private void Start()
        {
            _picker = FindObjectOfType<Picker>();
            _rectTransform = GetComponent<RectTransform>();
        
            _pickerTransform = pickerImage.GetComponent<RectTransform>();

            _pickerTransform.localPosition =
                new Vector2(-(_rectTransform.sizeDelta.x * 0.5f), -(_rectTransform.sizeDelta.y * 0.5f));
        }

        private void UpdateColor(PointerEventData eventData)
        {
            Vector3 pos = _rectTransform.InverseTransformPoint(eventData.position);

            float deltaX = _rectTransform.sizeDelta.x * 0.5f;
            float deltaY = _rectTransform.sizeDelta.y * 0.5f;

            if (pos.x < -deltaX)
            {
                pos.x = -deltaX;
            }
            else if (pos.x > deltaX)
            {
                pos.x = -deltaX;
            }

            if (pos.y < -deltaY)
            {
                pos.y = -deltaY;
            }
            else if (pos.y > deltaY)
            {
                pos.y = deltaY;
            }

            float x = pos.x + deltaX;
            float y = pos.y + deltaY;

            float xNorm = x / _rectTransform.sizeDelta.x;
            float yNorm = y / _rectTransform.sizeDelta.y;

            _pickerTransform.localPosition = pos;
            pickerImage.color = Color.HSVToRGB(0, 0, 1 - yNorm);
        
            _picker.SetSV(xNorm,yNorm);
        }

        public void OnDrag(PointerEventData eventData)
        {
            UpdateColor(eventData);
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            UpdateColor(eventData);
        }
    }
}