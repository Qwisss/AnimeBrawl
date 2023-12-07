using TMPro;
using UnityEngine;

public class ControllerSettings : MonoBehaviour
{
    [Header("Controller Type Setting")]
    [SerializeField] private DynamicJoystick _dynamicJoystick;
    [SerializeField] private FixedJoystick _fixedJoystick;
    [SerializeField] private FloatingJoystick _floatingJoystick;
    [SerializeField] private VariableJoystick _variableJoystick;

    [Header("Controller Type Dropdown")]
    [SerializeField] private TMP_Dropdown _controllerTypeDropdown;

    private void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
/*        if (_dynamicJoystick == null)
        {
            _dynamicJoystick = FindObjectOfType<DynamicJoystick>();
        }
        if (_fixedJoystick == null)
        {
            _fixedJoystick = FindObjectOfType<FixedJoystick>();
        }
        if (_floatingJoystick == null)
        {
            _floatingJoystick = FindObjectOfType<FloatingJoystick>();
        }
        if (_variableJoystick == null)
        {
            _variableJoystick = FindObjectOfType<VariableJoystick>();
        }*/
 

        if (_controllerTypeDropdown != null)
        {
            _controllerTypeDropdown.onValueChanged.AddListener(ActivateJoystickOnDropdownChange);
        }
        else
        {
            Debug.Log("_controllerTypeDropdown not found");
        }   
    }

    private void ActivateJoystickOnDropdownChange(int dropdownValue)
    {
        string selectedJoystickName = _controllerTypeDropdown.options[dropdownValue].text;
        ActivateJoystick(selectedJoystickName);
    }

    public void ActivateJoystick(string joystickName)
    {
        DeactivateAllJoysticks();
        switch (joystickName)
        {
            case "Dynamic":
                _dynamicJoystick.gameObject.SetActive(true);
                break;
            case "Fixed":
                _fixedJoystick.gameObject.SetActive(true);
                break;
            case "Floating":
                _floatingJoystick.gameObject.SetActive(true);
                break;
            case "Variable":
                _variableJoystick.gameObject.SetActive(true);
                break;
            default:
                Debug.LogError("Unknown joystick name: " + joystickName);
                break;
        }
    }

    public void ControllerApply()
    {
        SaveControllerPrefs();
        GetComponent<ConfirmationBox>().StartCoroutineConfirmationBox();
    }
    public void SetDropdownValue(int dropdownIndex)
    {
        _controllerTypeDropdown.value = dropdownIndex;
    }

    private void DeactivateAllJoysticks()
    {
        _dynamicJoystick.gameObject.SetActive(false);
        _fixedJoystick.gameObject.SetActive(false);
        _floatingJoystick.gameObject.SetActive(false);
        _variableJoystick.gameObject.SetActive(false);
    }

    private void SaveControllerPrefs()
    {
        if (_controllerTypeDropdown != null)
        {
            string selectedController = _controllerTypeDropdown.options[_controllerTypeDropdown.value].text;
            PlayerPrefs.SetString("selectedController", selectedController);
            //SettingsData.SelectedController = selectedController;

            int selectedIndex = _controllerTypeDropdown.value;
            PlayerPrefs.SetInt("selectedIndex", selectedIndex);
            //SettingsData.SelectedIndex = selectedIndex;

            PlayerPrefs.Save();
        }
    }
}
