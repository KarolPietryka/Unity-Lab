using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class DestinationPath {

    public static List<IMazeElement> GetListFromStartToDestination(IMazeElement destinationPoint)
    {
        List<IMazeElement> pathFromStartToEnd = new List<IMazeElement>();
        IMazeElement mazeElement = destinationPoint;
        while (mazeElement.PathFindParent != null)
        {
            pathFromStartToEnd.Add(mazeElement);
            mazeElement = mazeElement.PathFindParent;
        }
        pathFromStartToEnd.Reverse();
        return pathFromStartToEnd;
    }
}
