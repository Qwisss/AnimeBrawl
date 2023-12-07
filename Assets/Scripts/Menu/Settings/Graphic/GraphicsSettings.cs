using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GraphicsSettings : MonoBehaviour
{
    [Header("FPS Setting")]
    [SerializeField] private TextMeshProUGUI _FPSSlideTextValue = null;
    [SerializeField] private Slider _FPSSlider = null;
    [Range(30, 240)][SerializeField] private int _defaultFPSValue = 60;


    public void SetFPS(float FPS)
    {
        Application.targetFrameRate = (int)FPS;
        _FPSSlideTextValue.text = FPS.ToString("0");
    }

    public void FPSApply()
    {
        PlayerPrefs.SetInt("masterFPS", Application.targetFrameRate);
        SettingsData.MasterFPS = Application.targetFrameRate;
        GetComponent<ConfirmationBox>().StartCoroutineConfirmationBox();
    }

    public void PFSReset(string menyType)
    {
        if (menyType == "Graphic")
        {
            Application.targetFrameRate = _defaultFPSValue;
            _FPSSlider.value = _defaultFPSValue;
            _FPSSlideTextValue.text = _defaultFPSValue.ToString("0");
            FPSApply();
        }
    }
}
