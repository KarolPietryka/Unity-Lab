using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class FarthestMazeElementFromLastMouseClickMazeElementTest {

    IMouse mouseBoundary;

    public IMouse GetMouseMock(Vector2 _currentMazeElementIndex)
    {
        var mouseBoundary = Substitute.For<IMouse>();
        mouseBoundary.GetCurrentMouseOnMazeElementIndex().Returns(_currentMazeElementIndex);
        mouseBoundary.GetLastMouseClickMazeElementIndex().Returns(_currentMazeElementIndex);

        return mouseBoundary;
    }

    public void CurrentMazeElementChange(Vector2 _newCurrentMazeElementIndex)
    {
        mouseBoundary.GetCurrentMouseOnMazeElementIndex().Returns(_newCurrentMazeElementIndex);
    }
    [Test]
    public void _1_1_Update_LeftProcessDirection_Current_Zero_Zero_New_Neg_Neg()
    {
        Direction processDirection = Direction.Left;
        Vector2 currentMazeElementIndex = new Vector2(0, 0);
        Vector2 newCurrentMazeElementIndex = new Vector2(-1, -3);
        mouseBoundary = GetMouseMock(currentMazeElementIndex);

        var farthestMazeElementFromLastMouseClickMazeElement = Substitute.For<FarthestMazeElementFromLastMouseClickMazeElement>(mouseBoundary);
        CurrentMazeElementChange(newCurrentMazeElementIndex);

        farthestMazeElementFromLastMouseClickMazeElement.UpdateIfCurrentMazeEleIsGreater(processDirection);

        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.x, newCurrentMazeElementIndex.x);
        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.y, currentMazeElementIndex.y);
    }

    [Test]
    public void _1_2_Update_LeftProcessDirection_Current_Zero_Zero_New_Neg_Neg()
    {
        Direction processDirection = Direction.Left;
        Vector2 currentMazeElementIndex = new Vector2(0, 0);
        Vector2 newCurrentMazeElementIndex = new Vector2(-21, -1);
        mouseBoundary = GetMouseMock(currentMazeElementIndex);

        var farthestMazeElementFromLastMouseClickMazeElement = Substitute.For<FarthestMazeElementFromLastMouseClickMazeElement>(mouseBoundary);
        CurrentMazeElementChange(newCurrentMazeElementIndex);

        farthestMazeElementFromLastMouseClickMazeElement.UpdateIfCurrentMazeEleIsGreater(processDirection);

        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.x, newCurrentMazeElementIndex.x);
        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.y, currentMazeElementIndex.y);
    }

    [Test]
    public void _1_3_Update_RightProcessDirection_Current_Zero_Zero_New_Pos_Pos()
    {
        Direction processDirection = Direction.Right;
        Vector2 currentMazeElementIndex = new Vector2(0, 0);
        Vector2 newCurrentMazeElementIndex = new Vector2(2, 21);
        mouseBoundary = GetMouseMock(currentMazeElementIndex);

        var farthestMazeElementFromLastMouseClickMazeElement = Substitute.For<FarthestMazeElementFromLastMouseClickMazeElement>(mouseBoundary);
        CurrentMazeElementChange(newCurrentMazeElementIndex);

        farthestMazeElementFromLastMouseClickMazeElement.UpdateIfCurrentMazeEleIsGreater(processDirection);

        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.x, newCurrentMazeElementIndex.x);
        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.y, currentMazeElementIndex.y);
    }

    [Test]
    public void _1_4_Update_RightProcessDirection_All_Neg()
    {
        Direction processDirection = Direction.Right;
        Vector2 currentMazeElementIndex = new Vector2(-4, -2);
        Vector2 newCurrentMazeElementIndex = new Vector2(-1, -1);
        mouseBoundary = GetMouseMock(currentMazeElementIndex);

        var farthestMazeElementFromLastMouseClickMazeElement = Substitute.For<FarthestMazeElementFromLastMouseClickMazeElement>(mouseBoundary);
        CurrentMazeElementChange(newCurrentMazeElementIndex);

        farthestMazeElementFromLastMouseClickMazeElement.UpdateIfCurrentMazeEleIsGreater(processDirection);

        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.x, newCurrentMazeElementIndex.x);
        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.y, currentMazeElementIndex.y);
    }

    [Test]
    public void _1_5_Update_RightProcessDirection_Current_Neg_Neg_New_Neg_Pos()
    {
        Direction processDirection = Direction.Right;
        Vector2 currentMazeElementIndex = new Vector2(-4, -2);
        Vector2 newCurrentMazeElementIndex = new Vector2(-1, 51);
        mouseBoundary = GetMouseMock(currentMazeElementIndex);

        var farthestMazeElementFromLastMouseClickMazeElement = Substitute.For<FarthestMazeElementFromLastMouseClickMazeElement>(mouseBoundary);
        CurrentMazeElementChange(newCurrentMazeElementIndex);

        farthestMazeElementFromLastMouseClickMazeElement.UpdateIfCurrentMazeEleIsGreater(processDirection);

        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.x, newCurrentMazeElementIndex.x);
        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.y, currentMazeElementIndex.y);
    }

    [Test]
    public void _1_6_Update_DownProcessDirection_All_Pos()
    {
        Direction processDirection = Direction.Down;
        Vector2 currentMazeElementIndex = new Vector2(4, 2);
        Vector2 newCurrentMazeElementIndex = new Vector2(1, 51);
        mouseBoundary = GetMouseMock(currentMazeElementIndex);

        var farthestMazeElementFromLastMouseClickMazeElement = Substitute.For<FarthestMazeElementFromLastMouseClickMazeElement>(mouseBoundary);
        CurrentMazeElementChange(newCurrentMazeElementIndex);

        farthestMazeElementFromLastMouseClickMazeElement.UpdateIfCurrentMazeEleIsGreater(processDirection);

        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.x, currentMazeElementIndex.x);
        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.y, newCurrentMazeElementIndex.y);
    }

    [Test]
    public void _1_7_Update_DownProcessDirection_Current_Neg_Zero_New_Neg_Pos()
    {
        Direction processDirection = Direction.Down;
        Vector2 currentMazeElementIndex = new Vector2(-4, 0);
        Vector2 newCurrentMazeElementIndex = new Vector2(-1, 4);
        mouseBoundary = GetMouseMock(currentMazeElementIndex);

        var farthestMazeElementFromLastMouseClickMazeElement = Substitute.For<FarthestMazeElementFromLastMouseClickMazeElement>(mouseBoundary);
        CurrentMazeElementChange(newCurrentMazeElementIndex);

        farthestMazeElementFromLastMouseClickMazeElement.UpdateIfCurrentMazeEleIsGreater(processDirection);

        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.x, currentMazeElementIndex.x);
        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.y, newCurrentMazeElementIndex.y);
    }

    [Test]
    public void _1_8_Update_UpProcessDirection_Current_Pos_Neg_New_Pos_Neg()
    {
        Direction processDirection = Direction.Up;
        Vector2 currentMazeElementIndex = new Vector2(1, -3);
        Vector2 newCurrentMazeElementIndex = new Vector2(5, -4);
        mouseBoundary = GetMouseMock(currentMazeElementIndex);

        var farthestMazeElementFromLastMouseClickMazeElement = Substitute.For<FarthestMazeElementFromLastMouseClickMazeElement>(mouseBoundary);
        CurrentMazeElementChange(newCurrentMazeElementIndex);

        farthestMazeElementFromLastMouseClickMazeElement.UpdateIfCurrentMazeEleIsGreater(processDirection);

        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.x, currentMazeElementIndex.x);
        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.y, newCurrentMazeElementIndex.y);
    }

    [Test]
    public void _1_9_Update_UpProcessDirection_Current_Neg_Pos_New_Pos_Neg()
    {
        Direction processDirection = Direction.Up;
        Vector2 currentMazeElementIndex = new Vector2(-1, 3);
        Vector2 newCurrentMazeElementIndex = new Vector2(5, -4);
        mouseBoundary = GetMouseMock(currentMazeElementIndex);

        var farthestMazeElementFromLastMouseClickMazeElement = Substitute.For<FarthestMazeElementFromLastMouseClickMazeElement>(mouseBoundary);
        CurrentMazeElementChange(newCurrentMazeElementIndex);

        farthestMazeElementFromLastMouseClickMazeElement.UpdateIfCurrentMazeEleIsGreater(processDirection);

        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.x, currentMazeElementIndex.x);
        Assert.AreEqual(farthestMazeElementFromLastMouseClickMazeElement.CurrentFarthestMazeElementIndex.y, newCurrentMazeElementIndex.y);
    }
}
