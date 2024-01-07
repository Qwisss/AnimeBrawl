using UnityEngine;

public class InventoryHandler : MonoBehaviour
{

    public ItemGrid selectedItemGrid;

    private void Update()
    {
        if(selectedItemGrid == null)
        {
            return;
        }

        //selectedItemGrid.GetTileGridPosition(Input.mousePosition);

    }
}
