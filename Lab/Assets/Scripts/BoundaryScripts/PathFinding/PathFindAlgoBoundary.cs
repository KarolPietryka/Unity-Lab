using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public enum EPathFindAlgorithms
{
    DijkstraAlgorithm,
    EuclideanAStar
}
public interface IPathFindAlgoBoundary
{
    IMazeElement FindStartPlaceForPathFinding();
    IMazeElement FindDestinationPlaceForPathFinding();
}

public class PathFindAlgoBoundary : MonoBehaviour, IPathFindAlgoBoundary{

    IPathFindAlgo pathFindAlgo;
    List<IMazeElement> pathFromStartToEnd;
    List<IMazeElement> unexploredMazeElementsList;

    List<IMazeElement> openList;
    List<IMazeElement> closeList;

    [SerializeField]
    PlaneBoundry planeBuilder;
    [SerializeField]
    Dropdown pathFindDropdownUI;

    private void Awake()
    {
        pathFromStartToEnd = new List<IMazeElement>();
        unexploredMazeElementsList = new List<IMazeElement>(); //GetComponent<MazeEditorBoundary>().unexploredWalkableMazeElementsList;
        openList = new List<IMazeElement>();
        closeList = new List<IMazeElement>();
        this.enabled = false;
    }
    private void Start()
    {
        //unexploredMazeElementsList = transform.GetComponentInParent<MazeEditorBoundary>().unexploredWalkableMazeElementsList;

    }

    public void PathFind()
    {
        pathFindAlgo = CreatePathFindAlgo();
        pathFindAlgo.AppointPath();
    }




    private IPathFindAlgo CreatePathFindAlgo()
    {
        PathfinderAlgorithmFactory pathfinderAlgorithmFactory = new PathfinderAlgorithmFactory();
        return pathfinderAlgorithmFactory.CreatePathFindAlgo(
            GetPathFindMethodFromPathFindDropdown(),
            this,
            pathFromStartToEnd,
            planeBuilder,
            unexploredMazeElementsList,
            openList,
            closeList);
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
