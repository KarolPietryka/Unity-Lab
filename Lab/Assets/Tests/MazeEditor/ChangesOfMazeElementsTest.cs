using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class ChangesOfMazeElementsTest {

    Vector2 gamePlaneSize = new Vector2(20, 20);

    IMouse GetMouseMock(Vector2 _currentMouseOnMazeElementIndex, Vector2 _lastMouseClickMazeElementIndex)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.GetCurrentMouseOnMazeElementIndex().Returns(_currentMouseOnMazeElementIndex);
        mouse.GetLastMouseClickMazeElementIndex().Returns(_lastMouseClickMazeElementIndex);
        return mouse;
    }

    List<IMazeElement> GetMazeElementsToProcess(Vector2 gamePlaneSize, Direction processDirection, Vector2 firstMazeElementTochangeIndex)
    {
        List<IMazeElement> mazeElementsList = new List<IMazeElement>();

        if (processDirection == Direction.Left || processDirection == Direction.Right)
        {
            for (int i = 0; i <= gamePlaneSize.x; i++)
            {
                IMazeElement mazeElement = Substitute.For<IMazeElement>();
                mazeElement.Index.Returns(new Vector2(i, firstMazeElementTochangeIndex.y));
                mazeElement.IsMazeWall.Returns(false);

                mazeElementsList.Add(mazeElement);
            }
        }
        else
        {
            for (int i = 0; i <= gamePlaneSize.y; i++)
            {
                IMazeElement mazeElement = Substitute.For<IMazeElement>();
                mazeElement.Index.Returns(new Vector2(firstMazeElementTochangeIndex.x, i));
                mazeElement.IsMazeWall.Returns(false);

                mazeElementsList.Add(mazeElement);
            }
        }
        return mazeElementsList;
    }

    void MazeElementDidReceivedCall(IMazeElement changedMazeElement)
    {
        if (changedMazeElement != null)
        {
            changedMazeElement.Received().ReverseIsMazeWall();
        }
    }

    void MazeElementDidNotReceivedCall(IMazeElement changedMazeElement)
    {
        if (changedMazeElement != null)
        {
            changedMazeElement.DidNotReceive().ReverseIsMazeWall();
        }
    }

    void AssertionOfChangeOnHorizontal(Vector2 _firstMazeElementToReverseIndex, Vector2 _lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess, Direction processDirection)
    {
        Vector2 firstMazeElementToReverseIndex;
        Vector2 lastMazeElementToReverseIndex;

        if (processDirection == Direction.Right || processDirection == Direction.Down)
        {
            firstMazeElementToReverseIndex = _firstMazeElementToReverseIndex;
            lastMazeElementToReverseIndex = _lastMazeElementToReverseIndex;
        }
        else
        {
            firstMazeElementToReverseIndex = _lastMazeElementToReverseIndex;
            lastMazeElementToReverseIndex = _firstMazeElementToReverseIndex;
        }

        for (int i = 0; i < firstMazeElementToReverseIndex.x; i++)
        {
            IMazeElement changedMazeElement = mazeElementsToProcess.Find(x => x.Index == new Vector2(i, firstMazeElementToReverseIndex.y));
            //Debug.Log(changedMazeElement.Index); //for test problems
            MazeElementDidNotReceivedCall(changedMazeElement);

        }
        for (int i = (int)firstMazeElementToReverseIndex.x; i <= lastMazeElementToReverseIndex.x; i++)
        {
            IMazeElement changedMazeElement = mazeElementsToProcess.Find(x => x.Index == new Vector2(i, firstMazeElementToReverseIndex.y));
            //Debug.Log(changedMazeElement.Index); //for test problems
            MazeElementDidReceivedCall(changedMazeElement);
        }
        for (int i = (int)lastMazeElementToReverseIndex.x + 1; i <= gamePlaneSize.x; i++)
        {
            IMazeElement changedMazeElement = mazeElementsToProcess.Find(x => x.Index == new Vector2(i, firstMazeElementToReverseIndex.y));
            //Debug.Log(changedMazeElement.Index); //for test problems
            MazeElementDidNotReceivedCall(changedMazeElement);

        }
    }

    void AssertionOfChangeOnVertical(Vector2 _firstMazeElementToChangeeIndex, Vector2 _lastMazeElementToChangeIndex, List<IMazeElement> mazeElementsToProcess, Direction processDirection)
    {
        Vector2 firstMazeElementToReverseIndex;
        Vector2 lastMazeElementToReverseIndex;

        if (processDirection == Direction.Right || processDirection == Direction.Down)
        {
            firstMazeElementToReverseIndex = _firstMazeElementToChangeeIndex;
            lastMazeElementToReverseIndex = _lastMazeElementToChangeIndex;
        }
        else
        {
            firstMazeElementToReverseIndex = _lastMazeElementToChangeIndex;
            lastMazeElementToReverseIndex = _firstMazeElementToChangeeIndex;
        }

        for (int i = 0; i < firstMazeElementToReverseIndex.y; i++)
        {
            IMazeElement changedMazeElement = mazeElementsToProcess.Find(x => x.Index == new Vector2(firstMazeElementToReverseIndex.x, i));
            //Debug.Log(changedMazeElement.Index); //for test problems
            MazeElementDidNotReceivedCall(changedMazeElement);

        }
        for (int i = (int)firstMazeElementToReverseIndex.y; i <= lastMazeElementToReverseIndex.y; i++)
        {
            IMazeElement changedMazeElement = mazeElementsToProcess.Find(x => x.Index == new Vector2(firstMazeElementToReverseIndex.x, i));
            //Debug.Log(changedMazeElement.Index); //for test problems
            MazeElementDidReceivedCall(changedMazeElement);

        }
        for (int i = (int)lastMazeElementToReverseIndex.y + 1; i <= gamePlaneSize.y; i++)
        {
            IMazeElement changedMazeElement = mazeElementsToProcess.Find(x => x.Index == new Vector2(firstMazeElementToReverseIndex.x, i));
            //Debug.Log(changedMazeElement.Index); //for test problems
            MazeElementDidNotReceivedCall(changedMazeElement);

        }
    }


    [Test]
    public void _1_1_ChangeOfMazeElements_DirectionRight()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Direction processDirection = Direction.Right;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(4, 0);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(2, 0);

        IMouse mouseBoundary = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, lastMouseClickMazeElementIndex);

        ChangesOfMazeElements reversalOfMazeElements = new ChangesOfMazeElements();
        reversalOfMazeElements.ChangeMazeElementsInListFromTo(mouseBoundary, processDirection, mazeElementsToProcess, newIsMazeWallForRootMazeElement);

        AssertionOfChangeOnHorizontal(lastMouseClickMazeElementIndex, currentMouseOnMazeElementIndex, mazeElementsToProcess, processDirection);
    }

    [Test]
    public void _1_2_ChangeOfMazeElements_DirectionRight()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Direction processDirection = Direction.Right;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(4, 0);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(0, 0);

        IMouse mouseBoundary = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, lastMouseClickMazeElementIndex);

        ChangesOfMazeElements reversalOfMazeElements = new ChangesOfMazeElements();
        reversalOfMazeElements.ChangeMazeElementsInListFromTo(mouseBoundary, processDirection, mazeElementsToProcess, newIsMazeWallForRootMazeElement);

        AssertionOfChangeOnHorizontal(lastMouseClickMazeElementIndex, currentMouseOnMazeElementIndex, mazeElementsToProcess, processDirection);
    }

    [Test]
    public void _1_3_ChangeOfMazeElements_DirectionDown()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Direction processDirection = Direction.Down;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(4, 1);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(4, 0);

        IMouse mouseBoundary = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, lastMouseClickMazeElementIndex);

        ChangesOfMazeElements reversalOfMazeElements = new ChangesOfMazeElements();
        reversalOfMazeElements.ChangeMazeElementsInListFromTo(mouseBoundary, processDirection, mazeElementsToProcess, newIsMazeWallForRootMazeElement);

        AssertionOfChangeOnVertical(lastMouseClickMazeElementIndex, currentMouseOnMazeElementIndex, mazeElementsToProcess, processDirection);
    }

    [Test]
    public void _1_4_ChangeOfMazeElements_DirectionDown()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Direction processDirection = Direction.Down;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(4, 8);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(4, 1);

        IMouse mouseBoundary = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, lastMouseClickMazeElementIndex);

        ChangesOfMazeElements reversalOfMazeElements = new ChangesOfMazeElements();
        reversalOfMazeElements.ChangeMazeElementsInListFromTo(mouseBoundary, processDirection, mazeElementsToProcess, newIsMazeWallForRootMazeElement);

        AssertionOfChangeOnVertical(lastMouseClickMazeElementIndex, currentMouseOnMazeElementIndex, mazeElementsToProcess, processDirection);
    }

    [Test]
    public void _1_5_ChangeOfMazeElements_DirectionUp()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Direction processDirection = Direction.Up;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(4, 1);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(4, 3);

        IMouse mouseBoundary = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, lastMouseClickMazeElementIndex);

        ChangesOfMazeElements reversalOfMazeElements = new ChangesOfMazeElements();
        reversalOfMazeElements.ChangeMazeElementsInListFromTo(mouseBoundary, processDirection, mazeElementsToProcess, newIsMazeWallForRootMazeElement);

        AssertionOfChangeOnVertical(lastMouseClickMazeElementIndex, currentMouseOnMazeElementIndex, mazeElementsToProcess, processDirection);
    }

    [Test]
    public void _1_6_ChangeOfMazeElements_DirectionUp()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Direction processDirection = Direction.Up;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(4, 0);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(4, 9);

        IMouse mouseBoundary = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, lastMouseClickMazeElementIndex);

        ChangesOfMazeElements reversalOfMazeElements = new ChangesOfMazeElements();
        reversalOfMazeElements.ChangeMazeElementsInListFromTo(mouseBoundary, processDirection, mazeElementsToProcess, newIsMazeWallForRootMazeElement);

        AssertionOfChangeOnVertical(lastMouseClickMazeElementIndex, currentMouseOnMazeElementIndex, mazeElementsToProcess, processDirection);
    }

    [Test]
    public void _1_7_ChangeOfMazeElements_DirectionLeft()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Direction processDirection = Direction.Left;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(1, 0);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(6, 0);

        IMouse mouseBoundary = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, lastMouseClickMazeElementIndex);

        ChangesOfMazeElements reversalOfMazeElements = new ChangesOfMazeElements();
        reversalOfMazeElements.ChangeMazeElementsInListFromTo(mouseBoundary, processDirection, mazeElementsToProcess, newIsMazeWallForRootMazeElement);

        AssertionOfChangeOnHorizontal(lastMouseClickMazeElementIndex, currentMouseOnMazeElementIndex, mazeElementsToProcess, processDirection);
    }

    [Test]
    public void _1_8_ChangeOfMazeElements_DirectionLeft()
    {
        bool newIsMazeWallForRootMazeElement = true;
        Direction processDirection = Direction.Left;
        Vector2 currentMouseOnMazeElementIndex = new Vector2(6, 6);
        Vector2 lastMouseClickMazeElementIndex = new Vector2(6, 6);

        IMouse mouseBoundary = GetMouseMock(currentMouseOnMazeElementIndex, lastMouseClickMazeElementIndex);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, lastMouseClickMazeElementIndex);

        ChangesOfMazeElements reversalOfMazeElements = new ChangesOfMazeElements();
        reversalOfMazeElements.ChangeMazeElementsInListFromTo(mouseBoundary, processDirection, mazeElementsToProcess, newIsMazeWallForRootMazeElement);

        AssertionOfChangeOnHorizontal(lastMouseClickMazeElementIndex, currentMouseOnMazeElementIndex, mazeElementsToProcess, processDirection);
    }

}
