using System.Collections;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI _FPSCount;
    [SerializeField] private float _updateTime = 0.1f;


    private void OnEnable()
    {
        StartCoroutine(UpdateTimer());
    }


    private IEnumerator UpdateTimer()
    {
        while (true)
        {

            float fps = 1f / Time.deltaTime;
            _FPSCount.text = $"{Mathf.Round(fps)}";

            yield return new WaitForSeconds(_updateTime);
        }
    }



    private void OnDisable()
    {
        StopCoroutine(UpdateTimer());
    }

}
