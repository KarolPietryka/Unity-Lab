using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;


public class OpenCloseListControllerTest {

    IMazeElement GetMazeElementMock(float pathFindWeight, float pathFindDistanceHeuristic)
    {
        var mazeElement = Substitute.For<IMazeElement>();
       // mazeElement.Index.Returns(mazeElementIndex);
        mazeElement.PathFindWeight.Returns(pathFindWeight);
        mazeElement.PathFindDistanceHeuristic.Returns(pathFindDistanceHeuristic);
        return mazeElement;
    }

    [Test]
    public void SortOpenList()
    {
        List<IMazeElement> openList = new List<IMazeElement>();
        List<IMazeElement> closeList = new List<IMazeElement>();

        openList.Add(GetMazeElementMock(1.0f, 3.0f));
        openList.Add(GetMazeElementMock(1.0f, 2.0f));
        openList.Add(GetMazeElementMock(2.0f, 3.0f));
        openList.Add(GetMazeElementMock(0.1f, 4.5f));
        OpenCloseListController openCloseListController = new OpenCloseListController(openList, closeList);

        IMazeElement lowestWeightMazeElement = openCloseListController.GetMazeElementWithLowestWeight();

        Assert.AreEqual(lowestWeightMazeElement.PathFindWeight, 1.0f);
        Assert.AreEqual(lowestWeightMazeElement.PathFindDistanceHeuristic, 2.0f);
    }

    [Test]
    public void SortOpenList_TwoElementsInList()
    {
        List<IMazeElement> openList = new List<IMazeElement>();
        List<IMazeElement> closeList = new List<IMazeElement>();

        openList.Add(GetMazeElementMock(1.0f, 3.0f));
        openList.Add(GetMazeElementMock(1.0f, 2.0f));
        OpenCloseListController openCloseListController = new OpenCloseListController(openList, closeList);

        IMazeElement lowestWeightMazeElement = openCloseListController.GetMazeElementWithLowestWeight();

        Assert.AreEqual(lowestWeightMazeElement.PathFindWeight, 1.0f);
        Assert.AreEqual(lowestWeightMazeElement.PathFindDistanceHeuristic, 2.0f);

    }

    [Test]
    public void SortOpenList_OneElementInList()
    {
        List<IMazeElement> openList = new List<IMazeElement>();
        List<IMazeElement> closeList = new List<IMazeElement>();

        openList.Add(GetMazeElementMock(1.0f, 2.0f));
        OpenCloseListController openCloseListController = new OpenCloseListController(openList, closeList);

        IMazeElement lowestWeightMazeElement = openCloseListController.GetMazeElementWithLowestWeight();

        Assert.AreEqual(lowestWeightMazeElement.PathFindWeight, 1.0f);
        Assert.AreEqual(lowestWeightMazeElement.PathFindDistanceHeuristic, 2.0f);

    }
}
