using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderAlgorithmFactory  {

    public virtual IPathFindAlgo CreatePathFindAlgo(
        EPathFindAlgorithms ePathFindAlgorithm,
        IMazeSpecialElementsSeeker pathFindAlgoBoundary,
        List<IMazeElement> pathFromStartToEnd,
        IPlaneBuilder planeBuilder,
        List<IMazeElement> unexploredMazeElementsList,
        List<IMazeElement> openList,
        List<IMazeElement> closeList,
        IPathFindProcessMetric pathFindProcessMetric)
    {
        PathFindAlgo pathFindAlgo = null;

        switch (ePathFindAlgorithm)
        {
            case EPathFindAlgorithms.DijkstraAlgorithm:

                pathFindAlgo = new PathFindAlgo(
                    pathFindAlgoBoundary,
                    pathFromStartToEnd,
                    new DijkstraPathFinder(
                        planeBuilder, 
                        new UnexploredMazeElements(
                            planeBuilder,
                            unexploredMazeElementsList),
                        pathFindAlgoBoundary.FindStartPlaceForPathFinding(),
                        pathFindAlgoBoundary.FindDestinationPlaceForPathFinding(),
                        pathFindProcessMetric),               
                    new MazeRestarter(
                        planeBuilder));
                          
                break;

            case EPathFindAlgorithms.EuclideanAStar:

                pathFindAlgo = new PathFindAlgo(
                    pathFindAlgoBoundary,
                    pathFromStartToEnd,
                    new AStarPathFinder(
                        pathFindAlgoBoundary.FindStartPlaceForPathFinding(),
                        pathFindAlgoBoundary.FindDestinationPlaceForPathFinding(),                   
                        new OpenCloseListController(
                            openList,
                            closeList),
                        new NeighboursPathFindParametersProcessor(
                            planeBuilder,
                            pathFindAlgoBoundary.FindDestinationPlaceForPathFinding(),
                            new AStarEuclideanDistanceHeuristic()),
                        pathFindProcessMetric),
                    new MazeRestarter(
                        planeBuilder));
                        
                break;

            case EPathFindAlgorithms.ManhattanAStar:

                pathFindAlgo = new PathFindAlgo(
                    pathFindAlgoBoundary,
                    pathFromStartToEnd,
                    new AStarPathFinder(
                        pathFindAlgoBoundary.FindStartPlaceForPathFinding(),
                        pathFindAlgoBoundary.FindDestinationPlaceForPathFinding(),
                        new OpenCloseListController(
                            openList,
                            closeList),
                        new NeighboursPathFindParametersProcessor(
                            planeBuilder,
                            pathFindAlgoBoundary.FindDestinationPlaceForPathFinding(),
                            new AStarManhattanDistanceHeuristic()),
                        pathFindProcessMetric),
                    new MazeRestarter(
                        planeBuilder));

                break;
        }
        

        return pathFindAlgo;
    }
}
