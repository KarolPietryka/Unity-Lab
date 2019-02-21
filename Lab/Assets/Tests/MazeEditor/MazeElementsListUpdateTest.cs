using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class MazeElementsListUpdateTest {

    private IPlaneBuilder planeBuilder;
    private IMouse mouseBoundary;
    private Direction processDirection;
    private List<IMazeElement> MazeElementsToProcess;

    IMouse GetMouseMock(Vector2 _currentMouseOnMazeElementIndex, Vector2 _lastMouseClickMazeElementIndex)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.GetCurrentMouseOnMazeElementIndex().Returns(_currentMouseOnMazeElementIndex);
        mouse.GetLastMouseClickMazeElementIndex().Returns(_lastMouseClickMazeElementIndex);
        return mouse;
    }

    IPlaneBuilder GetPlaneBuilder(Vector2 gamePlaneSize, Vector2 indexesOfMazeElementsBelongingToAnotherMazeWall)
    {
        var planeBuilder = Substitute.For<IPlaneBuilder>();
        for (int i = 0; i <= gamePlaneSize.x; i++)
        {
            for (int j = 0; j <= gamePlaneSize.y; j++)
            {
                var mazeElement = Substitute.For<IMazeElement>();
                mazeElement.Index.Returns(new Vector2(i, j));

                if (i == indexesOfMazeElementsBelongingToAnotherMazeWall.x && j == indexesOfMazeElementsBelongingToAnotherMazeWall.y)
                {
                    mazeElement.IsElementOfAnotherWall.Returns(true);
                }
                else
                {
                    mazeElement.IsElementOfAnotherWall.Returns(false);
                }
                planeBuilder.GetFromMazeArray(i, j).Returns(mazeElement);
            }
        }
        return planeBuilder;
    }

    /*void GetFarthestMazeElement(Vector2 currentFarthestMazeElementIndex)
    {
        var farthestMazeElement = Substitute.For<IFarthestMazeElement>();
        farthestMazeElement.currentFarthestMazeElementIndex.Returns(currentFarthestMazeElementIndex);
    }*/

    [Test]
    public void _1_1_UpdateMazeElementsToProcessList_DirectionRight_CountCheck()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(5, 0);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(0, 0);
        Vector2 gamePlaneSize = new Vector2(10, 10);
        Vector2 indexesOfMazeElementsBelongingToAnotherMazeWall = new Vector2(3, 0);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        IPlaneBuilder planeBuilder = GetPlaneBuilder(gamePlaneSize, indexesOfMazeElementsBelongingToAnotherMazeWall);
        Direction processDirection = Direction.Right;
        List<IMazeElement> mazeElementsToProcess = new List<IMazeElement>();

        MazeElementsListUpdate mazeElementsListToProcess = new MazeElementsListUpdate(mouse, planeBuilder);
        mazeElementsListToProcess.UpdateList(mazeElementsToProcess, processDirection, newIsMazeWallForRootMazeElement);

        Assert.AreEqual(mazeElementsListToProcess.mazeElementsToProcess.Count, 5);
    }
    
    [Test]
    public void _1_2_UpdateList_directionLeft_CountCheck()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(4, 0);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(5, 0);
        Vector2 gamePlaneSize = new Vector2(10, 10);
        Vector2 indexesOfMazeElementsBelongingToAnotherMazeWall = new Vector2(3, 0);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        IPlaneBuilder planeBuilder = GetPlaneBuilder(gamePlaneSize, indexesOfMazeElementsBelongingToAnotherMazeWall);
        Direction processDirection = Direction.Left;
        List<IMazeElement> mazeElementsToProcess = new List<IMazeElement>();

        MazeElementsListUpdate mazeElementsListToProcess = new MazeElementsListUpdate(mouse, planeBuilder);
        mazeElementsListToProcess.UpdateList(mazeElementsToProcess, processDirection, newIsMazeWallForRootMazeElement);


        Assert.AreEqual(mazeElementsListToProcess.mazeElementsToProcess.Count, 2);
    }

    [Test]
    public void _1_3_UpdateMazeElementsToProcessList_directionUp_CountCheck()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(0, 0);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(3, 3);
        Vector2 gamePlaneSize = new Vector2(10, 10);
        Vector2 indexesOfMazeElementsBelongingToAnotherMazeWall = new Vector2(0, 4);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        IPlaneBuilder planeBuilder = GetPlaneBuilder(gamePlaneSize, indexesOfMazeElementsBelongingToAnotherMazeWall);
        Direction processDirection = Direction.Up;
        List<IMazeElement> mazeElementsToProcess = new List<IMazeElement>();

        MazeElementsListUpdate mazeElementsListToProcess = new MazeElementsListUpdate(mouse, planeBuilder);
        mazeElementsListToProcess.UpdateList(mazeElementsToProcess, processDirection, newIsMazeWallForRootMazeElement);


        Assert.AreEqual(mazeElementsListToProcess.mazeElementsToProcess.Count, 4);
    }
    [Test]
    public void _1_4_UpdateMazeElementsToProcessList_directionDown_CountCheck()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(10, 7);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(3, 3);
        Vector2 gamePlaneSize = new Vector2(10, 10);
        Vector2 indexesOfMazeElementsBelongingToAnotherMazeWall = new Vector2(0, 4);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        IPlaneBuilder planeBuilder = GetPlaneBuilder(gamePlaneSize, indexesOfMazeElementsBelongingToAnotherMazeWall);
        Direction processDirection = Direction.Down;
        List<IMazeElement> mazeElementsToProcess = new List<IMazeElement>();

        MazeElementsListUpdate mazeElementsListToProcess = new MazeElementsListUpdate(mouse, planeBuilder);
        mazeElementsListToProcess.UpdateList(mazeElementsToProcess, processDirection, newIsMazeWallForRootMazeElement);

        Assert.AreEqual(mazeElementsListToProcess.mazeElementsToProcess.Count, 5);
    }

    [Test]
    public void _1_5_UpdateMazeElementsToProcessList_directionUp_CountCheckNegative()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(10, 7);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(3, 3);
        Vector2 gamePlaneSize = new Vector2(10, 10);
        Vector2 indexesOfMazeElementsBelongingToAnotherMazeWall = new Vector2(0, 4);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        IPlaneBuilder planeBuilder = GetPlaneBuilder(gamePlaneSize, indexesOfMazeElementsBelongingToAnotherMazeWall);
        Direction processDirection = Direction.Up;
        List<IMazeElement> mazeElementsToProcess = new List<IMazeElement>();

        MazeElementsListUpdate mazeElementsListToProcess = new MazeElementsListUpdate(mouse, planeBuilder);
        mazeElementsListToProcess.UpdateList(mazeElementsToProcess, processDirection, newIsMazeWallForRootMazeElement);

        Assert.AreEqual(mazeElementsListToProcess.mazeElementsToProcess.Count, 1);
    }

    [Test]
    public void _1_6_UpdateMazeElementsToProcessList_directionUp_CountCheckNegative()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(4, 4);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(3, 3);
        Vector2 gamePlaneSize = new Vector2(10, 10);
        Vector2 indexesOfMazeElementsBelongingToAnotherMazeWall = new Vector2(0, 3);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        IPlaneBuilder planeBuilder = GetPlaneBuilder(gamePlaneSize, indexesOfMazeElementsBelongingToAnotherMazeWall);
        Direction processDirection = Direction.Down;
        List<IMazeElement> mazeElementsToProcess = new List<IMazeElement>();

        MazeElementsListUpdate mazeElementsListToProcess = new MazeElementsListUpdate(mouse, planeBuilder);
        mazeElementsListToProcess.UpdateList(mazeElementsToProcess, processDirection, newIsMazeWallForRootMazeElement);

        Assert.AreNotEqual(mazeElementsListToProcess.mazeElementsToProcess.Count, 1);
    }
    [Test]
    public void _1_7_UpdateMazeElementsToProcessList_directionUp_CountCheckPositive()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(4, 4);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(3, 3);
        Vector2 gamePlaneSize = new Vector2(10, 10);
        Vector2 indexesOfMazeElementsBelongingToAnotherMazeWall = new Vector2(0, 3);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        IPlaneBuilder planeBuilder = GetPlaneBuilder(gamePlaneSize, indexesOfMazeElementsBelongingToAnotherMazeWall);
        Direction processDirection = Direction.Down;
        List<IMazeElement> mazeElementsToProcess = new List<IMazeElement>();

        MazeElementsListUpdate mazeElementsListToProcess = new MazeElementsListUpdate(mouse, planeBuilder);
        mazeElementsListToProcess.UpdateList(mazeElementsToProcess, processDirection, newIsMazeWallForRootMazeElement);

        Assert.AreEqual(mazeElementsListToProcess.mazeElementsToProcess.Count, 2);
    }
    
}
