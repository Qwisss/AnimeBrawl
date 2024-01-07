using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGrid : MonoBehaviour
{
    const float TileSizeWidth = 32f;
    const float TileSizeHeight = 32f;

    private RectTransform rectTransform;

    private Vector2 mousePositionOnTheGrid;
    Vector2Int tileGridPosition = new Vector2Int();

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

/*    private void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 200, 20), mousePositionOnTheGrid.ToString());
        GUI.Label(new Rect(10, 30, 200, 20), GetTileGridPosition(Input.mousePosition).ToString());
    }*/

    public Vector2Int GetTileGridPosition(Vector2 mousePosition)
    {
        mousePositionOnTheGrid.x = mousePosition.x - rectTransform.position.x;
        mousePositionOnTheGrid.y = rectTransform.position.y - mousePosition.y;

        tileGridPosition.x = (int)(mousePositionOnTheGrid.x / TileSizeWidth);
        tileGridPosition.y = (int)(mousePositionOnTheGrid.y / TileSizeHeight);

        return tileGridPosition;
    }
  
}
