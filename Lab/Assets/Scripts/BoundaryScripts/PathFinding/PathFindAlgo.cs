using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPathFindAlgo
{
    void AppointPath();
}
public class PathFindAlgo : IPathFindAlgo
{
    IMazeSpecialElementsSeeker pathFindAlgoBoundary;

    List<IMazeElement> pathFromStartToEnd;
    IPathFinder pathFinder;
    IMazeElementsPathFindParametersRestarter mazeElementsPathFindParametersRestarter;


    public PathFindAlgo(IMazeSpecialElementsSeeker _pathFindAlgoBoundary, List<IMazeElement> _pathFromStartToEnd, IPathFinder _pathFinder, IMazeElementsPathFindParametersRestarter _mazeElementsPathFindParametersRestarter)
    {
        pathFindAlgoBoundary = _pathFindAlgoBoundary;
        pathFromStartToEnd = _pathFromStartToEnd;
        pathFinder = _pathFinder;
        mazeElementsPathFindParametersRestarter = _mazeElementsPathFindParametersRestarter;

    }




    public void AppointPath()
    {
        mazeElementsPathFindParametersRestarter.RestartMazeElementsParameters();
        pathFromStartToEnd = FindPath();
        PathDrawer.DrawPathFromStartToEnd(pathFindAlgoBoundary.FindDestinationPlaceForPathFinding());
    }




    private List<IMazeElement> FindPath()
    {
        return pathFinder.FindPath();
    }
}

