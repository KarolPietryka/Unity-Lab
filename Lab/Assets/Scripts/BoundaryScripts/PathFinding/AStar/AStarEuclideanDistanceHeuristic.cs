using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAStarDistanceHeuristic
{
    float GetDistanceBetween(IMazeElement currentMazeElement, IMazeElement destinationMazeElemen);
}

public class AStarEuclideanDistanceHeuristic : IAStarDistanceHeuristic
{

    public AStarEuclideanDistanceHeuristic()
    {

    }

    public float GetDistanceBetween(IMazeElement currentMazeElement, IMazeElement destinationMazeElemen)
    {
        return (currentMazeElement.Index - destinationMazeElemen.Index).magnitude;
    }

}
