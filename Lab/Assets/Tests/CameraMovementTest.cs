using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
//using Moq;

public class CameraMovementTest
{
    float screenWidth = 1920;
    float screenHeight = 1080;
    float offset = 50;
    float speed = 1;
    Vector2 minMaxXPosition = new Vector2(-100, 100);
    Vector2 minMaxYPosition = new Vector2(-100, 100);

    [Test]
    public void _1_MouseInTheMiddleOfScreen_NoCameraMove()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight / 2, 0);
        float fakeDeltaTime = 0.016f;
        Vector3 startCamPosition = new Vector3(0, 0, 0);
        Vector3 oldCameraPosition = startCamPosition;
        CameraMovement mouseMovement = new CameraMovement(screenWidth, screenHeight, new FakeInputMousePositionProvider(fakeMousePosition), new FakeTimeProvider(fakeDeltaTime));

        Vector3 newCamPosition = mouseMovement.Movement(offset, speed, minMaxXPosition, minMaxYPosition, startCamPosition);

        Assert.AreEqual(startCamPosition, newCamPosition);
    }

    [Test]
    public void _2_MouseBetweenScreenLimits_NoCameraMove()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 4, screenHeight / 3, 0);
        float fakeDeltaTime = 0.016f;
        Vector3 startCamPosition = new Vector3(0, 0, 0);
        Vector3 oldCameraPosition = startCamPosition;
        CameraMovement mouseMovement = new CameraMovement(screenWidth, screenHeight, new FakeInputMousePositionProvider(fakeMousePosition), new FakeTimeProvider(fakeDeltaTime));

        Vector3 newCamPosition = mouseMovement.Movement(offset, speed, minMaxXPosition, minMaxYPosition, startCamPosition);

        Assert.AreEqual(startCamPosition, newCamPosition);
    }

    [Test]
    public void _3_MouseExcatlyOnScreenHightLimit_NoCameraMove_XCheck()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - offset, 0);
        float fakeDeltaTime = 0.016f;
        Vector3 startCamPosition = new Vector3(0, 0, 0);
        Vector3 oldCameraPosition = startCamPosition;
        CameraMovement mouseMovement = new CameraMovement(screenWidth, screenHeight, new FakeInputMousePositionProvider(fakeMousePosition), new FakeTimeProvider(fakeDeltaTime));

        Vector3 newCamPosition = mouseMovement.Movement(offset, speed, minMaxXPosition, minMaxYPosition, startCamPosition);

        Assert.AreEqual(startCamPosition.x, newCamPosition.x);

    }

    [Test]
    public void _4_MouseExcatlyOnScreenHightLimit_NoCameraMove_YCheck()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - offset, 0);
        float fakeDeltaTime = 0.016f;
        Vector3 startCamPosition = new Vector3(0, 0, 0);
        Vector3 oldCameraPosition = startCamPosition;
        CameraMovement mouseMovement = new CameraMovement(screenWidth, screenHeight, new FakeInputMousePositionProvider(fakeMousePosition), new FakeTimeProvider(fakeDeltaTime));

        Vector3 newCamPosition = mouseMovement.Movement(offset, speed, minMaxXPosition, minMaxYPosition, startCamPosition);

        Assert.AreEqual(startCamPosition.y, newCamPosition.y);
    }

    [Test]
    public void _5_MouseAboveScreenHightLimit_CameraMoveOnYAxis_XCheck()
    {
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - (offset - 1), 0);
        float fakeDeltaTime = 0.016f;
        Vector3 startCamPosition = new Vector3(0, 0, 0);
        Vector3 oldCameraPosition = startCamPosition;
        CameraMovement mouseMovement = new CameraMovement(screenWidth, screenHeight, new FakeInputMousePositionProvider(fakeMousePosition), new FakeTimeProvider(fakeDeltaTime));

        Vector3 newCamPosition = mouseMovement.Movement(offset, speed, minMaxXPosition, minMaxYPosition, startCamPosition);

        Assert.AreEqual(startCamPosition.x, newCamPosition.x);
    }

    [Test]
    public void _6_MouseAboveScreenHightLimit_CameraMoveOnYAxis_YCheck()
    {
        
        Vector3 fakeMousePosition = new Vector3(screenWidth / 2, screenHeight - (offset - 1), 0);
        float fakeDeltaTime = 0.016f;
        Vector3 startCamPosition = new Vector3(0, 0, 0);
        Vector3 oldCameraPosition = startCamPosition;
        CameraMovement mouseMovement = new CameraMovement(screenWidth, screenHeight, new FakeInputMousePositionProvider(fakeMousePosition), new FakeTimeProvider(fakeDeltaTime));

        Vector3 newCamPosition = mouseMovement.Movement(offset, speed, minMaxXPosition, minMaxYPosition, startCamPosition);
        float camMove = speed * fakeDeltaTime;

        Assert.AreEqual(startCamPosition.y + camMove, newCamPosition.y);
    }

}
public class FakeInputMousePositionProvider : IMousePositionProvider
{
    public Vector3 MousePosition { get; set; }

    public Vector3 MousePositionInWorldSpace { get; set; }

    public Vector3 GetMousePosition() { return MousePosition; }

    public Vector3 GetMousePositionInWorldSpace() { return MousePositionInWorldSpace; }

    public FakeInputMousePositionProvider(Vector3 _mousePosition) { MousePosition = _mousePosition; }
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
