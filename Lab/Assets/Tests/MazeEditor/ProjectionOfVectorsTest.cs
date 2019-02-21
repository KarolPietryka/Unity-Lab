using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class ProjectionOfVectorsTest {

    public IFarthestMazeElement GetFarthestMazeElement(Vector2 currentFarthestMazeElementIndex)
    {
        var farthestMazeElement = Substitute.For<IFarthestMazeElement>();
        farthestMazeElement.CurrentFarthestMazeElementIndex.Returns(currentFarthestMazeElementIndex);
        return farthestMazeElement;
    }

    public IMouse GetMouseMock(Vector2 _currentMazeElementIndex)
    {
        var mouseBoundary = Substitute.For<IMouse>();
        mouseBoundary.GetCurrentMouseOnMazeElementIndex().Returns(_currentMazeElementIndex);
        return mouseBoundary;
    }

    [Test]
    public void _1_1_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionRight_ReturnFalse()
    {
        Direction direction = Direction.Right;
        Vector2 currentMouseOnMazeElement = new Vector2(5, 4);
        Vector2 currentFarthestMazeElementIndex = new Vector2(6, 0);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, false);
    }

    [Test]
    public void _1_2_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionRight_ReturnTrue()
    {
        Direction direction = Direction.Right;
        Vector2 currentMouseOnMazeElement = new Vector2(6, 4);
        Vector2 currentFarthestMazeElementIndex = new Vector2(6, 0);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, true);
    }

    [Test]
    public void _1_3_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionLeft_ReturnFalse()
    {
        Direction direction = Direction.Left;
        Vector2 currentMouseOnMazeElement = new Vector2(4, 6);
        Vector2 currentFarthestMazeElementIndex = new Vector2(6, 6);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, false);
    }

    [Test]
    public void _1_4_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionLeft_Returntrue()
    {
        Direction direction = Direction.Left;
        Vector2 currentMouseOnMazeElement = new Vector2(-6, -5);
        Vector2 currentFarthestMazeElementIndex = new Vector2(-6, 6);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, true);
    }

    [Test]
    public void _1_5_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionUp_ReturnFalse()
    {
        Direction direction = Direction.Up;
        Vector2 currentMouseOnMazeElement = new Vector2(5, 5);
        Vector2 currentFarthestMazeElementIndex = new Vector2(4, 6);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, false);
    }

    [Test]
    public void _1_6_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionUp_ReturnFalse()
    {
        Direction direction = Direction.Up;
        Vector2 currentMouseOnMazeElement = new Vector2(5, 5);
        Vector2 currentFarthestMazeElementIndex = new Vector2(5, 6);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, false);
    }
    [Test]
    public void _1_7_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionRight_Returntrue()
    {
        Direction direction = Direction.Up;
        Vector2 currentMouseOnMazeElement = new Vector2(4, 6);
        Vector2 currentFarthestMazeElementIndex = new Vector2(5, 6);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, true);
    }

    [Test]
    public void _1_8_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionDown_ReturnFalse()
    {
        Direction direction = Direction.Down;
        Vector2 currentMouseOnMazeElement = new Vector2(7, 16);
        Vector2 currentFarthestMazeElementIndex = new Vector2(7, 13);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, false);
    }

    [Test]
    public void _1_9_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionDown_ReturnFalse()
    {
        Direction direction = Direction.Down;
        Vector2 currentMouseOnMazeElement = new Vector2(7, 16);
        Vector2 currentFarthestMazeElementIndex = new Vector2(7, 13);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, false);
    }

    [Test]
    public void _1_10_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionDown_ReturnFalse()
    {
        Direction direction = Direction.Down;
        Vector2 currentMouseOnMazeElement = new Vector2(6, 14);
        Vector2 currentFarthestMazeElementIndex = new Vector2(7, 13);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, false);
    }

    [Test]
    public void _1_11_IsProjectionOfCurrentMazeEleEqualToFarthestMazeEle_DirectionDown_ReturnTrue()
    {
        Direction direction = Direction.Down;
        Vector2 currentMouseOnMazeElement = new Vector2(6, 13);
        Vector2 currentFarthestMazeElementIndex = new Vector2(7, 13);

        IMouse mouse = GetMouseMock(currentMouseOnMazeElement);
        IFarthestMazeElement farthestMazeElement = GetFarthestMazeElement(currentFarthestMazeElementIndex);

        bool isProjectionOfCurrentMazeEleEqualToFarthestMazeEle = ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeElement, mouse, direction);

        Assert.AreEqual(isProjectionOfCurrentMazeEleEqualToFarthestMazeEle, true);
    }
}

