using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPathFindProcessMetric: IJunctionMetric
{
    void IncreaseNumberOfVisitedNodes();
    void SetPathLengthExpressedInNumberOfNodes(int numberOfNodesInFoundPath);
}
public interface IJunctionMetric
{
    void ProcessJunctionParametersBaseOn(List<IMazeElement> neighbourMazeElementList);
}
public interface IPathFindProcessMetricCollector
{
    int NumberOfVisitedNodes { get; }
    int NumberOfVisitedJunctions { get; }
    int NumberOfVisitedThreeWayJunctions { get; }
    int NumberOfVisitedFourWayJunctions { get; }
    int NumberOfVisitedDeadEnds { get; }
    int NumberOfVisitedHallwayNodes { get; }
    int PathLengthExpressedInNumberOfNodes { get; }
}
public interface IUniversalMetric: IJunctionMetric
{
    void IncreaseNumberOfThreeWayJunctions();
    void IncreaseNumberOfFourWayJunctions();
    void IncreaseNumberOfDeadEnds();
    void IncreaseNumberOfHallwayNodes();
}

public class PathFindProcessMetric : IPathFindProcessMetric, IUniversalMetric, IPathFindProcessMetricCollector
{
    private int numberOfVisitedNodes;
    private int numberOfVisitedThreeWayJunctions;
    private int numberOfVisitedFourWayJunctions;
    private int numberOfVisitedDeadEnds;
    private int numberOfVisitedHallwayNodes;
    private int pathLengthExpressedInNumberOfNodes;

    public int NumberOfVisitedNodes { get { return numberOfVisitedNodes; } }
    public int NumberOfVisitedJunctions { get { return numberOfVisitedFourWayJunctions + numberOfVisitedThreeWayJunctions; } }
    public int NumberOfVisitedThreeWayJunctions { get { return numberOfVisitedThreeWayJunctions; } }
    public int NumberOfVisitedFourWayJunctions { get { return numberOfVisitedFourWayJunctions; } }
    public int NumberOfVisitedDeadEnds { get { return numberOfVisitedDeadEnds; } }
    public int NumberOfVisitedHallwayNodes { get { return numberOfVisitedHallwayNodes; } }
    public int PathLengthExpressedInNumberOfNodes { get { return pathLengthExpressedInNumberOfNodes; } }


    public void IncreaseNumberOfVisitedNodes()
    {
        numberOfVisitedNodes++;
    }
    public void IncreaseNumberOfThreeWayJunctions()
    {
        numberOfVisitedThreeWayJunctions++;
    }
    public void IncreaseNumberOfFourWayJunctions()
    {
        numberOfVisitedFourWayJunctions++;
    }
    public void IncreaseNumberOfDeadEnds()
    {
        numberOfVisitedDeadEnds++;
    }
    public void IncreaseNumberOfHallwayNodes()
    {
        numberOfVisitedHallwayNodes++;
    }

    public void ProcessJunctionParametersBaseOn(List<IMazeElement> neighbourMazeElementList)
    {
        Junctions.ProcessJunctionParametersBaseOn(this, neighbourMazeElementList);
    }

    public void SetPathLengthExpressedInNumberOfNodes(int numberOfNodesInFoundPath)
    {
        pathLengthExpressedInNumberOfNodes = numberOfNodesInFoundPath;
    }
}
