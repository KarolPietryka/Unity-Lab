using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfinderAlgorithmFactory  {

    public virtual IPathFindAlgo CreatePathFindAlgo(
        EPathFindAlgorithms ePathFindAlgorithm,
        IPathFindAlgoBoundary pathFindAlgoBoundary,
        List<IMazeElement> pathFromStartToEnd,
        IPlaneBuilder planeBuilder,
        List<IMazeElement> unexploredMazeElementsList,
        List<IMazeElement> openList,
        List<IMazeElement> closeList)
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
                        pathFindAlgoBoundary.FindDestinationPlaceForPathFinding()),
                    new MazeElementsParametersRestarter(
                        planeBuilder));
                          
                break;

            case EPathFindAlgorithms.EuclideanAStar:

                pathFindAlgo = new PathFindAlgo(
                    pathFindAlgoBoundary,
                    pathFromStartToEnd,
                    new EuclideanAStarPathFinder(
                        pathFindAlgoBoundary.FindStartPlaceForPathFinding(),
                        pathFindAlgoBoundary.FindDestinationPlaceForPathFinding(),                   
                        new OpenCloseListController(
                            openList,
                            closeList),
                        new NeighboursPathFindParametersProcessor(
                            planeBuilder,
                            pathFindAlgoBoundary.FindDestinationPlaceForPathFinding(),
                            new AStarEuclideanDistanceHeuristic())),
                    new MazeElementsParametersRestarter(
                        planeBuilder));
                        
                break;
                    
        }
        

        return pathFindAlgo;
    }
}
