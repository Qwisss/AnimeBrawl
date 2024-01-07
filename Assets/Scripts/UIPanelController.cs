using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIPanelController : MonoBehaviour
{
    [SerializeField] private InputController _inputController;

    [SerializeField] private GameObject _inventoryPanel;
    [SerializeField] private GameObject _statsPanel;
    [SerializeField] private GameObject _characterPanel;
    [SerializeField] private GameObject _questPanel;

    private void Start()
    {
        _inputController.OnPressIEvent += OpenInventoryPanel;
    }

    public void OpenInventoryPanel()
    {
        _inventoryPanel.SetActive(!_inventoryPanel.activeInHierarchy);
    }

    public void OpenStatsPanel()
    {
        _statsPanel.SetActive(!_statsPanel.activeInHierarchy);
    }

    public void OpenCharacterPanel()
    {
        _characterPanel.SetActive(!_characterPanel.activeInHierarchy);
    }

    public void OpenSettingsPanel()
    {
        _questPanel.SetActive(!_questPanel.activeInHierarchy);
    }

}
