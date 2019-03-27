using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;
using System.Collections.Generic;

public class NeighboursPathFindParametersProcessorTest {

    IPlaneBuilder GetPlaneBuilderMock(IMazeElement currentMazeElement, float mazeElementsWeight)
    {
        var planeBuilder = Substitute.For<IPlaneBuilder>();
        var neighboursList = GetNeighbours(currentMazeElement, mazeElementsWeight);

        foreach (var neighbour in neighboursList)
        {
            Vector2 mazeElementIndex = neighbour.Index;
            planeBuilder.GetFromMazeArray((int)mazeElementIndex.x, (int)mazeElementIndex.y).Returns(neighbour);
        }
        planeBuilder.GetNeighboursOfMazeElement(currentMazeElement).Returns(neighboursList);
        return planeBuilder;
    }
    List<IMazeElement> GetNeighbours(IMazeElement currentMazeElement, float mazeElementsWeight)
    {
        Vector2 currentMazeElementIndex = currentMazeElement.Index;
        List<IMazeElement> neighbours = new List<IMazeElement>();
        neighbours.Add(GetMazeElementMock(new Vector2(currentMazeElementIndex.x - 1, currentMazeElementIndex.y), mazeElementsWeight));
        neighbours.Add(GetMazeElementMock(new Vector2(currentMazeElementIndex.x + 1, currentMazeElementIndex.y), mazeElementsWeight));
        neighbours.Add(GetMazeElementMock(new Vector2(currentMazeElementIndex.x, currentMazeElementIndex.y - 1), mazeElementsWeight));
        neighbours.Add(GetMazeElementMock(new Vector2(currentMazeElementIndex.x, currentMazeElementIndex.y + 1), mazeElementsWeight));

        return neighbours;
    }

    IMazeElement GetMazeElementMock(Vector2 mazeElementIndex)
    {
        var mazeElement = Substitute.For<IMazeElement>();
        mazeElement.Index.Returns(mazeElementIndex);
        return mazeElement;
    }
    IMazeElement GetMazeElementMock(Vector2 mazeElementIndex, float mazeElementsWeight)
    {
        var mazeElement = Substitute.For<IMazeElement>();
        mazeElement.Index.Returns(mazeElementIndex);
        mazeElement.PathFindWeight.Returns(mazeElementsWeight);
        return mazeElement;
    }

    IOpenCloseListController GetOpenCloseListController()
    {
        var openCloseListController = Substitute.For<IOpenCloseListController>();
        openCloseListController.CloseListContains(Substitute.For<IMazeElement>()).ReturnsForAnyArgs(false);
        openCloseListController.OpenListContains(Substitute.For<IMazeElement>()).ReturnsForAnyArgs(false);

        return openCloseListController;
    }

    IAStarDistanceHeuristic GetAStarDistanceHeuristic()
    {
        var aStarWeightHeuristic = new AStarEuclideanDistanceHeuristic();        

        return aStarWeightHeuristic;
    }
    [Test]
    public void ProcessNeighboursPathFindParameters_RightNeighbourCheck()
    {
        var destinationMazeElement = GetMazeElementMock(new Vector2(5, 3));
        var currentMazeElement = GetMazeElementMock(new Vector2(3, 3), 10);
        var planeBuilder = GetPlaneBuilderMock(currentMazeElement, 10);
        var openCloseListController = GetOpenCloseListController();
        var aStarWeightHeuristic = GetAStarDistanceHeuristic();

        var neighboursPathFindParametersProcessorTestSimplePasses = new NeighboursPathFindParametersProcessor(planeBuilder, destinationMazeElement, aStarWeightHeuristic);

        neighboursPathFindParametersProcessorTestSimplePasses.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController, Substitute.For<IPathFindProcessMetric>());

