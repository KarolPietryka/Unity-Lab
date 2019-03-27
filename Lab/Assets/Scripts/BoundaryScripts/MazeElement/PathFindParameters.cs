using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPathFindingParameters
{
    void ResetPathFindingParameters();
    IMazeElement PathFindParent { get; set; }
    float Weight { get; set; }
    float DistanceHeuristic { get; set; }
}

public class PathFindParameters : IPathFindingParameters
{
    public IMazeElement PathFindParent { get; set; }
    public float Weight { get; set; }
    public float DistanceHeuristic { get; set; }

    public void ResetPathFindingParameters()
    {
        Weight = int.MaxValue;
        DistanceHeuristic = int.MaxValue;
        PathFindParent = null;
    }
}
