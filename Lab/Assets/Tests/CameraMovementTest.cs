using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
//using Moq;


public class CameraMovementTest
{
    float fakeDeltaTime = 0.016f;
    float screenWidth = 1920;
    float screenHeight = 1080;
    float offset = 50;
    float speed = 1;
    float scrollSpeed = 2;
    Vector2 minMaxXPosition = new Vector2(-100, 100);
    Vector2 minMaxYPosition = new Vector2(-100, 100);
    Vector3 startCamPosition = new Vector3(0, 0, 0);
    Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 1));


    [Test]
    public void _1_AxisMovement_MouseInTheMiddleOfScreen_NoCameraMove()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight / 2, 0);
        Vector3 oldCameraPosition = startCamPosition;

        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(fakeMousePosition);
        ITimeProvider timeProvider = new FakeTimeProvider(fakeDeltaTime);
        IMouseScrollWheelProvider mouseScrollWheelProvider = new FakeMouseWheelProvider(1);

        CameraMovement cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);

        Vector3 newCamPosition = cameraMovement.AxisMovement(offset, speed, gamePlaneBounds, startCamPosition);

        Assert.AreEqual(startCamPosition, newCamPosition);
    }

    [Test]
    public void _2_AxisMovement_MouseBetweenScreenLimits_NoCameraMove()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 4, screenHeight / 3, 0);
        Vector3 oldCameraPosition = startCamPosition;

        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(fakeMousePosition);
        ITimeProvider timeProvider = new FakeTimeProvider(fakeDeltaTime);
        IMouseScrollWheelProvider mouseScrollWheelProvider = new FakeMouseWheelProvider(1);

        CameraMovement cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);

        Vector3 newCamPosition = cameraMovement.AxisMovement(offset, speed, gamePlaneBounds, startCamPosition);

        Assert.AreEqual(startCamPosition, newCamPosition);
    }

    [Test]
    public void _3_AxisMovement_MouseExcatlyOnScreenHightLimit_NoCameraMove_XCheck()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth - offset, screenHeight / 2, 0);
        Vector3 oldCameraPosition = startCamPosition;

        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(fakeMousePosition);
        ITimeProvider timeProvider = new FakeTimeProvider(fakeDeltaTime);
        IMouseScrollWheelProvider mouseScrollWheelProvider = new FakeMouseWheelProvider(1);

        CameraMovement cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);

        Vector3 newCamPosition = cameraMovement.AxisMovement(offset, speed, gamePlaneBounds, startCamPosition);

        Assert.AreEqual(startCamPosition.x, newCamPosition.x);

    }

    [Test]
    public void _4_AxisMovement_MouseExcatlyOnScreenHightLimit_NoCameraMove_YCheck()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - offset, 0);
        Vector3 oldCameraPosition = startCamPosition;

        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(fakeMousePosition);
        ITimeProvider timeProvider = new FakeTimeProvider(fakeDeltaTime);
        IMouseScrollWheelProvider mouseScrollWheelProvider = new FakeMouseWheelProvider(1);

        CameraMovement cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);

        Vector3 newCamPosition = cameraMovement.AxisMovement(offset, speed, gamePlaneBounds, startCamPosition);

        Assert.AreEqual(startCamPosition.y, newCamPosition.y);
    }

    [Test]
    public void _5_AxisMovement_MouseAboveScreenHightLimit_CameraMoveOnYAxis_XCheck()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth - (offset - 1), screenHeight / 2, 0);
        Vector3 oldCameraPosition = startCamPosition;

        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(fakeMousePosition);
        ITimeProvider timeProvider = new FakeTimeProvider(fakeDeltaTime);
        IMouseScrollWheelProvider mouseScrollWheelProvider = new FakeMouseWheelProvider(1);

        CameraMovement cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);

        Vector3 newCamPosition = cameraMovement.AxisMovement(offset, speed, gamePlaneBounds, startCamPosition);
        float camMove = cameraMovement.cameraMovementDistance(speed);

        Assert.AreEqual(startCamPosition.x + camMove, newCamPosition.x);
    }

    [Test]
    public void _6_AxisMovement_MouseAboveScreenHightLimit_CameraMoveOnYAxis_YCheck()
    {

        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - (offset - 1), 0);
        Vector3 oldCameraPosition = startCamPosition;

        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(fakeMousePosition);
        ITimeProvider timeProvider = new FakeTimeProvider(fakeDeltaTime);
        IMouseScrollWheelProvider mouseScrollWheelProvider = new FakeMouseWheelProvider(1);

        CameraMovement cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);

        Vector3 newCamPosition = cameraMovement.AxisMovement(offset, speed, gamePlaneBounds, startCamPosition);
        float camMove = cameraMovement.cameraMovementDistance(speed);

        Assert.AreEqual(startCamPosition.y + camMove, newCamPosition.y);
    }

    [Test]
    public void _7_MouseScrollWheel_Up_MoveCameraUp([Values(1, 4988, 14.763f)] float mouseScrollWheelValue)
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - (offset - 1), 0);

        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(fakeMousePosition);
        ITimeProvider timeProvider = new FakeTimeProvider(fakeDeltaTime);
        IMouseScrollWheelProvider mouseScrollWheelProvider = new FakeMouseWheelProvider(mouseScrollWheelValue);

        float cameraOldOrthographicSize = 10;

        Vector2 scrollWheelLimits = new Vector2(3, 15);

        CameraMovement cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);

        float cameraOrthographicSize = cameraMovement.ScrollWheel(scrollSpeed, cameraOldOrthographicSize, scrollWheelLimits);

        Assert.AreEqual(cameraOrthographicSize, cameraOldOrthographicSize - scrollSpeed);
    }

    [Test]
    public void _8_MouseScrollWheel_Down_MoveCameraDown([Values(-1, -0.48f, -14.763f)] float mouseScrollWheelValue)
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - (offset - 1), 0);

        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(fakeMousePosition);
        ITimeProvider timeProvider = new FakeTimeProvider(fakeDeltaTime);
        IMouseScrollWheelProvider mouseScrollWheelProvider = new FakeMouseWheelProvider(mouseScrollWheelValue);

        float cameraOldOrthographicSize = 10;

        Vector2 scrollWheelLimits = new Vector2(3, 15);

        CameraMovement cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);

        float cameraOrthographicSize = cameraMovement.ScrollWheel(scrollSpeed, cameraOldOrthographicSize, scrollWheelLimits);

        Assert.AreEqual(cameraOrthographicSize, cameraOldOrthographicSize + scrollSpeed);
    }

    [Test]
    public void _9_ScrollWheel_NoMouseScroll_CameraNoMove()
    {
        float mouseScrollWheelValue = 0;
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - (offset - 1), 0);

        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(fakeMousePosition);
        ITimeProvider timeProvider = new FakeTimeProvider(fakeDeltaTime);
        IMouseScrollWheelProvider mouseScrollWheelProvider = new FakeMouseWheelProvider(mouseScrollWheelValue);

        float cameraOldOrthographicSize = 10;

        Vector2 scrollWheelLimits = new Vector2(3, 15);

        CameraMovement cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);

        float cameraOrthographicSize = cameraMovement.ScrollWheel(scrollSpeed, cameraOldOrthographicSize, scrollWheelLimits);

        Assert.AreEqual(cameraOrthographicSize, cameraOldOrthographicSize);
    }

}







public class FakeInputMousePositionProvider : IMousePositionProvider
{
    public Vector3 MousePosition { get; set; }

    public Vector3 MousePositionInWorldSpace { get; set; }

    public Vector3 GetMousePosition() { return MousePosition; }

    public Vector3 GetMousePositionInWorldSpace() { return MousePositionInWorldSpace; }

    public FakeInputMousePositionProvider(Vector3 _mousePosition) { MousePosition = _mousePosition; MousePositionInWorldSpace = _mousePosition; }
}

public class FakeTimeProvider : ITimeProvider
{
    public FakeTimeProvider(float deltaTime)
    {
        DeltaTime = deltaTime;
    }
    public float DeltaTime{ get; set; }
    public float GetDeltaTime(){ return DeltaTime; }
}

public class FakeMouseWheelProvider : IMouseScrollWheelProvider
{
    public FakeMouseWheelProvider(float _mouseScrollWheel) { MouseScrollWheel = _mouseScrollWheel; }
    public float MouseScrollWheel { get; set; }
    public float GetMouseScrollWheel() { return MouseScrollWheel; }
}
