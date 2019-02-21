using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectionOfVectors{

    public static bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(IFarthestMazeElement farthestMazeElement, IMouse Mouse, Direction processDirection)
    {
        bool ret =  false;
        if (processDirection == Direction.Left || processDirection == Direction.Right)
        {
            Vector2 projectionOfCurrentMazeElementOnHorizontalMazeWall = new Vector2(Mouse.GetCurrentMouseOnMazeElementIndex().x, farthestMazeElement.CurrentFarthestMazeElementIndex.y);
            if (projectionOfCurrentMazeElementOnHorizontalMazeWall == farthestMazeElement.CurrentFarthestMazeElementIndex)
            {
                ret = true;
            }
        }
        else
        {
            Vector2 projectionOfCurrentMazeElementOnVerticalMazeWall = new Vector2(farthestMazeElement.CurrentFarthestMazeElementIndex.x, Mouse.GetCurrentMouseOnMazeElementIndex().y);
            if (projectionOfCurrentMazeElementOnVerticalMazeWall == farthestMazeElement.CurrentFarthestMazeElementIndex)
            {
                ret = true;
            }
        }
        return ret;
    }
}
