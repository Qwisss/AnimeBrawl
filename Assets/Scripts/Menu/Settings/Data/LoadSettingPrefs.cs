using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSettingPrefs : MonoBehaviour
{

    [Header("General Setting")]
/*    [SerializeField] private bool _canUse = false;*/
    [SerializeField] private VolumeSettings _volumeSettings;

    [Header("Volume Setting")]
    [SerializeField] private TextMeshProUGUI _volumeTextValue = null;
    [SerializeField] private Slider _volumeSlider = null;

    [Header("Controller Type Setting")]
    [SerializeField] private ControllerSettings _controllerSettings;

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
        _volumeSettings = _volumeSettings ?? FindObjectOfType<VolumeSettings>();

        _controllerSettings = _controllerSettings ?? FindObjectOfType<ControllerSettings>();
    }

    private void LoadPrefs()
    {
       /* if (_canUse == true)
        {*/
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

            // Load controller type settings
            if (PlayerPrefs.HasKey("selectedController"))
            {
                string selectedController = PlayerPrefs.GetString("selectedController");
                //SettingsData.SelectedController = selectedController;
                _controllerSettings.ActivateJoystick(selectedController);
            }

            // Load dropdown value settings
            if (PlayerPrefs.HasKey("selectedIndex"))
            {
                int selectedIndex = PlayerPrefs.GetInt("selectedIndex");
                //SettingsData.SelectedIndex = selectedIndex;
                _controllerSettings.SetDropdownValue(selectedIndex);
            }
        //}
    }
}
