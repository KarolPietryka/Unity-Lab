using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PathDrawer 
{
    public static void DrawPathFromStartToEnd(IMazeElementPathFindDrawingParameters destinationPoint)
    {
        IMazeElementPathFindDrawingParameters mazeElement = destinationPoint;
        while (mazeElement.PathFindParent != null)
        {
            mazeElement.ChangeOnPathFindColor();
            mazeElement = mazeElement.PathFindParent;
        }
        mazeElement.ChangeOnPathFindColor();
    }
}
