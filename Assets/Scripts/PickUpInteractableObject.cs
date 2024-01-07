using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpInteractableObject : MonoBehaviour
{

    [SerializeField] private int coinCount;

    private void Start()
    {
        GetComponent<InteractableObject>().OnInteractEvent += PickUp;
    }

    public void PickUp(Inventory inventory)
    {
        inventory.AddCurrency(coinCount);
        Debug.Log("Picked11111111111111");
        Destroy(gameObject);
    }

}
