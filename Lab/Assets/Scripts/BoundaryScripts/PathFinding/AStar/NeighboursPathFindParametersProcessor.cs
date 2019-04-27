using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INeighboursPathFindParametersProcessor
{
    void ProcessNeighboursPathFindParameters(IMazeElement currentMazeElement, IOpenCloseListController openCloseListController, IPathFindProcessMetric pathFindProcessMetric);
}
public class NeighboursPathFindParametersProcessor : INeighboursPathFindParametersProcessor
{
    IPlaneBuilder planeBuilder;
    IMazeElement destinationMazeElement;
    IAStarDistanceHeuristic aStarDistanceHeuristic;

    public NeighboursPathFindParametersProcessor(IPlaneBuilder _planeBuilder, 
        IMazeElement _destinationMazeElement, 
        IAStarDistanceHeuristic _aStarDistanceHeuristic)
    {
        planeBuilder = _planeBuilder;
        destinationMazeElement = _destinationMazeElement;
        aStarDistanceHeuristic = _aStarDistanceHeuristic;

    }

    public void ProcessNeighboursPathFindParameters(
        IMazeElement currentMazeElement, 
        IOpenCloseListController openCloseListController,
        IPathFindProcessMetric pathFindProcessMetric
        )
    {
        List<IMazeElement> neighbourMazeElementList = planeBuilder.GetNeighboursOfMazeElement(currentMazeElement);

        foreach (IMazeElement neighbourMazeElement in neighbourMazeElementList)
        {
            if (!openCloseListController.CloseListContains(neighbourMazeElement) && !neighbourMazeElement.IsMazeWall)
            {
                int discanceToNeighbour = 1;
                float newNeighbourWeight = currentMazeElement.PathFindWeight + discanceToNeighbour;

                if  (newNeighbourWeight < neighbourMazeElement.PathFindWeight || !openCloseListController.OpenListContains(neighbourMazeElement))
                    //(openCloseListController.OpenListContains(neighbourMazeElement) && neighbourMazeElement.PathFindWeight < newNeighbourWeight) //||
                    //openCloseListController.CloseListContains(neighbourMazeElement) && neighbourMazeElement.PathFindWeight < newNeighbourWeight)
                {
                    neighbourMazeElement.PathFindWeight = newNeighbourWeight;
                    neighbourMazeElement.PathFindDistanceHeuristic = aStarDistanceHeuristic.GetDistanceBetween(neighbourMazeElement, destinationMazeElement);
                    neighbourMazeElement.PathFindParent = currentMazeElement;

                    if (!openCloseListController.OpenListContains(neighbourMazeElement))
                    {
                        openCloseListController.AddToOpenList(neighbourMazeElement);
                    }
                }
            }
        }
        pathFindProcessMetric.ProcessJunctionParametersBaseOn(neighbourMazeElementList);
    }
}
