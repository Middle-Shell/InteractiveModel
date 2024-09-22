using _Project.Scripts.Object;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.ColorPicker
{
    public class Picker : MonoBehaviour
    {

        public float currentHue, currentSat, currentVal, currentAlpha;

        [SerializeField] private RawImage hueImage, satValImage, outputImage;

        [SerializeField] private Slider hueSlider, alphaSlider;

        [SerializeField] private TMP_InputField hexInputField;

        private Texture2D hueTexture, svTexture, outputTexture;

        [SerializeField] private MeshRenderer targetMeshRenderer;

        private void Awake()
        {
            SceneMediator.OnTargetSelected.AddListener(OnChangeTargetMeshRenderer);
        }

        private void Start()
        {
            CreateHueImage();
            CreateSVImage();
            CreateOutputImage();
        
            //UpdateOutputImage();
        }

        private void OnChangeTargetMeshRenderer(ObjectData objectData)
        {
            targetMeshRenderer = objectData.MeshRenderer;
            OnTargetInput();
        }


        private void CreateHueImage()
        {
            hueTexture = new Texture2D(1, 16);
            hueTexture.wrapMode = TextureWrapMode.Clamp;
            hueTexture.name = "HueTexture";
            for (int i = 0; i < hueTexture.height; i++)
            {
                hueTexture.SetPixel(0, i, Color.HSVToRGB((float) i / hueTexture.height, 1, 1f));
            }
        
            hueTexture.Apply();
            currentHue = 0;

            hueImage.texture = hueTexture;
        }

        private void CreateSVImage()
        {
            svTexture = new Texture2D(16, 16);
            svTexture.wrapMode = TextureWrapMode.Clamp;
            svTexture.name = "SatValTexture";

            for (int y = 0; y < svTexture.height; y++)
            {
                for (int x = 0; x < svTexture.width; x++)
                {
                    svTexture.SetPixel(x, y,
                        Color.HSVToRGB(
                            currentHue, 
                            (float) x / svTexture.width, 
                            (float) y / svTexture.height
                        ));
                }
            }
        
            svTexture.Apply();
            currentSat = 0;
            currentVal = 0;
            currentAlpha = 1;

            satValImage.texture = svTexture;
        }

        private void CreateOutputImage()
        {
            outputTexture = new Texture2D(1, 16);
            outputTexture.wrapMode = TextureWrapMode.Clamp;
            outputTexture.name = "OutputTexture";
            Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);
            currentColor.a = currentAlpha;

            for (int i = 0; i < outputTexture.height; i++)
            {
                outputTexture.SetPixel(0, i, currentColor);
            }
        
            outputTexture.Apply();

            outputImage.texture = outputTexture;
        }

        private void UpdateOutputImage()
        {
            if(targetMeshRenderer == null)
                return;
            Color currentColor = Color.HSVToRGB(currentHue, currentSat, currentVal);
            currentColor.a = currentAlpha; 

            for (int i = 0; i < outputTexture.height; i++)
            {
                outputTexture.SetPixel(0, i, currentColor);
            }
        
            outputTexture.Apply();
        
            targetMeshRenderer.material.SetColor("_Color", currentColor);
        }

        public void SetSV(float s, float v)
        {
            currentSat = s;
            currentVal = v;
        
            UpdateOutputImage();
        }

        public void UpdateSVImage()
        {
            currentHue = hueSlider.value;

            for (int y = 0; y < svTexture.height; y++)
            {
                for (int x = 0; x < svTexture.width; x++)
                {
                    svTexture.SetPixel(x, y,
                        Color.HSVToRGB(
                            currentHue, 
                            (float) x / svTexture.width, 
                            (float) y / svTexture.height
                        ));
                }
            }
        
            svTexture.Apply();
        
            UpdateOutputImage();
        }

        public void UpdateAlpha()
        {
            currentAlpha = alphaSlider.value;
            UpdateOutputImage();
        }

        public void OnTextInput()
        {
            if(hexInputField.text.Length < 6) { return;}

            if (ColorUtility.TryParseHtmlString("#" + hexInputField.text, out var newCol))
            {
                Color.RGBToHSV(newCol, out currentHue, out currentSat, out currentVal);
                currentAlpha = newCol.a;
            }

            hueSlider.value = currentHue;
            alphaSlider.value = currentAlpha;
            hexInputField.text = "";
        
            UpdateOutputImage();
        }
    
        private void OnTargetInput()
        {
            if(targetMeshRenderer == null)
                return;
            Color newCol = targetMeshRenderer.material.color;
            Color.RGBToHSV(newCol, out currentHue, out currentSat, out currentVal);
            currentAlpha = newCol.a;

            hueSlider.value = currentHue;
            alphaSlider.value = currentAlpha;
            hexInputField.text = newCol.ToString();
        
            UpdateOutputImage();
        }
    
    }
}