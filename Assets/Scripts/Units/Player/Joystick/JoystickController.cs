using System.Collections.Generic;
using UnityEngine;

public class JoystickController : MonoBehaviour
{

    [Header("Controller Type Setting")]
    [SerializeField] private DynamicJoystick _dynamicJoystick;
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private VariableJoystick _variableJoystick;

    private Dictionary<string, Joystick> _joysticks;

    private void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _joysticks = new Dictionary<string, Joystick>
        {
            {"Dynamic", _dynamicJoystick},
            {"Fixed", _fixedJoystick},
            {"Floating", _floatingJoystick},
            {"Variable", _variableJoystick}
        };

        LoadJoystickType();
    }

    private void LoadJoystickType()
    {
        if (PlayerPrefs.HasKey("selectedController"))
        {
            string joystickType = PlayerPrefs.GetString("selectedController");

            if (_joysticks.TryGetValue(joystickType, out Joystick selectedJoystick))
            {
                ActivateJoystick(selectedJoystick);
            }
            else
            {
                Debug.LogError("Invalid joystick type: " + joystickType);
            }
        }
        else
        {
            Debug.LogError("PlayerPrefs.HasKey(\"selectedController\") is null");
        }
    }

    private void ActivateJoystick(Joystick joystick)
    {
        // Проверяем, что контроллер не равен null, прежде чем активировать его
        if (joystick != null)
        {
            // Деактивируем все контроллеры
            DeactivateAllJoysticks();

            // Активируем выбранный контроллер
            joystick.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogError("Trying to activate a null joystick.");
        }
    }

    private void DeactivateAllJoysticks()
    {
        foreach (var joystick in _joysticks.Values)
        {
            if (joystick != null)
            {
                joystick.gameObject.SetActive(false);
            }
        }
    }

}
