using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeInOutPoints
{
    void SetInOutPoints();
}
public class MazeInOutPoints : IMazeInOutPoints {

    IMouse mouseBoundary;
    IInputMouseButtons inputMouseButtons;


    bool pathFindStartPointIsAlreadySet;
    bool pathFindEndPointIsAlreadySet;

    public MazeInOutPoints(IMouse _mouseBoundary, IInputMouseButtons _inputMouseButtons)
    {
        mouseBoundary = _mouseBoundary;
        inputMouseButtons = _inputMouseButtons;

    }

    public void SetInOutPoints()
    {

        if (inputMouseButtons.GetMouseButtonDown(1) && mouseBoundary.CurrentMouseOnMazeElement != null)
        {
            if (mouseBoundary.CurrentMouseOnMazeElement.tag != "PathFindStartNode" && mouseBoundary.CurrentMouseOnMazeElement.tag != "PathFindDestinationNode" && !pathFindStartPointIsAlreadySet)
            {
                mouseBoundary.CurrentMouseOnMazeElement.tag = "PathFindStartNode";
                pathFindStartPointIsAlreadySet = true;
                mouseBoundary.CurrentMouseOnMazeElement.ChangeOnMazeStartPointColor();
            }
            else if (mouseBoundary.CurrentMouseOnMazeElement.tag != "PathFindStartNode" && mouseBoundary.CurrentMouseOnMazeElement.tag != "PathFindDestinationNode" && pathFindStartPointIsAlreadySet && !pathFindEndPointIsAlreadySet)
            {
                mouseBoundary.CurrentMouseOnMazeElement.tag = "PathFindDestinationNode";
                pathFindEndPointIsAlreadySet = true;
                mouseBoundary.CurrentMouseOnMazeElement.ChangeOnMazeEndPointColor();
            }
            else if (mouseBoundary.CurrentMouseOnMazeElement.tag == "PathFindStartNode")
            {
                mouseBoundary.CurrentMouseOnMazeElement.tag = "MazeElement";
                pathFindStartPointIsAlreadySet = false;
                mouseBoundary.CurrentMouseOnMazeElement.ChangeOnNormalColor();
            }
            else if (mouseBoundary.CurrentMouseOnMazeElement.tag == "PathFindDestinationNode")
            {
                mouseBoundary.CurrentMouseOnMazeElement.tag = "MazeElement";
                pathFindEndPointIsAlreadySet = false;
                mouseBoundary.CurrentMouseOnMazeElement.ChangeOnNormalColor();
            }
        }
    }
}