        Assert.AreEqual(planeBuilder.GetFromMazeArray(4, 3).PathFindWeight, 11);
        Assert.AreEqual(planeBuilder.GetFromMazeArray(4, 3).PathFindDistanceHeuristic, 1);
    }

    [Test]
    public void ProcessNeighboursPathFindParameters_LeftNeighbourCheck()
    {
        var destinationMazeElement = GetMazeElementMock(new Vector2(5, 3));
        var currentMazeElement = GetMazeElementMock(new Vector2(3, 3), 10);
        var planeBuilder = GetPlaneBuilderMock(currentMazeElement, 10);
        var openCloseListController = GetOpenCloseListController();
        var aStarWeightHeuristic = GetAStarDistanceHeuristic();

        var neighboursPathFindParametersProcessorTestSimplePasses = new NeighboursPathFindParametersProcessor(planeBuilder, destinationMazeElement, aStarWeightHeuristic);

        neighboursPathFindParametersProcessorTestSimplePasses.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController, Substitute.For<IPathFindProcessMetric>());

        Assert.AreEqual(planeBuilder.GetFromMazeArray(2, 3).PathFindWeight, 11);
        Assert.AreEqual(planeBuilder.GetFromMazeArray(2, 3).PathFindDistanceHeuristic, 3);
    }

    [Test]
    public void ProcessNeighboursPathFindParameters_UpNeighbourCheck()
    {
        var destinationMazeElement = GetMazeElementMock(new Vector2(5, 3));
        var currentMazeElement = GetMazeElementMock(new Vector2(3, 3), 10);
        var planeBuilder = GetPlaneBuilderMock(currentMazeElement, 10);
        var openCloseListController = GetOpenCloseListController();
        var aStarWeightHeuristic = GetAStarDistanceHeuristic();

        var neighboursPathFindParametersProcessorTestSimplePasses = new NeighboursPathFindParametersProcessor(planeBuilder, destinationMazeElement, aStarWeightHeuristic);

        neighboursPathFindParametersProcessorTestSimplePasses.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController, Substitute.For<IPathFindProcessMetric>());

        Assert.AreEqual(planeBuilder.GetFromMazeArray(3, 2).PathFindWeight, 11);
        Assert.AreEqual(planeBuilder.GetFromMazeArray(3, 2).PathFindDistanceHeuristic, Mathf.Sqrt(5));
    }

    [Test]
    public void ProcessNeighboursPathFindParameters_DownNeighbourCheck()
    {
        var destinationMazeElement = GetMazeElementMock(new Vector2(5, 3));
        var currentMazeElement = GetMazeElementMock(new Vector2(3, 3), 10);
        var planeBuilder = GetPlaneBuilderMock(currentMazeElement, 10);
        var openCloseListController = GetOpenCloseListController();
        var aStarWeightHeuristic = GetAStarDistanceHeuristic();

        var neighboursPathFindParametersProcessorTestSimplePasses = new NeighboursPathFindParametersProcessor(planeBuilder, destinationMazeElement, aStarWeightHeuristic);

        neighboursPathFindParametersProcessorTestSimplePasses.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController, Substitute.For<IPathFindProcessMetric>());

        Assert.AreEqual(planeBuilder.GetFromMazeArray(3, 2).PathFindWeight, 11);
        Assert.AreEqual(planeBuilder.GetFromMazeArray(3, 2).PathFindDistanceHeuristic, Mathf.Sqrt(5));
    }

    [Test]
    public void ProcessNeighboursPathFindParameters_DownNeighbourAreNotEqualCheck()
    {
        var destinationMazeElement = GetMazeElementMock(new Vector2(5, 3));
        var currentMazeElement = GetMazeElementMock(new Vector2(3, 3), 10);
        var planeBuilder = GetPlaneBuilderMock(currentMazeElement, 10);
        var openCloseListController = GetOpenCloseListController();
        var aStarWeightHeuristic = GetAStarDistanceHeuristic();

        var neighboursPathFindParametersProcessorTestSimplePasses = new NeighboursPathFindParametersProcessor(planeBuilder, destinationMazeElement, aStarWeightHeuristic);

        neighboursPathFindParametersProcessorTestSimplePasses.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController, Substitute.For<IPathFindProcessMetric>());

        Assert.AreEqual(planeBuilder.GetFromMazeArray(3, 2).PathFindWeight, 11);
        Assert.AreNotEqual(planeBuilder.GetFromMazeArray(3, 2).PathFindDistanceHeuristic, Mathf.Sqrt(5.1f));
    }

    [Test]
    public void ProcessNeighboursPathFindParameters_NeighbourEqualCheck_BiggerPlane()
    {
        var destinationMazeElement = GetMazeElementMock(new Vector2(10, 10));
        var currentMazeElement = GetMazeElementMock(new Vector2(1, 1), 10);
        var planeBuilder = GetPlaneBuilderMock(currentMazeElement, 10);
        var openCloseListController = GetOpenCloseListController();
        var aStarWeightHeuristic = GetAStarDistanceHeuristic();

        var neighboursPathFindParametersProcessorTestSimplePasses = new NeighboursPathFindParametersProcessor(planeBuilder, destinationMazeElement, aStarWeightHeuristic);

        neighboursPathFindParametersProcessorTestSimplePasses.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController, Substitute.For<IPathFindProcessMetric>());

        Assert.AreEqual(planeBuilder.GetFromMazeArray(1, 2).PathFindWeight, 11);
        Assert.AreEqual(planeBuilder.GetFromMazeArray(1, 2).PathFindDistanceHeuristic, Mathf.Sqrt(145));
    }

    [Test]
    public void ProcessNeighboursPathFindParameters_OpenListCountCheck()
    {
        var destinationMazeElement = GetMazeElementMock(new Vector2(5, 3));
        var currentMazeElement = GetMazeElementMock(new Vector2(3, 3), 10);
        var planeBuilder = GetPlaneBuilderMock(currentMazeElement, 10);
        var openCloseListController = GetOpenCloseListController();
        var aStarWeightHeuristic = GetAStarDistanceHeuristic();

        var neighboursPathFindParametersProcessorTestSimplePasses = new NeighboursPathFindParametersProcessor(planeBuilder, destinationMazeElement, aStarWeightHeuristic);

        neighboursPathFindParametersProcessorTestSimplePasses.ProcessNeighboursPathFindParameters(currentMazeElement, openCloseListController, Substitute.For<IPathFindProcessMetric>());

        openCloseListController.ReceivedWithAnyArgs(4).AddToOpenList(Substitute.For<IMazeElement>());

    }
}
