using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using NSubstitute;

public class CameraMovementPermitterTest {



    Vector2 screenDim = new Vector2(1920, 1080);
    float offset = 50;
    Vector3 startCamPosition = new Vector3(0, 0, 0);
    Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 1));

    private IMouse GetMouseMock(Vector3 fakeMousePosition)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.GetMousePosition().Returns(fakeMousePosition);


        return mouse;
    }

    private IElementsBounds GetElementsBoundsMock(Bounds gamePlaneBounds)
    {
        var elementsBounds = Substitute.For<IElementsBounds>();
        elementsBounds.GamePlaneBounds.Returns(gamePlaneBounds);

        return elementsBounds;
    }

    private ICameraMovementController GetCameraMovementControllerMock(Vector2 currentCameraPosition)
    {
        var cameraMovementController = Substitute.For<ICameraMovementController>();
        cameraMovementController.CurrentCameraPosition.Returns(currentCameraPosition);

        return cameraMovementController;
    }

    private ICameraMovementController GetCameraMovementControllerMock(float offset, Vector2 screenDim)
    {
        var cameraMovementController = Substitute.For<ICameraMovementController>();
        cameraMovementController.Offset.Returns(offset);
        cameraMovementController.ScreenHeight.Returns(screenDim.y);
        cameraMovementController.ScreenWidth.Returns(screenDim.x);

        return cameraMovementController;
    }
    #region IsMouseBehindOffset_InsideBounds
    [Test]
    public void _1_1_IsMouseBehindScreenOffset_MouseAtCenterPointOfScreen_ReturnFalse()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(screenDim.x/ 2, screenDim.y / 2, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Left);
        Assert.AreEqual(false, isMouseBehindScreenOffset);
    }

    [Test]
    public void _1_2_IsMouseBehindScreenOffset_MouseInsideGamePlaneBoundry_ReturnFalse()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(screenDim.x / 6, screenDim.y / 3, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Left);
        Assert.AreEqual(false, isMouseBehindScreenOffset);
    }
    #endregion
    #region IsMouseBehindScreenOffset_Left
    [Test]
    public void _2_1_IsMouseBehindScreenOffset_MouseBeneathLeftOffset_ReturnFalse()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(offset + 1, screenDim.y / 3, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Left);
        Assert.AreEqual(false, isMouseBehindScreenOffset);
    }

    [Test]
    public void _2_2_IsMouseBehindScreenOffset_MouseAtLeftOffset_ReturnFalse()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(offset, screenDim.y / 3, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Left);
        Assert.AreEqual(false, isMouseBehindScreenOffset);
    }

    [Test]
    public void _2_3_IsMouseBehindScreenOffset_MouseBehindLeftOffset_ReturnTrue()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(offset - 1, screenDim.y / 3, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Left);
        Assert.AreEqual(true, isMouseBehindScreenOffset);
    }
    #endregion
    #region IsMouseBehindScreenOffset_Down
    [Test]
    public void _3_1_IsMouseBehindScreenOffset_MouseBeneathDownOffset_ReturnFalse()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(screenDim.x / 3, offset + 1, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Down);
        Assert.AreEqual(false, isMouseBehindScreenOffset);
    }

    [Test]
    public void _3_2_IsMouseBehindScreenOffset_MouseAtDownOffset_ReturnFalse()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(screenDim.x / 3, offset, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Down);
        Assert.AreEqual(false, isMouseBehindScreenOffset);
    }

    [Test]
    public void _3_3_IsMouseBehindScreenOffset_MouseBehindDownOffset_ReturnTrue()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(screenDim.x / 3, offset - 1, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Down);
        Assert.AreEqual(true, isMouseBehindScreenOffset);
    }
    #endregion
    #region IsMouseBehindScreenOffset_Right
    [Test]
    public void _4_1_IsMouseBehindScreenOffset_MouseBeneathRightOffset_ReturnFalse()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(screenDim.x - (offset + 1), screenDim.y / 3, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Right);
        Assert.AreEqual(false, isMouseBehindScreenOffset);
    }

    [Test]
    public void _4_2_IsMouseBehindScreenOffset_MouseAtRightOffset_ReturnFalse()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(screenDim.x - offset, screenDim.y / 3, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Right);
        Assert.AreEqual(false, isMouseBehindScreenOffset);
    }

    [Test]
    public void _4_3_IsMouseBehindScreenOffset_MouseBehindRightOffset_ReturnTrue()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(screenDim.x - (offset - 1), screenDim.y / 3, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Right);
        Assert.AreEqual(true, isMouseBehindScreenOffset);
    }

    [Test]
    public void _4_4_IsMouseBehindScreenOffset_MouseBehindRightOffset_ReturnTrue()
    {
        bool isMouseBehindScreenOffset;

        Vector3 fakeMousePosition = new Vector3(screenDim.x + offset, screenDim.y / 3, 0);
        var mouse = GetMouseMock(fakeMousePosition);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, screenDim);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isMouseBehindScreenOffset = cameraMovementPermitter.IsMouseBehindScreenOffset(Direction.Right);
        Assert.AreEqual(true, isMouseBehindScreenOffset);
    }
    #endregion
    #region IscameraCenterInsideGamePlaneSquare_InsideBounds
    [Test]
    public void _5_1_IsCameraCenterInsideGamePlaneSquare()
    {
        bool isCameraCenterInsideGamePlanesquare;

        Vector2 currentCameraPosition = gamePlaneBounds.center;
        var mouse = Substitute.For<IMouse>();
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(currentCameraPosition);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isCameraCenterInsideGamePlanesquare = cameraMovementPermitter.IsCameraCenterInsideGamePlaneSquare(Direction.Left);
        Assert.AreEqual(true, isCameraCenterInsideGamePlanesquare);
    }

    [Test]
    public void _5_2_IsCameraCenterInsideGamePlaneSquare_CameraInsideGamePlaneBounds_ReturnTrue()
    {
        bool isCameraCenterInsideGamePlanesquare;

        Vector2 currentCameraPosition = new Vector2(gamePlaneBounds.extents.x / 2, gamePlaneBounds.extents.y / 2);
        var mouse = Substitute.For<IMouse>();
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(currentCameraPosition);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isCameraCenterInsideGamePlanesquare = cameraMovementPermitter.IsCameraCenterInsideGamePlaneSquare(Direction.Left);
        Assert.AreEqual(true, isCameraCenterInsideGamePlanesquare);
    }
    #endregion
    #region IscameraCenterInsideGamePlaneSquare_Left
    [Test]
    public void _6_1_IsCameraCenterInsideGamePlaneSquare_CameraBeneathLeftGamePlaneSide_ReturnTrue()
    {
        bool isCameraCenterInsideGamePlanesquare;

        Vector2 currentCameraPosition = new Vector2(-gamePlaneBounds.extents.x + 1, gamePlaneBounds.extents.y / 2);
        var mouse = Substitute.For<IMouse>();
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(currentCameraPosition);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isCameraCenterInsideGamePlanesquare = cameraMovementPermitter.IsCameraCenterInsideGamePlaneSquare(Direction.Left);
        Assert.AreEqual(true, isCameraCenterInsideGamePlanesquare);
    }

    [Test]
    public void _6_4_IsCameraCenterInsideGamePlaneSquare_CameraAtLeftGamePlaneSide_ReturnTrue()
    {
        bool isCameraCenterInsideGamePlanesquare;

        Vector2 currentCameraPosition = new Vector2(-gamePlaneBounds.extents.x, gamePlaneBounds.extents.y / 2);
        var mouse = Substitute.For<IMouse>();
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(currentCameraPosition);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isCameraCenterInsideGamePlanesquare = cameraMovementPermitter.IsCameraCenterInsideGamePlaneSquare(Direction.Left);
        Assert.AreEqual(true, isCameraCenterInsideGamePlanesquare);
    }

    [Test]
    public void _6_5_IsCameraCenterInsideGamePlanesquare_CameraBehindLeftGamePlaneSide_ReturnFalse()
    {
        bool isCameraCenterInsideGamePlanesquare;

        Vector2 currentCameraPosition = new Vector2(-gamePlaneBounds.extents.x - 1, gamePlaneBounds.extents.y / 2);
        var mouse = Substitute.For<IMouse>();
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(currentCameraPosition);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isCameraCenterInsideGamePlanesquare = cameraMovementPermitter.IsCameraCenterInsideGamePlaneSquare(Direction.Left);
        Assert.AreEqual(false, isCameraCenterInsideGamePlanesquare);
    }
    #endregion
    #region IsCameraCenterInsideGamePlaneSquere_Down
    [Test]
    public void _7_1_IsCameraCenterInsideGamePlaneSquare_CameraBeneathDownGamePlaneSide_ReturnTrue()
    {
        bool isCameraCenterInsideGamePlanesquare;

        Vector2 currentCameraPosition = new Vector2(gamePlaneBounds.extents.x / 2, -gamePlaneBounds.extents.y + 1);
        var mouse = Substitute.For<IMouse>();
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(currentCameraPosition);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isCameraCenterInsideGamePlanesquare = cameraMovementPermitter.IsCameraCenterInsideGamePlaneSquare(Direction.Down);
        Assert.AreEqual(true, isCameraCenterInsideGamePlanesquare);
    }

    [Test]
    public void _7_1_IsCameraCenterInsideGamePlaneSquare_CameraAtDownGamePlaneSide_ReturnTrue()
    {
        bool isCameraCenterInsideGamePlanesquare;

        Vector2 currentCameraPosition = new Vector2(gamePlaneBounds.extents.x / 2, -gamePlaneBounds.extents.y);
        var mouse = Substitute.For<IMouse>();
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(currentCameraPosition);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isCameraCenterInsideGamePlanesquare = cameraMovementPermitter.IsCameraCenterInsideGamePlaneSquare(Direction.Down);
        Assert.AreEqual(true, isCameraCenterInsideGamePlanesquare);
    }

    [Test]
    public void _7_3_IsCameraCenterInsideGamePlanesquare_CameraBehindDownGamePlaneSide_ReturnFalse()
    {
        bool isCameraCenterInsideGamePlanesquare;

        Vector2 currentCameraPosition = new Vector2(gamePlaneBounds.extents.x / 2, -gamePlaneBounds.extents.y - 1);
        var mouse = Substitute.For<IMouse>();
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(currentCameraPosition);

        var cameraMovementPermitter = Substitute.For<CameraMovementPermitter>(mouse, cameraMovementController, elemensBounds);

        isCameraCenterInsideGamePlanesquare = cameraMovementPermitter.IsCameraCenterInsideGamePlaneSquare(Direction.Down);
        Assert.AreEqual(false, isCameraCenterInsideGamePlanesquare);
    }
    #endregion
}
