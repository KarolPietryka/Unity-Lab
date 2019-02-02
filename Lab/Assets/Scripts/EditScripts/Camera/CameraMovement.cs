using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement
{
    private Vector3 cameraMove;

    private IInputProvider inputProvider;
    private ITimeProvider timeProvider;
    private IElementsBounds elementsBounds;
    private ICameraMovementController cameraMovementController;


    public void SetInputProvider(IInputProvider _inputProvider)
    {
        inputProvider = _inputProvider;
    }
    public void SetTimeProvider(ITimeProvider _timeProvider)
    {
        timeProvider = _timeProvider;
    }
    public void SetElementsBounds(IElementsBounds _elementsBounds)
    {
        elementsBounds = _elementsBounds;
    }
    public void SetCameraMovementController(ICameraMovementController _cameraMovementController)
    {
        cameraMovementController = _cameraMovementController;
    }

    public Vector3 AxisMovement()
    {
        float xySpeed = cameraMovementController.XYSpeed;

        if (cameraMovementController.CanCameraMoveInDirection(Direction.Left))
        {
            cameraMove.x += CameraMovementDistance(xySpeed);
        }
        else if (cameraMovementController.CanCameraMoveInDirection(Direction.Right))
        {
            cameraMove.x -= CameraMovementDistance(xySpeed);
        }

        if (cameraMovementController.CanCameraMoveInDirection(Direction.Up))
        {
            cameraMove.y += CameraMovementDistance(xySpeed);
        }
        else if (cameraMovementController.CanCameraMoveInDirection(Direction.Down))
        {
            cameraMove.y -= CameraMovementDistance(xySpeed);
        }

        return cameraMove;
    }

    public float CameraMovementDistance(float speed)
    {
        return cameraMovementController.CameraMovementDistance(speed);
    }

    public bool CanCameraMoveInDirection(Direction moveDirection)
    {
        bool ret = false;
        Vector3 inputMousePositionVec = inputProvider.GetMousePosition();
        float offset = cameraMovementController.Offset;
        Vector3 currentCameraPosition = cameraMovementController.CurrentCameraPosition;
        Bounds gamePlaneBounds = elementsBounds.GamePlaneBounds;

        switch (moveDirection)
        {
            case Direction.Left:
                {
                    if ((inputMousePositionVec.x < offset) && currentCameraPosition.x > -gamePlaneBounds.extents.x)
                    {
                        ret = true;
                    }
                    break;
                }
            case Direction.Up:
                {
                    if ((inputMousePositionVec.y > cameraMovementController.ScreenHeight - offset) && (currentCameraPosition.y < gamePlaneBounds.extents.y))
                    {
                        ret = true;
                    }
                    break;
                }
            case Direction.Right:
                {
                    if ((inputMousePositionVec.x > cameraMovementController.ScreenWidth - offset) && (currentCameraPosition.x < gamePlaneBounds.extents.x))
                    {
                        ret = true;
                    }
                    break;
                }
            case Direction.Down:
                {
                    if ((inputMousePositionVec.y < offset) && currentCameraPosition.y > -gamePlaneBounds.extents.y)
                    {
                        ret = true;
                    }
                    break;
                }
            default:
                return false;
        }
        return ret;
    }
}

