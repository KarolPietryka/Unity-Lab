using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;


public class ReversalOfMazeElementsTest {

    Vector2 gamePlaneSize = new Vector2(20, 20);


    List<IMazeElement> GetMazeElementsToProcess(Vector2 gamePlaneSize, Direction processDirection, Vector2 firstMazeElementToReverseIndex)
    {
        List<IMazeElement> mazeElementsList = new List<IMazeElement>();

        if (processDirection == Direction.Left || processDirection == Direction.Right)
        {
            for (int i = 0; i <= gamePlaneSize.x; i++)
            {
                IMazeElement mazeElement = Substitute.For<IMazeElement>();
                mazeElement.Index.Returns(new Vector2(i, firstMazeElementToReverseIndex.y));

                mazeElementsList.Add(mazeElement);
            }
        }
        else
        {
            for (int i = 0; i <= gamePlaneSize.y; i++)
            {
                IMazeElement mazeElement = Substitute.For<IMazeElement>();
                mazeElement.Index.Returns(new Vector2(firstMazeElementToReverseIndex.x, i));

                mazeElementsList.Add(mazeElement);
            }
        }
        return mazeElementsList;
    }

    void AssertionOfReciveOnHorizontal(Vector2 _firstMazeElementToReverseIndex, Vector2 _lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess, Direction processDirection)
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

    void AssertionOfReciveOnVertical(Vector2 _firstMazeElementToReverseIndex, Vector2 _lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess, Direction processDirection)
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

    [Test]
    public void _1_1_ReversalOfMazeElements_DirectionRight()
    {
        Direction processDirection = Direction.Right;
        Vector2 firstMazeElementToReverseIndex = new Vector2(0, 0);
        Vector2 lastMazeElementToReverseIndex = new Vector2(1, 0);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, firstMazeElementToReverseIndex);


        ReversalOfMazeElements reversalOfMazeElements = new ReversalOfMazeElements();
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, mazeElementsToProcess);

        AssertionOfReciveOnHorizontal(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, processDirection);
    }

    [Test]
    public void _1_2_ReversalOfMazeElements_DirectionRight()
    {
        Direction processDirection = Direction.Right;
        Vector2 firstMazeElementToReverseIndex = new Vector2(3, 0);
        Vector2 lastMazeElementToReverseIndex = new Vector2(7, 0);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, firstMazeElementToReverseIndex);


        ReversalOfMazeElements reversalOfMazeElements = new ReversalOfMazeElements();
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, mazeElementsToProcess);

        AssertionOfReciveOnHorizontal(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, processDirection);

    }

    [Test]
    public void _1_3_ReversalOfMazeElements_DirectionDown()
    {
        Direction processDirection = Direction.Down;
        Vector2 firstMazeElementToReverseIndex = new Vector2(3, 1);
        Vector2 lastMazeElementToReverseIndex = new Vector2(3, 4);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, firstMazeElementToReverseIndex);


        ReversalOfMazeElements reversalOfMazeElements = new ReversalOfMazeElements();
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, mazeElementsToProcess);

        AssertionOfReciveOnVertical(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, processDirection);

    }

    [Test]
    public void _1_4_ReversalOfMazeElements_DirectionDown()
    {
        Direction processDirection = Direction.Down;
        Vector2 firstMazeElementToReverseIndex = new Vector2(3, 0);
        Vector2 lastMazeElementToReverseIndex = new Vector2(3, 3);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, firstMazeElementToReverseIndex);


        ReversalOfMazeElements reversalOfMazeElements = new ReversalOfMazeElements();
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, mazeElementsToProcess);

        AssertionOfReciveOnVertical(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, processDirection);

    }

    [Test]
    public void _1_5_ReversalOfMazeElements_DirectionLeft()
    {
        Direction processDirection = Direction.Left;
        Vector2 firstMazeElementToReverseIndex = new Vector2(3, 0);
        Vector2 lastMazeElementToReverseIndex = new Vector2(0, 0);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, firstMazeElementToReverseIndex);


        ReversalOfMazeElements reversalOfMazeElements = new ReversalOfMazeElements();
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, mazeElementsToProcess);

        AssertionOfReciveOnHorizontal(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, processDirection);

    }

    [Test]
    public void _1_6_ReversalOfMazeElements_DirectionLeft()
    {
        Direction processDirection = Direction.Left;
        Vector2 firstMazeElementToReverseIndex = new Vector2(9, 4);
        Vector2 lastMazeElementToReverseIndex = new Vector2(4, 4);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, firstMazeElementToReverseIndex);


        ReversalOfMazeElements reversalOfMazeElements = new ReversalOfMazeElements();
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, mazeElementsToProcess);

        AssertionOfReciveOnHorizontal(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, processDirection);

    }

    [Test]
    public void _1_7_ReversalOfMazeElements_DirectionLeft()
    {
        Direction processDirection = Direction.Left;
        Vector2 firstMazeElementToReverseIndex = new Vector2(1, 4);
        Vector2 lastMazeElementToReverseIndex = new Vector2(0, 4);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, firstMazeElementToReverseIndex);


        ReversalOfMazeElements reversalOfMazeElements = new ReversalOfMazeElements();
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, mazeElementsToProcess);

        AssertionOfReciveOnHorizontal(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, processDirection);

    }

    [Test]
    public void _1_8_ReversalOfMazeElements_DirectionUp()
    {
        Direction processDirection = Direction.Up;
        Vector2 firstMazeElementToReverseIndex = new Vector2(1, 5);
        Vector2 lastMazeElementToReverseIndex = new Vector2(1, 4);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, firstMazeElementToReverseIndex);


        ReversalOfMazeElements reversalOfMazeElements = new ReversalOfMazeElements();
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, mazeElementsToProcess);

        AssertionOfReciveOnVertical(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, processDirection);

    }

    [Test]
    public void _1_9_ReversalOfMazeElements_DirectionUp()
    {
        Direction processDirection = Direction.Up;
        Vector2 firstMazeElementToReverseIndex = new Vector2(7, 10);
        Vector2 lastMazeElementToReverseIndex = new Vector2(7, 1);
        List<IMazeElement> mazeElementsToProcess = GetMazeElementsToProcess(gamePlaneSize, processDirection, firstMazeElementToReverseIndex);


        ReversalOfMazeElements reversalOfMazeElements = new ReversalOfMazeElements();
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, mazeElementsToProcess);

        AssertionOfReciveOnVertical(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, processDirection);

    }
}
