using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPathFindAlgo
{
    void AppointPath();
}
public class PathFindAlgo : IPathFindAlgo
{
    IPathFindAlgoBoundary pathFindAlgoBoundary;

    List<IMazeElement> pathFromStartToEnd;
    IPathFinder pathFinder;
    IMazeElementsParametersRestarter mazeElementsParametersRestarter;


    public PathFindAlgo(IPathFindAlgoBoundary _pathFindAlgoBoundary, List<IMazeElement> _pathFromStartToEnd, IPathFinder _pathFinder, IMazeElementsParametersRestarter _mazeElementsParametersRestarter)
    {
        pathFindAlgoBoundary = _pathFindAlgoBoundary;
        pathFromStartToEnd = _pathFromStartToEnd;
        pathFinder = _pathFinder;
        mazeElementsParametersRestarter = _mazeElementsParametersRestarter;

    }




    public void AppointPath()
    {
        mazeElementsParametersRestarter.RestartMazeElementsParameters();
        pathFromStartToEnd = FindPath();
        PathDrawer.DrawPathFromStartToEnd(pathFindAlgoBoundary.FindDestinationPlaceForPathFinding());

    }




    private List<IMazeElement> FindPath()
    {
        return pathFinder.FindPath();
    }
}

