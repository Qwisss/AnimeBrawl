using UnityEngine;
using UnityEngine.UI;

public class UIPoolBar : BarBase
{

    private ValuePool _targetPool;

    public void Show(ValuePool targetPool)
    {
        _targetPool = targetPool;
        UpdateBar(_targetPool.MaxValue.Integer_value, _targetPool.CurrentValue);
    }

    public void Clear()
    {
        _currentBar.maxValue = 0;
        _currentBar.minValue = 0;
        _currentBar.value = 0;
    }
}
