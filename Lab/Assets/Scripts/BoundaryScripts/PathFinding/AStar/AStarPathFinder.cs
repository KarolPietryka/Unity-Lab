using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class AStarPathFinder : IPathFinder
{
    IMazeElement startMazeElement;
    IMazeElement destinationMazeElement;
    IOpenCloseListController openCloseListController;
    INeighboursPathFindParametersProcessor neighboursPathFindParametersProcessor;
    IPathFindProcessMetric pathFindProcessMetric;


    bool destinationReach = false;

    public AStarPathFinder(
        IMazeElement _startMazeElement,
        IMazeElement _destinationMazeElement,
        IOpenCloseListController _openCloseListController,
        INeighboursPathFindParametersProcessor _neighboursPathFindParametersProcessor,
        IPathFindProcessMetric _pathFindProcessMetric)
    {
        startMazeElement = _startMazeElement;
        destinationMazeElement = _destinationMazeElement;
        openCloseListController = _openCloseListController;
        neighboursPathFindParametersProcessor = _neighboursPathFindParametersProcessor;
        pathFindProcessMetric = _pathFindProcessMetric;
    }
    public List<IMazeElement> FindPath()
    {
        startMazeElement.PathFindWeight = 0;
        openCloseListController.AddToOpenList(startMazeElement);

        while (openCloseListController.OpenListCount() > 0 && destinationReach == false)
        {
            IMazeElement currentMazeElement = openCloseListController.GetMazeElementWithLowestWeight();

            openCloseListController.RemoveFirstElementFromOpenList(currentMazeElement);
            openCloseListController.AddToCloseList(currentMazeElement);

            pathFindProcessMetric.IncreaseNumberOfVisitedNodes();
            if (currentMazeElement == destinationMazeElement)
            {
                destinationReach = true;
                continue;
            }
            currentMazeElement.Tag = "PathFindSolution";

            neighboursPathFindParametersProcessor.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController, pathFindProcessMetric);
        }
        List<IMazeElement> listFromStartToDestination = DestinationPath.GetListFromStartToDestination(destinationMazeElement);
        pathFindProcessMetric.SetPathLengthExpressedInNumberOfNodes(listFromStartToDestination.Count);

        return listFromStartToDestination;
    }

}