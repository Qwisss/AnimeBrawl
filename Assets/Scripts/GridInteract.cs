using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GridInteract : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    InventoryHandler inventoryHandler;
    ItemGrid itemGrid;

    private void Start()
    {
        inventoryHandler = FindObjectOfType<InventoryHandler>();
        itemGrid = GetComponent<ItemGrid>();
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        inventoryHandler.selectedItemGrid = itemGrid;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
       
    }

}
