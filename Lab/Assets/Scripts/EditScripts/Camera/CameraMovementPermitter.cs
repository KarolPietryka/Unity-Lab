using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementPermitter{

    Vector3 inputMousePositionVec;
    Vector3 currentCameraPosition;
    float offset;
    Bounds gamePlaneBounds;
    Vector2 screenDim;

    IMouse mouse;
    ICameraMovementController cameraMovementController;
    IElementsBounds elementsBounds;

    public CameraMovementPermitter(
        IMouse _mouse, 
        ICameraMovementController _cameraMovementController,
        IElementsBounds _elementsBounds
        )
    {
        mouse = _mouse;
        cameraMovementController = _cameraMovementController;
        elementsBounds = _elementsBounds;       
    }

    public void UpdatePermitterParameters()
    {
        inputMousePositionVec = mouse.GetMousePosition();
        offset = cameraMovementController.Offset;
        currentCameraPosition = cameraMovementController.CurrentCameraPosition;
        gamePlaneBounds = elementsBounds.GamePlaneBounds;
        screenDim = new Vector2 (cameraMovementController.ScreenWidth, cameraMovementController.ScreenHeight);
    }

    public bool IsMouseBehindScreenOffset(Direction moveDirection)
    {
        UpdatePermitterParameters();
        bool ret = false;

        switch (moveDirection)
        {
            case Direction.Left:
                {
                    if (inputMousePositionVec.x < offset)
                    {
                        ret = true;
                    }
                    break;
                }
            case Direction.Up:
                {
                    if (inputMousePositionVec.y > screenDim.y - offset) 
                    {
                        ret = true;
                    }
                    break;
                }
            case Direction.Right:
                {
                    if (inputMousePositionVec.x > screenDim.x - offset)
                    {
                        ret = true;
                    }
                    break;
                }
            case Direction.Down:
                {
                    if (inputMousePositionVec.y < offset)
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

    public bool IsCameraCenterInsideGamePlaneSquare(Direction moveDirection)
    {
        UpdatePermitterParameters();
        bool ret = false;

        switch (moveDirection)
        {
            case Direction.Left:
                {
                    if (currentCameraPosition.x >= -gamePlaneBounds.extents.x)
                    {
                        ret = true;
                    }
                    break;
                }
            case Direction.Up:
                {
                    if (currentCameraPosition.y <= gamePlaneBounds.extents.y)
                    {
                        ret = true;
                    }
                    break;
                }
            case Direction.Right:
                {
                    if (currentCameraPosition.x <= gamePlaneBounds.extents.x)
                    {
                        ret = true;
                    }
                    break;
                }
            case Direction.Down:
                {
                    if (currentCameraPosition.y >= -gamePlaneBounds.extents.y)
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
