using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INeighboursPathFindParametersProcessor
{
    void ProcessNeighboursPathFindParameters(IMazeElement currentMazeElement, IOpenCloseListController openCloseListController);
}
public class NeighboursPathFindParametersProcessor : INeighboursPathFindParametersProcessor
{
    IPlaneBuilder planeBuilder;
    IMazeElement destinationMazeElement;
    IAStarDistanceHeuristic aStarEuclideanDistanceHeuristic;

    public NeighboursPathFindParametersProcessor(IPlaneBuilder _planeBuilder, IMazeElement _destinationMazeElement, IAStarDistanceHeuristic _aStarEuclideanDistanceHeuristic)
    {
        planeBuilder = _planeBuilder;
        destinationMazeElement = _destinationMazeElement;
        aStarEuclideanDistanceHeuristic = _aStarEuclideanDistanceHeuristic;

    }

    public void ProcessNeighboursPathFindParameters(
        IMazeElement currentMazeElement, 
        IOpenCloseListController openCloseListController
        )
    {
        List<IMazeElement> neighbourMazeElementList = planeBuilder.GetNeighboursOfMazeElement(currentMazeElement);

        Debug.Log(neighbourMazeElementList.Count);
        foreach (IMazeElement neighbourMazeElement in neighbourMazeElementList)
        {
            //Debug.Log(neighbourMazeElement.Index);
            if (!openCloseListController.CloseListContains(neighbourMazeElement))
            {
                //Debug.Log("openCloseListController do not contain neighbour with index " + neighbourMazeElement.Index);
                int discanceToNeighbour = 1;
                float newNeighbourWeight = currentMazeElement.PathFindWeight + discanceToNeighbour;
               // Debug.Log("currentMazeElement.PathFindWeight " + currentMazeElement.PathFindWeight);
               // Debug.Log("aStarWeightHeuristic.GetDistanceBetween(currentMazeElement, destinationMazeElement) " + aStarEuclideanDistanceHeuristic.GetDistanceBetween(currentMazeElement, destinationMazeElement));
               // Debug.Log("newNeighbourWeight " + newNeighbourWeight);
                if  (newNeighbourWeight < neighbourMazeElement.PathFindWeight || !openCloseListController.OpenListContains(neighbourMazeElement))
                    //(openCloseListController.OpenListContains(neighbourMazeElement) && neighbourMazeElement.PathFindWeight < newNeighbourWeight) //||
                    //openCloseListController.CloseListContains(neighbourMazeElement) && neighbourMazeElement.PathFindWeight < newNeighbourWeight)
                {
                   // Debug.Log("I set new weight and Parent");

                    neighbourMazeElement.PathFindWeight = newNeighbourWeight;
                    neighbourMazeElement.PathFindDistanceHeuristic = aStarEuclideanDistanceHeuristic.GetDistanceBetween(neighbourMazeElement, destinationMazeElement);
                    neighbourMazeElement.PathFindParent = currentMazeElement;

                    if (!openCloseListController.OpenListContains(neighbourMazeElement))
                    {
                        openCloseListController.AddToOpenList(neighbourMazeElement);
                    }
                }
            }
        }
    }
}
