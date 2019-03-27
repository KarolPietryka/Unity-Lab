using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeInOutController
{
    void RemoveInOutPoints();
    void SetInOutPointsAt(IMazeElement inPoint, IMazeElement outPoint);

    void SetInPoint(IMazeElement mazeElement);
    void SetOutPoint(IMazeElement mazeElement);
    void RemoveInPoint();
    void RemoveEndPoint();

    bool IsPathFindStartPointAlreadySet();
    bool IsPathFindEndPointAlreadySet();

}
public class MazeInOutPointsController : IMazeInOutController
{
    private bool pathFindStartPointIsAlreadySet;
    private bool pathFindEndPointIsAlreadySet;
    private IMazeElement startPoint;
    private IMazeElement endPoint;

    public void RemoveInOutPoints()
    {
        RemoveInPoint();

        RemoveEndPoint();
    }

    public void SetInOutPointsAt(IMazeElement inPoint, IMazeElement outPoint)
    {
        SetInPoint(inPoint);
        SetOutPoint(outPoint);
    }

    public bool IsPathFindStartPointAlreadySet()
    {
        return pathFindStartPointIsAlreadySet;
    }
    public bool IsPathFindEndPointAlreadySet()
    {
        return pathFindEndPointIsAlreadySet;
    }

    public void SetInPoint(IMazeElement mazeElement)
    {
        startPoint = mazeElement;
        mazeElement.Tag = "PathFindStartNode";
        pathFindStartPointIsAlreadySet = true;
        mazeElement.ChangeOnMazeStartPointColor();
    }
    public void SetOutPoint(IMazeElement mazeElement)
    {
        endPoint = mazeElement;
        mazeElement.Tag = "PathFindDestinationNode";
        pathFindEndPointIsAlreadySet = true;
        mazeElement.ChangeOnMazeEndPointColor();
    }
    public void RemoveInPoint()
    {
        if (startPoint != null)
        {
            startPoint.Tag = "MazeElement";
            pathFindStartPointIsAlreadySet = false;
            startPoint.ChangeOnNormalColor();
            startPoint = null;

        }
    }
    public void RemoveEndPoint()
    {
        if (endPoint != null)
        {
            endPoint.Tag = "MazeElement";
            pathFindEndPointIsAlreadySet = false;
            endPoint.ChangeOnNormalColor();
            endPoint = null;
        }
    }
}
