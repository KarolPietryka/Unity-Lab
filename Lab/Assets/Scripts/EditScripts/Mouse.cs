using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse
{
    public float mouseupperScrollLimit;

    private IMousePositionProvider mousePositionProvider;
    private float instantiantionAreaSideX;
    private float instantiantionAreaSideY;
    private Vector3 gamePlaneCenter;

    public Mouse(IMousePositionProvider _mousePositionProvider, 
        Bounds _gamePlaneBounds, 
        Bounds _mazeElementBounds, 
        float _mouseUpperScrollLimit)
    {

        mousePositionProvider = _mousePositionProvider;
        gamePlaneCenter = _gamePlaneBounds.center;

        instantiantionAreaSideX = (_gamePlaneBounds.extents.x - _mazeElementBounds.extents.x) * 2;
        instantiantionAreaSideY = (_gamePlaneBounds.extents.y - _mazeElementBounds.extents.y) * 2;

        mouseupperScrollLimit = _mouseUpperScrollLimit;
    }

    public bool InInstantiationArea()
    {
        Vector3 mousePositionInWorldSpace = mousePositionProvider.GetMousePositionInWorldSpace();

        Bounds gamePlaneBounds = new Bounds(gamePlaneCenter, new Vector3(instantiantionAreaSideX, instantiantionAreaSideY, mouseupperScrollLimit));
        
        if (gamePlaneBounds.Contains(mousePositionInWorldSpace))
        {
            return true;
        }
        return false;
    }

}

