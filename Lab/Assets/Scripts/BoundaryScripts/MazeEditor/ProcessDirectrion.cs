using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProcessDirectionUpdate
{
    Direction ExecuteUpdate();
    bool WasProcessDirectionChange();
    Direction GetLastCheckDirection();
    

}
public class ProcessDirectionUpdate : IProcessDirectionUpdate{

    private Direction LastCheckDirection;
    private Direction CurrentProcessDirection;

    private IMouse MouseBoundry;
    bool WasHorizontalMoveInReferenceToLastClick;

    public ProcessDirectionUpdate(IMouse _MouseBoundry)
    {
        MouseBoundry = _MouseBoundry;
    }

    public Direction GetLastCheckDirection()
    {
        return LastCheckDirection;
    }

    public Direction ExecuteUpdate()
    {
        LastCheckDirection = CurrentProcessDirection;

        WasHorizontalMoveInReferenceToLastClick = MouseBoundry.WasHorizontalMoveInReferenceToLastClick();
        CurrentProcessDirection = UpdateProcessDirection();

        return CurrentProcessDirection;
    }

    public bool WasProcessDirectionChange()
    {
        if (LastCheckDirection != CurrentProcessDirection)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    private Direction UpdateProcessDirection()
    {
        Direction processDirection;
        Vector3 currentMousePosition = MouseBoundry.GetMousePosition();
        Vector3 lastMouseClickPosition = MouseBoundry.LastMouseClickPosition;

        if (WasHorizontalMoveInReferenceToLastClick)
        {
            if (currentMousePosition.x > lastMouseClickPosition.x)
            {
                processDirection = Direction.Right;
            }
            else
            {
                processDirection = Direction.Left;
            }
        }
        else
        {
            if (currentMousePosition.y > lastMouseClickPosition.y)
            {
                processDirection = Direction.Up;
            }
            else
            {
                processDirection = Direction.Down;
            }
        }
        return processDirection;
    }
}
