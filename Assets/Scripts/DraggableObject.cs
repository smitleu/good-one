using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableObject : MonoBehaviour
{
    Vector3 screenSpace;
    Vector3 offset;
    Vector3 originalPosition;

    void OnMouseDown()
    {
        //translate the cubes position from the world to Screen Point
        screenSpace = Camera.main.WorldToScreenPoint(transform.position);

        //calculate any difference between the cubes world position and the mouses Screen position converted to a world point  
        offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z));

        originalPosition = transform.position;
    }

    void OnMouseDrag()
    {

        var curScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenSpace.z);

        //convert the screen mouse position to world point and adjust with offset
        var curPosition = Camera.main.ScreenToWorldPoint(curScreenSpace) + offset;

        //update the position of the object in the world
        transform.position = curPosition;


    }

    private void OnMouseUp()
    {
        var finalPos = Camera.main.WorldToScreenPoint(transform.position);

        if (finalPos.x < 0 | finalPos.x > Screen.width | finalPos.y < 0 | finalPos.y > Screen.height)
        {
            transform.position = originalPosition;
        }
    }
}

