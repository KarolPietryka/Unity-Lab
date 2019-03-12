using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EuclideanAStarPathFinder : IPathFinder
{
    IMazeElement startMazeElement;
    IMazeElement destinationMazeElement;
    IAStarDistanceHeuristic aStarEuclideanDistanceHeuristic;
    IOpenCloseListController openCloseListController;
    INeighboursPathFindParametersProcessor neighboursPathFindParametersProcessor;
    IPlaneBuilder planeBuilder;

    bool destinationReach = false;

    public EuclideanAStarPathFinder(
        IMazeElement _startMazeElement,
        IMazeElement _destinationMazeElement,
        IOpenCloseListController _openCloseListController,
        INeighboursPathFindParametersProcessor _neighboursPathFindParametersProcessor)
    {
        startMazeElement = _startMazeElement;
        destinationMazeElement = _destinationMazeElement;
        openCloseListController = _openCloseListController;
        neighboursPathFindParametersProcessor = _neighboursPathFindParametersProcessor;
    }
    public List<IMazeElement> FindPath()
    {
        startMazeElement.PathFindWeight = 0;
        openCloseListController.AddToOpenList(startMazeElement);

        while (openCloseListController.OpenListCount() > 0 || destinationReach == true)
        {
            IMazeElement currentMazeElement = openCloseListController.GetMazeElementWithLowestWeight();

            openCloseListController.RemoveFirstElementFromOpenList(currentMazeElement);
            openCloseListController.AddToCloseList(currentMazeElement);
            
            if (currentMazeElement == destinationMazeElement)
            {
                destinationReach = true;
                continue;
            }
            currentMazeElement.Tag = "PathFindSolution";
            Debug.Log(currentMazeElement.Index);
            neighboursPathFindParametersProcessor.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController);
        }
        return DestinationPath.GetListFromStartToDestination(destinationMazeElement);
        //return new List<IMazeElement>();
    }

}