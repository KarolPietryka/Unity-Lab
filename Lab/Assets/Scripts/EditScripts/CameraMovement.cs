using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement
{
    private Vector3 cameraMove;

    private readonly IMousePositionProvider mousePositionProvider;
    private readonly ITimeProvider timeProvider;
    private readonly IMouseScrollWheelProvider mouseScrollWheelProvider;
    private float screenWidth;
    private float screenHeight;

    public CameraMovement(
        float _screenWidth, 
        float _screenHeight, 
        IMousePositionProvider _mousePositionProvider, 
        ITimeProvider _timeProvider, 
        IMouseScrollWheelProvider _mouseScrollWheelProvider)
    {
        screenWidth = _screenWidth;
        screenHeight = _screenHeight;
        mousePositionProvider = _mousePositionProvider;
        timeProvider = _timeProvider;
        mouseScrollWheelProvider = _mouseScrollWheelProvider;
    }

    public Vector3 AxisMovement(float offset, float speed, Bounds gamePlaneBounds, Vector3 camPosition)
    {
        Vector3 InputMousePositionVec = mousePositionProvider.GetMousePosition();

        if ((InputMousePositionVec.x > screenWidth - offset) && camPosition.x < gamePlaneBounds.extents.x)
        {
            cameraMove.x += cameraMovementDistance(speed);
        }
        else if ((InputMousePositionVec.x < offset) && camPosition.x > -gamePlaneBounds.extents.x)
        {
            cameraMove.x -= cameraMovementDistance(speed);
        }

        if ((InputMousePositionVec.y > screenHeight - offset) && camPosition.y < gamePlaneBounds.extents.y)
        {
            cameraMove.y += cameraMovementDistance(speed);
            }
        else if ((InputMousePositionVec.y < offset) && camPosition.y > -gamePlaneBounds.extents.y)
        {
            cameraMove.y -= cameraMovementDistance(speed);
        }

        return cameraMove;
    }

    public float ScrollWheel(float scrollSpeed, float _mainCameraOrthographicSize, Vector2 scrollWheelLimit)
    {
        float mainCameraOrthographicSize = _mainCameraOrthographicSize;

        float mouseScrollWheel = mouseScrollWheelProvider.GetMouseScrollWheel();
        if (mainCameraOrthographicSize >= scrollWheelLimit.x && mainCameraOrthographicSize <= scrollWheelLimit.y)
        {
            if (mouseScrollWheel > 0)
            {
                mainCameraOrthographicSize -= scrollSpeed;
            }
            else if (mouseScrollWheel < 0)
            {
                mainCameraOrthographicSize += scrollSpeed;
            }
        }
        return mainCameraOrthographicSize;
    }

    public float cameraMovementDistance(float speed)
    {
        return (speed * timeProvider.GetDeltaTime());
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
public interface IMouseScrollWheelProvider
{
    float GetMouseScrollWheel();
}
