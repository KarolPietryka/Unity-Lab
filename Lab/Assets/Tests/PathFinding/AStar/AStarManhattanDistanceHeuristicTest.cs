using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class AStarManhattanDistanceHeuristicTest {

    IMazeElement GetMazeElementMock(Vector2 mazeElementIndex)
    {
        var mazeElement = Substitute.For<IMazeElement>();
        mazeElement.Index.Returns(mazeElementIndex);
        return mazeElement;
    }

    [Test]
    public void _1_1_GetDistanceBetween()
    {
        var currentMazeElement = GetMazeElementMock(new Vector2(0, 0));
        var destinationMazeElement = GetMazeElementMock(new Vector2(2, 0));
        AStarManhattanDistanceHeuristic AStarManhattanDistanceHeuristic = new AStarManhattanDistanceHeuristic();

        float distance = AStarManhattanDistanceHeuristic.GetDistanceBetween(currentMazeElement, destinationMazeElement);
        Assert.AreEqual(distance, 2);
    }

    [Test]
    public void _1_2_GetDistanceBetween()
    {
        var currentMazeElement = GetMazeElementMock(new Vector2(4, 0));
        var destinationMazeElement = GetMazeElementMock(new Vector2(2, 0));
        AStarManhattanDistanceHeuristic AStarManhattanDistanceHeuristic = new AStarManhattanDistanceHeuristic();

        float distance = AStarManhattanDistanceHeuristic.GetDistanceBetween(currentMazeElement, destinationMazeElement);
        Assert.AreEqual(distance, 2);
    }

    [Test]
    public void _1_3_GetDistanceBetween()
    {
        var currentMazeElement = GetMazeElementMock(new Vector2(0, 0));
        var destinationMazeElement = GetMazeElementMock(new Vector2(3, 4));
        AStarManhattanDistanceHeuristic AStarManhattanDistanceHeuristic = new AStarManhattanDistanceHeuristic();

        float distance = AStarManhattanDistanceHeuristic.GetDistanceBetween(currentMazeElement, destinationMazeElement);
        Assert.AreEqual(distance, 7);
    }

    [Test]
    public void _1_4_GetDistanceBetween()
    {
        var currentMazeElement = GetMazeElementMock(new Vector2(9, 7));
        var destinationMazeElement = GetMazeElementMock(new Vector2(5, 4));
        AStarManhattanDistanceHeuristic AStarManhattanDistanceHeuristic = new AStarManhattanDistanceHeuristic();

        float distance = AStarManhattanDistanceHeuristic.GetDistanceBetween(currentMazeElement, destinationMazeElement);
        Assert.AreEqual(distance, 7);
    }
}
