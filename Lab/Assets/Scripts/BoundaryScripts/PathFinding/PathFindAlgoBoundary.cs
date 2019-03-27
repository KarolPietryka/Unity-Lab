using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum EPathFindAlgorithms
{
    DijkstraAlgorithm,
    EuclideanAStar,
    ManhattanAStar
}
public interface IMazeSpecialElementsSeeker
{
    IMazeElement FindStartPlaceForPathFinding();
    IMazeElement FindDestinationPlaceForPathFinding();
}

public class PathFindAlgoBoundary : MonoBehaviour, IMazeSpecialElementsSeeker
{
    //IMazeInOutPoints mazeInOutPointsBoundary;
    IPathFindAlgo pathFindAlgo;
    //List<IMazeElement> pathFromStartToEnd;
   // List<IMazeElement> unexploredMazeElementsList;


    [SerializeField]
    PlaneBoundry planeBuilder;
    [SerializeField]
    Dropdown pathFindDropdownUI;
    [SerializeField]
    SaveSystemBoundary saveSystemBoundary;

    PathFindProcessMetric pathFindProcessMetric;
    MazeMetric mazeMetric;


    private void Awake()
    {
        this.enabled = false;
    }


    public void PathFind()
    {
        pathFindProcessMetric = new PathFindProcessMetric();
        mazeMetric = new MazeMetric(planeBuilder);

        mazeMetric.SetMazeMetric();
        saveSystemBoundary.SaveMazeMetric(mazeMetric);

        pathFindAlgo = CreatePathFindAlgo();
        pathFindAlgo.AppointPath();

        saveSystemBoundary.SaveMetricForPathFindProcess(pathFindProcessMetric, GetPathFindMethodFromPathFindDropdown());
    }




    private IPathFindAlgo CreatePathFindAlgo()
    {
        PathfinderAlgorithmFactory pathfinderAlgorithmFactory = new PathfinderAlgorithmFactory();
        return pathfinderAlgorithmFactory.CreatePathFindAlgo(
            GetPathFindMethodFromPathFindDropdown(),
            this,
            new List<IMazeElement>(),
            planeBuilder,
             new List<IMazeElement>(),
            new List<IMazeElement>(),
            new List<IMazeElement>(),
             pathFindProcessMetric);
    }
    private EPathFindAlgorithms GetPathFindMethodFromPathFindDropdown()
    {
        PathFindDropdownBoundary pathFindDropdownBoundary = pathFindDropdownUI.GetComponent<PathFindDropdownBoundary>();
        return pathFindDropdownBoundary.GetCurrentSelectPathFindAlgorithm();
    }




    public IMazeElement FindStartPlaceForPathFinding()
    {
        return GameObject.FindGameObjectWithTag("PathFindStartNode").GetComponent<MazeElementBoundary>();
    }
    public IMazeElement FindDestinationPlaceForPathFinding()
    {
        return GameObject.FindGameObjectWithTag("PathFindDestinationNode").GetComponent<MazeElementBoundary>();
    }
}
