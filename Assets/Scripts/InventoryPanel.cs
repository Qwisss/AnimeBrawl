using TMPro;
using UnityEngine;

public class InventoryPanel : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI currencyText;
    [SerializeField] Inventory characterInventory;

    private int currency;


    private void OnEnable()
    {
        characterInventory.UpdateCurrency += UpdateCurrencyCount;
        characterInventory.GetData();
    }

    private void UpdateCurrencyCount(int currencyValue)
    {
        currency = currencyValue;
        currencyText.text = currency.ToString();
    }

    private void OnDisable()
    {
        characterInventory.UpdateCurrency -= UpdateCurrencyCount;
    }
}
