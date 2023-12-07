using UnityEngine;
using UnityEngine.UI;

public class BarBase : MonoBehaviour
{

    [SerializeField] private Slider _currentBar;

    public virtual void Awake()
    {
        Iniatialize();
    }

    public virtual void Iniatialize()
    {
        if(_currentBar == null)
        {
            _currentBar = GetComponent<Slider>();
        }
    }

    public void UpdateBar(int maxValue, int currentValue)
    {
        _currentBar.maxValue = maxValue;
        _currentBar.minValue = 0;
        _currentBar.value = currentValue;
    }
}
