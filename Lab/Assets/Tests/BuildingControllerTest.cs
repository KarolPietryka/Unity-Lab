using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using NSubstitute;


public class BuildingControllerTest {


    private IInputProvider GetInputProviderMock(Vector3 fakeMousePosition)
    {
        var inputProvider = Substitute.For<IInputProvider>();
        inputProvider.GetMousePosition().Returns(fakeMousePosition);

        return inputProvider;
    }

    private IInputProvider GetInputProviderMock(Vector3 fakeMousePosition, Direction moveInReferenceToLastClick)
    {
        var inputProvider = Substitute.For<IInputProvider>();
        inputProvider.GetMousePosition().Returns(fakeMousePosition);

        if (moveInReferenceToLastClick == Direction.Left || moveInReferenceToLastClick == Direction.Right)
        {
            inputProvider.WasHorizontalMoveInReferenceToLastClick().Returns(true);
        }
        else if (moveInReferenceToLastClick == Direction.Up || moveInReferenceToLastClick == Direction.Down)
        {
            inputProvider.WasHorizontalMoveInReferenceToLastClick().Returns(false);
        }
        else
        {
            throw new System.ArgumentException("Bad enum was passed");
        }

        return inputProvider;
    }
    
    private IMouse getMouseMock(Vector3 LastMouseClickPosition)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.LastMouseClickPosition.Returns(LastMouseClickPosition);

        return mouse;
    }
    private BuildingController getBuildingControllerMock(IInputProvider inputProvider, IMouse mouse)
    {
        var buildingController = Substitute.For<BuildingController>();
        buildingController.SetInputProvider(inputProvider);
        buildingController.SetMouse(mouse);
        return buildingController;
    }

    #region SetBuildingStatus
    [Test]
    public void _1_1_SetBuildingStatusOnBuilding_ReturnEnumBuilding()
    {
        var buildingController = Substitute.For<BuildingController>();       
        bool isCurrentMazeElementMazeWall = false;
        buildingController.SetBuldingStatus(isCurrentMazeElementMazeWall);

        Assert.AreEqual(buildingController.BuildingStatus, BuildingStatus.Building);
    }

    [Test]
    public void _1_2_SetBuildingStatusOnDismantling_ReturnDismantling()
    {
        var buildingController = Substitute.For<BuildingController>();     
        bool isCurrentMazeElementMazeWall = true;
        buildingController.SetBuldingStatus(isCurrentMazeElementMazeWall);

        Assert.AreEqual(buildingController.BuildingStatus, BuildingStatus.Dismantling);
    }
    #endregion

    #region UpdateBuildingDirection
    [Test]
    public void _2_1_UpdateBuildingDirection_BothVectorHavePositiveXYValues_ReturnBuildingDirectonEnumHLeft()
    {
        Vector3 fakeMousePosition = new Vector3(10, 3, 0);
        Vector3 LastMouseClickPosition = new Vector3(14, 0, 0);

        var inputProvider = GetInputProviderMock(fakeMousePosition, Direction.Left);
        var mouse = getMouseMock(LastMouseClickPosition);
        var buildingController = getBuildingControllerMock(inputProvider, mouse);// inputMemory);

        Direction buildingDirection = buildingController.UpdateBuildingDirection();

        Assert.AreEqual(buildingDirection, Direction.Left);
    }
    
    [Test]
    public void _2_2_UpdateBuildingDirection_VectorHaveAlternatingXYValues_ReturnBuildingDirectonEnumLeft()
    {
        Vector3 fakeMousePosition = new Vector3(-0.01f, 0, 0);
        Vector3 LastMouseClickPosition = new Vector3(0, 0, 0);

        var inputProvider = GetInputProviderMock(fakeMousePosition, Direction.Left);
        var mouse = getMouseMock(LastMouseClickPosition);
        var buildingController = getBuildingControllerMock(inputProvider, mouse);

        Direction buildingDirection = buildingController.UpdateBuildingDirection();

        Assert.AreEqual(buildingDirection, Direction.Left);
    }

    [Test]
    public void _2_3_UpdateBuildingDirection_VectorHaveAlternatingXYValues_ReturnBuildingDirectonEnumRight()
    {
        Vector3 fakeMousePosition = new Vector3(3, 0, 0);
        Vector3 LastMouseClickPosition = new Vector3(0, 2, 0);

        var inputProvider = GetInputProviderMock(fakeMousePosition, Direction.Right);
        var mouse = getMouseMock(LastMouseClickPosition);
        var buildingController = getBuildingControllerMock(inputProvider, mouse);

        Direction buildingDirection = buildingController.UpdateBuildingDirection();

        Assert.AreEqual(buildingDirection, Direction.Right);
    }

    [Test]
    public void _2_4_UpdateBuildingDirection__BothVectorHaveNegativeXYValues_ReturnBuildingDirectonEnumUP()
    {
        Vector3 fakeMousePosition = new Vector3(-3, -10, 0);
        Vector3 LastMouseClickPosition = new Vector3(-1, -100, 0);

        var inputProvider = GetInputProviderMock(fakeMousePosition, Direction.Up);
        var mouse = getMouseMock(LastMouseClickPosition);
        var buildingController = getBuildingControllerMock(inputProvider, mouse);

        Direction buildingDirection = buildingController.UpdateBuildingDirection();

        Assert.AreEqual(buildingDirection, Direction.Up);
    }

    [Test]
    public void _2_5_UpdateBuildingDirection__BothVectorHaveAlternatingXYValues_ReturnBuildingDirectonEnumDown()
    {
        Vector3 fakeMousePosition = new Vector3(-3, -10, 0);
        Vector3 LastMouseClickPosition = new Vector3(-1, 10, 0);

        var inputProvider = GetInputProviderMock(fakeMousePosition, Direction.Down);
        var mouse = getMouseMock(LastMouseClickPosition);
        var buildingController = getBuildingControllerMock(inputProvider, mouse);

        Direction buildingDirection = buildingController.UpdateBuildingDirection();

        Assert.AreEqual(buildingDirection, Direction.Down);
    }

    [Test]
    public void _6_1_UpdateBuildingDirection__BothVectorHaveAlternatingXYValues_ReturnBuildingDirectonEnumDown()
    {
        Vector3 fakeMousePosition = new Vector3(-11, -6, 0);
        Vector3 LastMouseClickPosition = new Vector3(2, 10, 0);

        var inputProvider = GetInputProviderMock(fakeMousePosition, Direction.Down);
        var mouse = getMouseMock(LastMouseClickPosition);
        var buildingController = getBuildingControllerMock(inputProvider, mouse);

        Direction buildingDirection = buildingController.UpdateBuildingDirection();

        Assert.AreEqual(buildingDirection, Direction.Down);
    }
    #endregion


}
