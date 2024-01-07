using System;
using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{
    public string ObjectName;
    public event Action<Inventory> OnInteractEvent;


    private void Start()
    {
        ObjectName = gameObject.name;
    }
    public void Interact(Inventory inventory)
    {
        OnInteractEvent?.Invoke(inventory);
    }
}
