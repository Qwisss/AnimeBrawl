using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LoadSettingPrefs : MonoBehaviour
{

    [Header("General Setting")]
    [SerializeField] private bool _canUse = false;
    [SerializeField] private MenuController _menuController;
    [SerializeField] private VolumeController _volumeController;

    [Header("Volume Setting")]
    [SerializeField] private TextMeshProUGUI _volumeTextValue = null;
    [SerializeField] private Slider _volumeSlider = null;

    // [Header("Brightness Setting")]

    // [Header("Quality Setting")]

    // [Header("Fullscreen Setting")]

    // [Header("Sensitibity Setting")]

    // [Header("Invert Y Setting")]

    // [Header("Controller Type Setting")]

    private void Awake()
    {
        Initialize();

        LoadPrefs();
    }

    private void Initialize()
    {
        if(_menuController == null)
        {
            _menuController = FindObjectOfType<MenuController>();
        }

        if(_volumeController == null)
        {
            _volumeController = FindObjectOfType<VolumeController>();
        }
    }

    private void LoadPrefs()
    {
        if (_canUse == true)
        {
            if (PlayerPrefs.HasKey("masterVolume"))
            {
                float localVolume = PlayerPrefs.GetFloat("masterVolume");

                _volumeTextValue.text = localVolume.ToString("0.0");
                _volumeSlider.value = localVolume;
                AudioListener.volume = localVolume;
            }
            else
            {
                _volumeController.VolumeReset("Audio");
            }


        }
    }
}
