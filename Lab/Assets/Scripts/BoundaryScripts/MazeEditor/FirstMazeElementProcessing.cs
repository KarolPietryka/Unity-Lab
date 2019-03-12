using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IFirstMazeElementProcessing
{
    void Execute();
    bool GetIsMazeWallForRootAfterCurrentProcess();
}
public class FirstMazeElementProcessing : IFirstMazeElementProcessing{

    private IMouse MouseBoundry;

    public FirstMazeElementProcessing(IMouse mouseBoundry)
    {
        MouseBoundry = mouseBoundry;
    }

    public void Execute()
    {
        MouseBoundry.LastMouseClickPosition = MouseBoundry.GetMousePosition();
        MouseBoundry.LastMouseClickMazeElement = MouseBoundry.CurrentMouseOnMazeElement;
        MouseBoundry.CurrentMouseOnMazeElement.ChangeOnNormalScale();
        MouseBoundry.CurrentMouseOnMazeElement.ChangeOnMazeWallColor();
    }

    public bool GetIsMazeWallForRootAfterCurrentProcess()
    {
        return ! MouseBoundry.GetCurrentMouseOnMazeElementIsMazeElement();
    }

}
