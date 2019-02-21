using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class ProcessDirectionTest {

    private IMouse GetMouseMock(Vector3 lastMouseClickPosition, Vector3 currentMousePosition, bool wasHorizontalMoveInReferenceToLastClick)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.GetMousePosition().Returns(currentMousePosition);
        mouse.LastMouseClickPosition.Returns(lastMouseClickPosition);
        mouse.WasHorizontalMoveInReferenceToLastClick().Returns(wasHorizontalMoveInReferenceToLastClick);

        return mouse;
    }

    #region UpdateProcessDirection
    [Test]
    public void _1_1_UpdateProcessDirection_BothVectorHavePositiveXYValues_ReturnBuildingDirectonEnumHLeft()
    {
        Vector3 currentMousePosition = new Vector3(10, 3, 0);
        Vector3 lastMouseClickPosition = new Vector3(14, 0, 0);
        bool wasHorizontalMoveInReferenceToLastClick = true;

        var mouse = GetMouseMock(lastMouseClickPosition, currentMousePosition, wasHorizontalMoveInReferenceToLastClick);
        var processDirectionUpdate = Substitute.For<ProcessDirectionUpdate>(mouse);

        Direction updatedProcessDirection = processDirectionUpdate.ExecuteUpdate();

        Assert.AreEqual(updatedProcessDirection, Direction.Left);
    }
    
    [Test]
    public void _1_2_UpdateProcessDirection_VectorHaveAlternatingXYValues_ReturnBuildingDirectonEnumLeft()
    {
        Vector3 currentMousePosition = new Vector3(-0.01f, 0, 0);
        Vector3 lastMouseClickPosition = new Vector3(0, 0, 0);
        bool wasHorizontalMoveInReferenceToLastClick = true;

        var mouse = GetMouseMock(lastMouseClickPosition, currentMousePosition, wasHorizontalMoveInReferenceToLastClick);
        var processDirectionUpdate = Substitute.For<ProcessDirectionUpdate>(mouse);

        Direction updatedProcessDirection = processDirectionUpdate.ExecuteUpdate();

        Assert.AreEqual(updatedProcessDirection, Direction.Left);
    }

    [Test]
    public void _1_3_UpdateProcessDirection_VectorHaveAlternatingXYValues_ReturnBuildingDirectonEnumRight()
    {
        Vector3 currentMousePosition = new Vector3(3, 0, 0);
        Vector3 lastMouseClickPosition = new Vector3(0, 2, 0);
        bool wasHorizontalMoveInReferenceToLastClick = true;

        var mouse = GetMouseMock(lastMouseClickPosition, currentMousePosition, wasHorizontalMoveInReferenceToLastClick);
        var processDirectionUpdate = Substitute.For<ProcessDirectionUpdate>(mouse);

        Direction updatedProcessDirection = processDirectionUpdate.ExecuteUpdate();

        Assert.AreEqual(updatedProcessDirection, Direction.Right);
    }

    [Test]
    public void _1_4_UpdateProcessDirection__BothVectorHaveNegativeXYValues_ReturnBuildingDirectonEnumUP()
    {
        Vector3 currentMousePosition = new Vector3(-3, -10, 0);
        Vector3 lastMouseClickPosition = new Vector3(-1, -100, 0);
        bool wasHorizontalMoveInReferenceToLastClick = false;

        var mouse = GetMouseMock(lastMouseClickPosition, currentMousePosition, wasHorizontalMoveInReferenceToLastClick);
        var processDirectionUpdate = Substitute.For<ProcessDirectionUpdate>(mouse);

        Direction updatedProcessDirection = processDirectionUpdate.ExecuteUpdate();

        Assert.AreEqual(updatedProcessDirection, Direction.Up);
    }

    [Test]
    public void _1_5_UpdateProcessDirection__BothVectorHaveAlternatingXYValues_ReturnBuildingDirectonEnumDown()
    {
        Vector3 currentMousePosition = new Vector3(-3, -10, 0);
        Vector3 lastMouseClickPosition = new Vector3(-1, 10, 0);
        bool wasHorizontalMoveInReferenceToLastClick = false;

        var mouse = GetMouseMock(lastMouseClickPosition, currentMousePosition, wasHorizontalMoveInReferenceToLastClick);
        var processDirectionUpdate = Substitute.For<ProcessDirectionUpdate>(mouse);

        Direction updatedProcessDirection = processDirectionUpdate.ExecuteUpdate();

        Assert.AreEqual(updatedProcessDirection, Direction.Down);
    }

    [Test]
    public void _1_6_UpdateProcessDirection__BothVectorHaveAlternatingXYValues_ReturnBuildingDirectonEnumDown()
    {
        Vector3 currentMousePosition = new Vector3(-11, -6, 0);
        Vector3 lastMouseClickPosition = new Vector3(2, 10, 0);
        bool wasHorizontalMoveInReferenceToLastClick = false;

        var mouse = GetMouseMock(lastMouseClickPosition, currentMousePosition, wasHorizontalMoveInReferenceToLastClick);
        var processDirectionUpdate = Substitute.For<ProcessDirectionUpdate>(mouse);

        Direction updatedProcessDirection = processDirectionUpdate.ExecuteUpdate();

        Assert.AreEqual(updatedProcessDirection, Direction.Down);
    }
    #endregion
}
