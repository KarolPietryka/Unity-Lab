using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MazeInOutPoints : IMazeInOutPoints {

    private IMouse mouseBoundary;
    private IInputMouseButtons inputMouseButtons;

    IMazeInOutController mazeInOutController;

    public MazeInOutPoints(IMouse _mouseBoundary, IInputMouseButtons _inputMouseButtons, IMazeInOutController _mazeInOutController)
    {
        mouseBoundary = _mouseBoundary;
        inputMouseButtons = _inputMouseButtons;
        mazeInOutController = _mazeInOutController;
    }


    public void SetInOutPoints()
    {
        if (inputMouseButtons.GetMouseButtonDown(1) && mouseBoundary.CurrentMouseOnMazeElement != null)
        {
            if (mouseBoundary.CurrentMouseOnMazeElement.tag != "PathFindStartNode" && mouseBoundary.CurrentMouseOnMazeElement.tag != "PathFindDestinationNode" && !mazeInOutController.IsPathFindStartPointAlreadySet())
            {
                mazeInOutController.SetInPoint(mouseBoundary.CurrentMouseOnMazeElement);
            }
            else if (mouseBoundary.CurrentMouseOnMazeElement.tag != "PathFindStartNode" &&
                mouseBoundary.CurrentMouseOnMazeElement.tag != "PathFindDestinationNode" &&
                mazeInOutController.IsPathFindStartPointAlreadySet() && 
                !mazeInOutController.IsPathFindEndPointAlreadySet())
            {
                mazeInOutController.SetOutPoint(mouseBoundary.CurrentMouseOnMazeElement);
            }
            else if (mouseBoundary.CurrentMouseOnMazeElement.tag == "PathFindStartNode")
            {
                mazeInOutController.RemoveInPoint();
            }
            else if (mouseBoundary.CurrentMouseOnMazeElement.tag == "PathFindDestinationNode")
            {
                mazeInOutController.RemoveEndPoint();
            }
        }
    }
    
    public void RemoveInOutPoints()
    {
        mazeInOutController.RemoveInOutPoints();
    }
    
    public void SetInOutPointsAt(IMazeElement inPoint, IMazeElement outPoint)
    {
        mazeInOutController.SetInPoint(inPoint);
        mazeInOutController.SetOutPoint(outPoint);
    }

   
}
