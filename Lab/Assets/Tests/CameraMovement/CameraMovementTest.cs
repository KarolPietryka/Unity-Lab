using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;


public class CameraMovementTest
{
    float fakeDeltaTime = 0.016f;
    float screenWidth = 1920;
    float screenHeight = 1080;
    float offset = 50;
    float xySpeed = 1;
    Vector3 startCamPosition = new Vector3(0, 0, 0);
    Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 1));
    float scrollSpeed = 2;
    Vector2 scrollWheelLimits = new Vector2(3, 15);


    private IMouse GetMouseMock(Vector3 fakeMousePosition, float mouseScrollWheel)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.GetMousePosition().Returns(fakeMousePosition);
        mouse.GetMouseScrollWheel().Returns(mouseScrollWheel);

        return mouse;
    }

    private IElementsBounds GetElementsBoundsMock(Bounds gamePlaneBounds)
    {
        var elementsBounds = Substitute.For<IElementsBounds>();
        elementsBounds.GamePlaneBounds.Returns(gamePlaneBounds);

        return elementsBounds;
    }

    private ICameraMovementController GetCameraMovementControllerMock(float offset, float xySpeed, Vector2 currentCameraPosition)
    {
        var cameraMovementController = Substitute.For<ICameraMovementController>();
        cameraMovementController.Offset.Returns(offset);
        cameraMovementController.XYSpeed.Returns(xySpeed);
        cameraMovementController.CurrentCameraPosition.Returns(currentCameraPosition);

        return cameraMovementController;
    }

    private ICameraMovementController GetCameraMovementControllerMock(float offset, float xySpeed, float fakeDeltaTime)
    {
        var cameraMovementController = Substitute.For<ICameraMovementController>();
        cameraMovementController.CameraMovementDistance(xySpeed).Returns(xySpeed * fakeDeltaTime);
        cameraMovementController.Offset.Returns(offset);
        cameraMovementController.XYSpeed.Returns(xySpeed);

        return cameraMovementController;
    }

    private CameraMovement GetCameraMovementMock(IMouse mouse, ICameraMovementController cameraMovementController, IElementsBounds elementsBounds)
    {
        var cameraMovement = Substitute.For<CameraMovement>();
        cameraMovement.SetMouse(mouse);
        cameraMovement.SetCameraMovementController(cameraMovementController);
        cameraMovement.SetElementsBounds(elementsBounds);

        return cameraMovement;
    }
   /* #region 1 AxisMovement
    [Test]
    public void _1_1_AxisMovement_MouseInTheMiddleOfScreen_NoCameraMove()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight / 2, 0);
        Vector3 oldCameraPosition = startCamPosition;
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 1));

        float offset = 5;
        var inputProvider = GetInputProviderMock(fakeMousePosition, 1);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, xySpeed);

        var cameraMovement = GetCameraMovementMock(inputProvider, cameraMovementController, elemensBounds);

        Vector3 newCamPosition = cameraMovement.AxisMovement();

        Assert.AreEqual(oldCameraPosition, newCamPosition);
       // Assert.AreEqual(new Vector3(oldCameraPosition.x + 1.0f, oldCameraPosition.y + 1.0f, oldCameraPosition.z + 1.0f), newCamPosition);//startCamPosition, newCamPosition);
    }
    
    [Test]
    public void _1_2_AxisMovement_MouseBetweenScreenLimits_NoCameraMove()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 4, screenHeight / 3, 0);
        Vector3 oldCameraPosition = startCamPosition;
        var inputProvider = GetInputProviderMock(fakeMousePosition, 1);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, xySpeed);

        var cameraMovement = GetCameraMovementMock(inputProvider, cameraMovementController, elemensBounds);

        Vector3 newCamPosition = cameraMovement.AxisMovement();

        Assert.AreEqual(oldCameraPosition, newCamPosition);
  
    }
    
    [Test]
    public void _3_1_AxisMovement_MouseExcatlyOnScreenHightLimit_NoCameraMove_XCheck()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth - offset, screenHeight / 2, 0);
        Vector3 oldCameraPosition = startCamPosition;
        var inputProvider = GetInputProviderMock(fakeMousePosition, 1);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, xySpeed);

        var cameraMovement = GetCameraMovementMock(inputProvider, cameraMovementController, elemensBounds);

        Vector3 newCamPosition = cameraMovement.AxisMovement();

        Assert.AreEqual(oldCameraPosition.x, newCamPosition.x);

    }
    
    [Test]
    public void _3_2_AxisMovement_MouseExcatlyOnScreenHightLimit_NoCameraMove_YCheck()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - offset, 0);
        Vector3 oldCameraPosition = startCamPosition;
        var inputProvider = GetInputProviderMock(fakeMousePosition, 1);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, xySpeed);

        var cameraMovement = GetCameraMovementMock(inputProvider, cameraMovementController, elemensBounds);

        Vector3 newCamPosition = cameraMovement.AxisMovement();

        Assert.AreEqual(oldCameraPosition.y, newCamPosition.y);
    }
    
    [Test]
    public void _4_1_AxisMovement_MouseAboveScreenHightLimit_CameraMoveOnYAxis_XCheck()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth - (offset - 1), screenHeight / 2, 0);
        Vector3 oldCameraPosition = startCamPosition;
        var inputProvider = GetInputProviderMock(fakeMousePosition, 1);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, xySpeed);

        var cameraMovement = GetCameraMovementMock(inputProvider, cameraMovementController, elemensBounds);

        Vector3 newCamPosition = cameraMovement.AxisMovement();
        float camMove = xySpeed * fakeDeltaTime;

        Debug.Log(camMove);
        Assert.AreEqual(oldCameraPosition.x + camMove, newCamPosition.x);
    }
    
    [Test]
    public void _4_2_AxisMovement_MouseAboveScreenHightLimit_CameraMoveOnYAxis_YCheck()
    {

        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - (offset - 1), 0);
        Vector3 oldCameraPosition = startCamPosition;
        var inputProvider = GetInputProviderMock(fakeMousePosition, 1);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, xySpeed);

        var cameraMovement = GetCameraMovementMock(inputProvider, cameraMovementController, elemensBounds);

        Vector3 newCamPosition = cameraMovement.AxisMovement();
        float camMove = cameraMovement.CameraMovementDistance(xySpeed);

        Assert.AreEqual(startCamPosition.y + camMove, newCamPosition.y);
    }
    #endregion*/

    #region CanCameraMoveInDirection
    [Test]
    public void _2_1_ShouldCameraMoveInDirection()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - (offset - 1), 0);
        Vector3 oldCameraPosition = startCamPosition;
        Vector2 currentCameraPosition = new Vector3(0, 0);

        var inputProvider = GetMouseMock(fakeMousePosition, 1);
        var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, xySpeed, currentCameraPosition);

        bool shouldCameraMoveInDirection = cameraMovementController.ShouldCameraMoveInDirection(Direction.Down);
        Assert.AreEqual(false, shouldCameraMoveInDirection);
    }

    [Test]
    public void _2_2_ShouldCameraMoveInDirection()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - (offset + 1), 0);
        Vector3 oldCameraPosition = startCamPosition;
        Vector2 currentCameraPosition = new Vector3(0, 0);

        var inputProvider = GetMouseMock(fakeMousePosition, 1);
        //var elemensBounds = GetElementsBoundsMock(gamePlaneBounds);
        var cameraMovementController = GetCameraMovementControllerMock(offset, xySpeed, currentCameraPosition);

        bool shouldCameraMoveInDirection = cameraMovementController.ShouldCameraMoveInDirection(Direction.Down);
        Assert.AreEqual(false, shouldCameraMoveInDirection);
    }
    #endregion
}
