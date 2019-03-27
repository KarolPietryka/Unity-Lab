using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeMetric
{
    void SetMazeMetric();
}
public interface IMazeMetricCollector
{
    int TotalNumberOfNodes { get; }
    int TotalNumberOfWalkableNodes { get; }
    int TotalNumberOfJunctions { get; }
    int TotalNumberOfThreeWayJunctions { get; }
    int TotalNumberOfFourWayJunctions { get; }
    int TotalNumberOfDeadEnds { get; }
    int TotalNumberOfHallwayNodes { get; }
}

public interface IMazeMetricController : IUniversalMetric, IMazeMetricCollector
{
    void IncreaseNumberOfNodes();
    void IncreaseNumberOfWalkableNodes();
}

public class MazeMetric : IMazeMetric, IMazeMetricCollector, IMazeMetricController
{

    IPlaneBuilder planeBuilder;

    private int totalNumberOfNodes;
    private int totalNumberOfWalkableNodes;
    private int totalNumberOfThreeWayJunctions;
    private int totalNumberOfFourWayJunctions;
    private int totalNumberOfDeadEnds;
    private int totalNumberOfHallwayNodes;

    public MazeMetric(IPlaneBuilder _planeBuilder)
    {
        planeBuilder = _planeBuilder;
    }

    public void SetMazeMetric()
    {
        for (int i = 0; i < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.x; i++)
        {
            for (int j = 0; j < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.y; j++)
            {
                IncreaseNumberOfNodes();

                IMazeElement currentMazeElement = planeBuilder.GetFromMazeArray(i, j);

                if (!currentMazeElement.IsMazeWall)
                {
                    IncreaseNumberOfWalkableNodes();
                    List<IMazeElement> neighbourMazeElementList = planeBuilder.GetNeighboursOfMazeElement(currentMazeElement);
                    ProcessJunctionParametersBaseOn(neighbourMazeElementList);
                }
            }
        }
    }

    public int TotalNumberOfNodes { get { return totalNumberOfNodes; } }
    public int TotalNumberOfWalkableNodes { get { return totalNumberOfWalkableNodes; } }
    public int TotalNumberOfJunctions { get { return totalNumberOfFourWayJunctions + totalNumberOfThreeWayJunctions; } }
    public int TotalNumberOfThreeWayJunctions { get { return totalNumberOfThreeWayJunctions; } }
    public int TotalNumberOfFourWayJunctions { get { return totalNumberOfFourWayJunctions; } }
    public int TotalNumberOfDeadEnds { get { return totalNumberOfDeadEnds; } }
    public int TotalNumberOfHallwayNodes { get { return totalNumberOfHallwayNodes; } }

    public void IncreaseNumberOfThreeWayJunctions()
    {
        totalNumberOfThreeWayJunctions++;
    }
    public void IncreaseNumberOfFourWayJunctions()
    {
        totalNumberOfFourWayJunctions++;
    }
    public void IncreaseNumberOfDeadEnds()
    {
        totalNumberOfDeadEnds++;
    }
    public void IncreaseNumberOfHallwayNodes()
    {
        totalNumberOfHallwayNodes++;
    }
    public void IncreaseNumberOfNodes()
    {
        totalNumberOfNodes++;
    }
    public void IncreaseNumberOfWalkableNodes()
    {
        totalNumberOfWalkableNodes++;
    }
    public void ProcessJunctionParametersBaseOn(List<IMazeElement> neighbourMazeElementList)
    {
        Junctions.ProcessJunctionParametersBaseOn(this, neighbourMazeElementList);
    }

}