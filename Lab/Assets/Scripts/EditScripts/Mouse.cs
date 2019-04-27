using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseLogic
{
    bool CurrentMouseOnMazeElementHadBeenChanged { get; set; }// DEL ?
    bool WasHorizontalMoveInReferenceToLastClick(Vector3 mousePosition);
}

public class Mouse : IMouseLogic
{
    private IMouse MouseBoundry;
    public bool CurrentMouseOnMazeElementHadBeenChanged { get; set; }

    public Mouse(IMouse mouseBoundry)
    {
        MouseBoundry = mouseBoundry;  
    }

    public bool WasHorizontalMoveInReferenceToLastClick(Vector3 mousePosition)
    {
        bool ret;
        Vector3 currentMousePosition = mousePosition;
        Vector3 lastMouseClickPosition = MouseBoundry.LastMouseClickPosition;

        if (Mathf.Abs(currentMousePosition.x - lastMouseClickPosition.x) >= Mathf.Abs(currentMousePosition.y - lastMouseClickPosition.y))
        {
            ret = true;
        }
        else
        {
            ret = false;
        }
        return ret;
    }

    public Vector3 GetMousePositionInWorldSpace(float zAxisOfObject)
    {
        Vector3 mouseInputPosition = Input.mousePosition;
        mouseInputPosition.z = zAxisOfObject;
        return Camera.main.ScreenToWorldPoint(mouseInputPosition);
    }

}


