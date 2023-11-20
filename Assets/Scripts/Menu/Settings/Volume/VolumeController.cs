using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [Header("Volume Setting")]
    [SerializeField] private TextMeshProUGUI _volumeTextValue = null;
    [SerializeField] private Slider _volumeSlider = null;
    [Range(0, 1)][SerializeField] private float _defaultVolume = 1f;

    [SerializeField] private GameObject _comfirmationPrompt = null;

    [Header("Courutine data")]
    [SerializeField] private float _delayTime = 0.4f;

    public void SetVolume(float volume)
    {
        AudioListener.volume = volume;
        _volumeTextValue.text = volume.ToString("0.0");
    }

    public void VolumeApply()
    {
        PlayerPrefs.SetFloat("masterVolume", AudioListener.volume);
        StartCoroutine(ConfirmationBox());
    }

    public void VolumeReset(string menyType)
    {
        if(menyType == "Audio")
        {
            AudioListener.volume = _defaultVolume;
            _volumeSlider.value = _defaultVolume;
            _volumeTextValue.text = _defaultVolume.ToString("0.0");
            VolumeApply();
        }
    }

    public IEnumerator ConfirmationBox()
    {
        _comfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(_delayTime);
        _comfirmationPrompt.SetActive(false);

    }
}
