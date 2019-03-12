using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;
using System.Collections.Generic;

public class EuclideanAStarPathFinderTest {

    IMazeElement GetMazeElementMock(Vector2 mazeElementIndex)
    {
        var mazeElement = Substitute.For<IMazeElement>();
        mazeElement.Index.Returns(mazeElementIndex);
        return mazeElement;
    }
    IMazeElement GetMazeElementMock(Vector2 mazeElementIndex, IMazeElement parent)
    {
        var mazeElement = Substitute.For<IMazeElement>();
        mazeElement.Index.Returns(mazeElementIndex);
        mazeElement.PathFindParent.Returns(parent);
        return mazeElement;
    }
    IMazeElement GetMazeElementMock(Vector2 mazeElementIndex, float mazeElementsWeight, float mazeElementHeuristicDistance)
    {
        var mazeElement = Substitute.For<IMazeElement>();
        mazeElement.Index.Returns(mazeElementIndex);
        mazeElement.PathFindWeight.Returns(mazeElementsWeight);
        mazeElement.PathFindDistanceHeuristic.Returns(mazeElementHeuristicDistance);
        return mazeElement;
    }

    IMazeElement GetMazeElementMock(Vector2 mazeElementIndex, float mazeElementsWeight)
    {
        var mazeElement = Substitute.For<IMazeElement>();
        mazeElement.Index.Returns(mazeElementIndex);
        mazeElement.PathFindWeight.Returns(mazeElementsWeight);
        return mazeElement;
    }
    IOpenCloseListController GetOpenCloseListController(int openListCount)
    {

        var openCloseListController = Substitute.For<IOpenCloseListController>();
        var counter = openListCount;

        openCloseListController.
            When(args => args.OpenListCount())
            .Do(args => openListCount--);

        openCloseListController.
            When(args => args.GetMazeElementWithLowestWeight())
            .Do(
                Callback.Always(args => counter--));
            
        return openCloseListController;
    }

    IPlaneBuilder GetPlaneBuilderMock(Vector2 gamePlaneSize)
    {
        var planeBuilder = Substitute.For<IPlaneBuilder>();
        /*for (int i = 0; i <= gamePlaneSize.x; i++)
        {
            for (int j = 0; j <= gamePlaneSize.y; j++)
            {
                var mazeElement = GetMazeElementMock(new Vector2(i, j), int.MaxValue);
                planeBuilder.GetFromMazeArray(i, j).Returns(mazeElement);

            }
        }*/

        var neighboursList = new List<IMazeElement>();
        neighboursList.Add(GetMazeElementMock(new Vector2(0, 1), 1));
        neighboursList.Add(GetMazeElementMock(new Vector2(1, 0), 1));
        neighboursList.Add(GetMazeElementMock(new Vector2(2, 1), 1));
        neighboursList.Add(GetMazeElementMock(new Vector2(1, 2), 1));


        planeBuilder.GetNeighboursOfMazeElement(planeBuilder.GetFromMazeArray(1, 1)).Returns(neighboursList);
        return planeBuilder;
    }

    List<IMazeElement> GetNeighbours(IMazeElement currentMazeElement, IPlaneBuilder planeBuilder)
    {
        Vector2 currentMazeElementIndex = currentMazeElement.Index;
        List<IMazeElement> neighbours = new List<IMazeElement>();
        neighbours.Add(planeBuilder.GetFromMazeArray((int)currentMazeElementIndex.x - 1, (int)currentMazeElementIndex.y));
        neighbours.Add(planeBuilder.GetFromMazeArray((int)currentMazeElementIndex.x + 1, (int)currentMazeElementIndex.y));
        neighbours.Add(planeBuilder.GetFromMazeArray((int)currentMazeElementIndex.x, (int)currentMazeElementIndex.y - 1));
        neighbours.Add(planeBuilder.GetFromMazeArray((int)currentMazeElementIndex.x, (int)currentMazeElementIndex.y + 1));

        return neighbours;
    }

    IAStarDistanceHeuristic GetAStarDistanceHeuristic()
    {
        var aStarWeightHeuristic = new AStarEuclideanDistanceHeuristic();

        return aStarWeightHeuristic;
    }

    INeighboursPathFindParametersProcessor GetNeighboursPathFindParametersProcessor()
    {
        var neighboursPathFindParametersProcessor = Substitute.For<INeighboursPathFindParametersProcessor>();

        return neighboursPathFindParametersProcessor;
    }
    [Test]
    public void EuclideanAStarPathFinderTestSimplePasses()
    {
        Vector2 gamePlaneSize = new Vector2(10, 10);
        var startMazeElement = GetMazeElementMock(new Vector2(1, 1), 0, 2);
        var destinationMazeElement = GetMazeElementMock(new Vector2(1, 3), null);
        var openCloseListController = GetOpenCloseListController(3);

        var neighboursPathFindParametersProcessor = GetNeighboursPathFindParametersProcessor();

        EuclideanAStarPathFinder euclideanAStarPathFinder = new EuclideanAStarPathFinder(startMazeElement, destinationMazeElement, openCloseListController, neighboursPathFindParametersProcessor);

        List<IMazeElement> path = euclideanAStarPathFinder.FindPath();

        Assert.AreEqual(path[0].Index, startMazeElement);
    }
}
 /*
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

        neighboursPathFindParametersProcessor.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController);
    }
    return DestinationPath.GetListFromStartToDestination(destinationMazeElement);
}*/