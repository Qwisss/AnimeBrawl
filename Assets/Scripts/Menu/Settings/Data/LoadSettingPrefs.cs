using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LoadSettingPrefs : MonoBehaviour
{

    [Header("General Setting")]
/*    [SerializeField] private bool _canUse = false;*/
    [SerializeField] private VolumeSettings _volumeSettings;
    [SerializeField] private GraphicsSettings _graphicsSettings;

    [Header("Volume Setting")]
    [SerializeField] private TextMeshProUGUI _volumeTextValue = null;
    [SerializeField] private Slider _volumeSlider = null;

    [Header("Controller Type Setting")]

    [Header("FPS Setting")]
    [SerializeField] private TextMeshProUGUI _FPSSlideTextValue = null;
    [SerializeField] private Slider _FPSSlider = null;
 

    // [Header("Brightness Setting")]

    // [Header("Quality Setting")]

    // [Header("Fullscreen Setting")]

    // [Header("Sensitibity Setting")]

    // [Header("Invert Y Setting")]

    // [Header("Controller Type Setting")]

    private void Start()
    {
        Initialize();

        LoadPrefs();
    }

    private void Initialize()
    {
        if (_volumeSettings == null)
        {
            _volumeSettings = FindObjectOfType<VolumeSettings>();
        }
        if (_graphicsSettings == null)
        {
            _graphicsSettings = FindObjectOfType<GraphicsSettings>();
        }
    }

    private void LoadPrefs()
    {
        // Load volume settings
        if (PlayerPrefs.HasKey("masterVolume"))
        {
            float localVolume = PlayerPrefs.GetFloat("masterVolume");
            SettingsData.MasterVolume = localVolume;
            _volumeTextValue.text = localVolume.ToString("0.0");
            _volumeSlider.value = localVolume;
            AudioListener.volume = localVolume;
        }
        else
        {
            _volumeSettings.VolumeReset("Audio");
        }

        // Load FPS settings
        if (PlayerPrefs.HasKey("masterFPS"))
        {
            int localFPS = PlayerPrefs.GetInt("masterFPS");
            SettingsData.MasterFPS = localFPS;
            _FPSSlideTextValue.text = localFPS.ToString("0");
            _FPSSlider.value = localFPS;
            Application.targetFrameRate = localFPS;
        }
        else
        {
            _graphicsSettings.PFSReset("Graphic");
        }
    }
}
