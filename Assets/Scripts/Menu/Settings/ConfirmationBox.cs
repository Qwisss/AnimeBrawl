using System.Collections;
using UnityEngine;

public class ConfirmationBox : MonoBehaviour
{
    [Header("Courutine data")]
    [SerializeField] private float _delayTime = 0.4f;
    [SerializeField] private GameObject _comfirmationPrompt = null;

    public void StartCoroutineConfirmationBox()
    {
        StartCoroutine(ShowConfirmationBox());
    }

    private IEnumerator ShowConfirmationBox()
    {
        _comfirmationPrompt.SetActive(true);
        yield return new WaitForSeconds(_delayTime);
        _comfirmationPrompt.SetActive(false);
    }
}
