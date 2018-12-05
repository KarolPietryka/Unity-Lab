using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement
{
    private Vector3 cameraMove;

    private readonly IMousePositionProvider mousePosition;
    private readonly ITimeProvider timeProvider;
    private float screenWidth;
    private float screenHeight;

    public CameraMovement(float _screenWidth, float _screenHeight, IMousePositionProvider _mousePosition, ITimeProvider _timeProvider)
    {
        screenWidth = _screenWidth;
        screenHeight = _screenHeight;
        mousePosition = _mousePosition;
        timeProvider = _timeProvider;
    }

    public Vector3 Movement(float offset, float speed, Vector2 minMaxXPosition, Vector2 minMaxYPosition, Vector3 camPosition)
    {
        Vector3 InputMousePositionVec = mousePosition.GetMousePosition();

        if ((InputMousePositionVec.x > screenWidth - offset) && camPosition.x < minMaxXPosition.y)
        {
            cameraMove.x += speed * timeProvider.GetDeltaTime();
        }
        if ((InputMousePositionVec.x < offset) && camPosition.x > minMaxXPosition.x)
        {
            cameraMove.x -= speed * timeProvider.GetDeltaTime();
        }
        if ((InputMousePositionVec.y > screenHeight - offset) && camPosition.y < minMaxYPosition.y)
        {
            cameraMove.y += speed * timeProvider.GetDeltaTime();
        }
        if ((InputMousePositionVec.y < offset) && camPosition.y > minMaxYPosition.x)
        {
            cameraMove.y -= speed * timeProvider.GetDeltaTime();
        }
        return cameraMove;      
    }
}

public interface IMousePositionProvider
{
    Vector3 GetMousePosition();
    Vector3 GetMousePositionInWorldSpace();

}
public interface ITimeProvider
{
    float GetDeltaTime();
}

public class CorrectInputMousePositionProvider : IMousePositionProvider
{
    public Vector3 GetMousePosition()
    {
        return Input.mousePosition ;
    }
    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 v3 = Input.mousePosition;
        v3.z = GameMaster.Instance.MazeElement.transform.position.z;//TODO why 20? If it will be 9 will it work? why it is not working with 0?
        return Camera.main.ScreenToWorldPoint(v3);
    }
}
public class CorrectTimeProvider : ITimeProvider
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
}