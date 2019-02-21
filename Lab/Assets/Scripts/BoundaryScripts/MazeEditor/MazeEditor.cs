using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeEditor
{
    void Update();
}
public class MazeEditor : IMazeEditor{ 
   
    private IMazeElementProcessing mazeElementProcessing;
    private IMouse Mouse;
    private IInputMouseButtons inputButtons;

    public MazeEditor(IMazeElementProcessing _mazeElementProcessing, IMouse _mouse, IInputMouseButtons _inputButtons)
    {
        mazeElementProcessing = _mazeElementProcessing;
        Mouse = _mouse;
        inputButtons = _inputButtons;
    }

    public void Update()
    {
        if (inputButtons.GetMouseButtonDown(0) && Mouse.CurrentMouseOnMazeElement != null)
        {
            mazeElementProcessing.FirstMazeElementBuildProcess();
        }
        else if (inputButtons.GetMouseButton(0) && Mouse.CurrentMouseOnMazeElement != null)
        {
            mazeElementProcessing.MazeElementInLineProcessing();
            // if (currentMouseOnMazeElement.Equals(NextPossibleMazeElementsToProcess[0]) || currentMouseOnMazeElement.Equals(NextPossibleMazeElementsToProcess[1]))//current have hanged and now it is one of nextMazeElements
            // {
            // gameMaster.ProcessNextMazeElement();
            //  }
            //NextPossibleMazeElementsToProcess = GamePlane.GetComponent<PlaneBoundry>().NextPossibleMazeElementsToProcess(buildingDirection, Mouse.CurrentMouseOnMazeElement);
        }
        else if (inputButtons.GetMouseButtonUp(0))
        {
            mazeElementProcessing.MazeElementsFinalProcess();
        }
    }

}
