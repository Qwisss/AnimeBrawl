using UnityEngine;

public class ButtonSwitchScene : MonoBehaviour
{

    [SerializeField] private int _switchSceneTo;

    public void SwitchScene()
    {
        SceneHandler.Instance.SwitchTo(_switchSceneTo);
    }
}
