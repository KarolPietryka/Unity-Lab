using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : IMouse
{
    private MazeElementBoundary currentMouseOnMazeElement;
    public MazeElementBoundary CurrentMouseOnMazeElement
    {
        get { return currentMouseOnMazeElement; }
        set
        {
            currentMouseOnMazeElement = value;
            if (value != null)
            {
                CurrentMouseOnMazeElementHadBeenChanged = true;
            }
        }
    }
    public Vector3 LastMouseClickPosition { get; set; }
    public bool CurrentMouseOnMazeElementHadBeenChanged { get; set; }


    public Vector2 CurrentMouseOnMazeElementIndex()
    {
        return CurrentMouseOnMazeElement.Index;
    }

    public void UpdateLastMouseClickPosition(Vector3 newLastMouseClickPosition)
    {
        LastMouseClickPosition = newLastMouseClickPosition;
    }

    public bool WasHorizontalMoveInReferenceToLastClick(Vector3 mousePosition)
    {
        bool ret;
        Vector3 currentMousePosition = mousePosition;
        Vector3 lastMouseClickPosition = LastMouseClickPosition;

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

    /*public bool InGamePlaneArea()
    {
        Vector3 mousePositionInWorldSpace = GetMousePositionInWorldSpace();

        Bounds gamePlaneBounds = new Bounds(gamePlaneCenter, new Vector3(instantiantionAreaSideX, instantiantionAreaSideY, mouseupperScrollLimit));

        if (gamePlaneBounds.Contains(mousePositionInWorldSpace))
        {
            return true;
        }
        return false;
    }*/

}


