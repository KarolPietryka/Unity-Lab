using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class CameraScrollTest {

    float screenWidth = 1920;
    float screenHeight = 1080;
    float scrollSpeed = 2;
    Vector2 scrollWheelLimit = new Vector2(3, 15);

    private IMouse getMouseMock(Vector3 fakeMousePosition, float mouseScrollWheel)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.GetMousePosition().Returns(fakeMousePosition);
        mouse.GetMouseScrollWheel().Returns(mouseScrollWheel);

        return mouse;
    }

    private ICameraMovementController getCameraMovementController(float cameraOldOrthographicSize, Vector2 scrollWheelLimit, float scrollSpeed)
    {
        var cameraMovementController = Substitute.For<ICameraMovementController>();
        cameraMovementController.CameraOrthographicSize.Returns(cameraOldOrthographicSize);
        cameraMovementController.ScrollWheelLimit.Returns(scrollWheelLimit);
        cameraMovementController.ScrollSpeed.Returns(scrollSpeed);

        return cameraMovementController;
    }

    private CameraScroll getCameraScrollMock(IMouse mouse, ICameraMovementController cameraMovementController)
    {
        var cameraScroll = Substitute.For<CameraScroll>();
        cameraScroll.SetMouse(mouse);
        cameraScroll.SetCameraMovementController(cameraMovementController);
        return cameraScroll;
    }

    [Test]
    public void _1_1_MouseScrollWheel_Up_CameraUnZoom([Values(1, 4988, 14.763f)] float mouseScrollWheelValue)
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight / 2, 0);
        float cameraOldOrthographicSize = 10;
        var mouse = getMouseMock(fakeMousePosition, mouseScrollWheelValue);
        var cameraMovementController = getCameraMovementController(cameraOldOrthographicSize, scrollWheelLimit, scrollSpeed);
        var cameraScroll = getCameraScrollMock(mouse, cameraMovementController);

        float cameraOrthographicSize = cameraScroll.ScrollWheel();

        Assert.AreEqual(cameraOrthographicSize, cameraOldOrthographicSize - scrollSpeed);
    }
    
    [Test]
    public void _1_2_MouseScrollWheel_Down_CameraZoom([Values(-1, -0.48f, -14.763f)] float mouseScrollWheelValue)
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight / 2, 0);
        float cameraOldOrthographicSize = 10;
        var mouse = getMouseMock(fakeMousePosition, mouseScrollWheelValue);
        var cameraMovementController = getCameraMovementController(cameraOldOrthographicSize, scrollWheelLimit, scrollSpeed);
        var cameraScroll = getCameraScrollMock(mouse, cameraMovementController);

        float cameraOrthographicSize = cameraScroll.ScrollWheel();

        Assert.AreEqual(cameraOrthographicSize, cameraOldOrthographicSize + scrollSpeed);

    }

    [Test]
    public void _2_1_ScrollWheel_NoMouseScroll_CameraNoMove()
    {
        float mouseScrollWheelValue = 0;
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight / 2, 0);
        float cameraOldOrthographicSize = 10;
        var mouse = getMouseMock(fakeMousePosition, mouseScrollWheelValue);
        var cameraMovementController = getCameraMovementController(cameraOldOrthographicSize, scrollWheelLimit, scrollSpeed);
        var cameraScroll = getCameraScrollMock(mouse, cameraMovementController);

        float cameraOrthographicSize = cameraScroll.ScrollWheel();

        Assert.AreEqual(cameraOrthographicSize, cameraOldOrthographicSize);
    }

    [Test]
    public void _3_1_MouseScrollWheel_CamOrthographicSizeUnderLimitScrollDown_CameraZoom([Values(-1, -0.48f, -14.763f)] float mouseScrollWheelValue)
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight / 2, 0);
        float cameraOldOrthographicSize = 1;
        var mouse = getMouseMock(fakeMousePosition, mouseScrollWheelValue);
        var cameraMovementController = getCameraMovementController(cameraOldOrthographicSize, scrollWheelLimit, scrollSpeed);
        var cameraScroll = getCameraScrollMock(mouse, cameraMovementController);

        float cameraOrthographicSize = cameraScroll.ScrollWheel();

        Assert.AreEqual(cameraOrthographicSize, cameraOldOrthographicSize + 2);
    }

    [Test]
    public void _3_1_MouseScrollWheel_CamOrthographicSizeOverLimitScrollDown_CameraUnZoom([Values(1, 0.48f, 14.763f)] float mouseScrollWheelValue)
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight / 2, 0);
        float cameraOldOrthographicSize = 15;
        var mouse = getMouseMock(fakeMousePosition, mouseScrollWheelValue);
        var cameraMovementController = getCameraMovementController(cameraOldOrthographicSize, scrollWheelLimit, scrollSpeed);
        var cameraScroll = getCameraScrollMock(mouse, cameraMovementController);

        float cameraOrthographicSize = cameraScroll.ScrollWheel();

        Assert.AreEqual(cameraOrthographicSize, cameraOldOrthographicSize - scrollSpeed);
    }
}
