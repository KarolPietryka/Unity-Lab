using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMousePosition
{
    //Vector2 MousePosition { set; }
}
public interface IFirstMazeElementProcessing : IMousePosition
{
    void Execute();
    bool GetNewIsMazeWallForRoot();
}
public class FirstMazeElementProcessing : IFirstMazeElementProcessing{

    private IMouse MouseBoundry;
   // private Vector2 mousePosition;
    //public Vector2 MousePosition { set { mousePosition = value; } }

    public FirstMazeElementProcessing(IMouse mouseBoundry)
    {
        MouseBoundry = mouseBoundry;
    }

    public void Execute()
    {
        MouseBoundry.LastMouseClickPosition = MouseBoundry.GetMousePosition();
        MouseBoundry.LastMouseClickMazeElement = MouseBoundry.CurrentMouseOnMazeElement;
       // MouseBoundry.CurrentMouseOnMazeElement.ReverseIsMazeWall();
        MouseBoundry.CurrentMouseOnMazeElement.ChangeOnNormalScale();
        MouseBoundry.CurrentMouseOnMazeElement.ChangeOnMazeWallColor();
    }

    public bool GetNewIsMazeWallForRoot()
    {
        return !MouseBoundry.GetCurrentMouseOnMazeElementIsMazeElement();
    }

}
