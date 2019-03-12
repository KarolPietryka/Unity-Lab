using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPathFinder
{
    List<IMazeElement> FindPath();
}
public class DijkstraPathFinder : IPathFinder
{
    IPlaneBuilder planeBuilder;
    IUnexploredMazeElements unexploredMazeElements;
    IMazeElement startMazeElement;
    IMazeElement destinationMazeElement;

    public DijkstraPathFinder(IPlaneBuilder _planeBuilder, IUnexploredMazeElements _unexploredMazeElements, IMazeElement _startMazeElement, IMazeElement _destinationMazeElement)
    {
        planeBuilder = _planeBuilder;
        unexploredMazeElements = _unexploredMazeElements;
  
        startMazeElement = _startMazeElement;
        destinationMazeElement = _destinationMazeElement;
    }



    public List<IMazeElement> FindPath()
    {
        //double startTime = Time.realtimeSinceStartup;
        List<IMazeElement> unexploredWalkableMazeElementsList = unexploredMazeElements.GetUnexploredList();
        bool destinationReach = false;
        startMazeElement.PathFindWeight = 0;

        while (unexploredWalkableMazeElementsList.Count > 0 && destinationReach == false) 
        {
            unexploredWalkableMazeElementsList.Sort((x, y) => x.PathFindWeight.CompareTo(y.PathFindWeight));

            IMazeElement currentMazeElement = unexploredWalkableMazeElementsList[0];
            if (currentMazeElement == destinationMazeElement)
            {
                destinationReach = true;
                continue;
            }
            unexploredWalkableMazeElementsList.Remove(currentMazeElement);

            List<IMazeElement> neighbourMazeElementList = planeBuilder.GetNeighboursOfMazeElement(currentMazeElement);

            ProcessNeighboursPathFindParameters(neighbourMazeElementList, unexploredWalkableMazeElementsList, currentMazeElement);
        }
        //double endTime = Time.realtimeSinceStartup - startTime;

        return DestinationPath.GetListFromStartToDestination(destinationMazeElement);
    }




    private void ProcessNeighboursPathFindParameters(List<IMazeElement> neighbourMazeElementList, List<IMazeElement> unexploredWalkableMazeElementsList, IMazeElement currentMazeElement)
    {
        foreach (IMazeElement neighbourMazeElement in neighbourMazeElementList)
        {
            if (unexploredWalkableMazeElementsList.Contains(neighbourMazeElement))
            {
                int discanceToNeighbour = 1;
                float distance = currentMazeElement.PathFindWeight + discanceToNeighbour;

                if (distance < neighbourMazeElement.PathFindWeight)
                {
                    neighbourMazeElement.PathFindWeight = distance;
                    neighbourMazeElement.PathFindParent = currentMazeElement;
                    currentMazeElement.Tag = "PathFindSolution";
                }
            }
        }
    }
}



