using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int currency;
    public event Action<int> UpdateCurrency;

    private void Start()
    {
       // UpdateCurrency.Invoke(currency);
    }

    public void GetData()
    {
        UpdateCurrency.Invoke(currency);
    }

    public void AddCurrency(int amount)
    {
        currency += amount;
        Debug.Log("Currency = " + currency.ToString());
        //UpdateCurrency.Invoke(currency);
    }
}
