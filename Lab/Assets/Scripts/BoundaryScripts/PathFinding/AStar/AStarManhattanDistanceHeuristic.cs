using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AStarManhattanDistanceHeuristic : IAStarDistanceHeuristic
{
    public float GetDistanceBetween(IMazeElement currentMazeElement, IMazeElement destinationMazeElemen)
    {
        return Mathf.Abs(currentMazeElement.Index.x - destinationMazeElemen.Index.x) + Mathf.Abs(currentMazeElement.Index.y - destinationMazeElemen.Index.y);
    }
}
