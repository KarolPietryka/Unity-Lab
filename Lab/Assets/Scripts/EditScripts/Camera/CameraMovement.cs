using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement
{
    private CameraMovementPermitter cameraMovementPermitter;
    private Vector3 cameraMove;
    private float xySpeed;

    private IMouse mouse;
    private ITimeProvider timeProvider;
    private IElementsBounds elementsBounds;
    private ICameraMovementController cameraMovementController;


    public void SetMouse(IMouse _mouse)
    {
        mouse = _mouse;
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
    public void CreateCameraMovementPermitter()
    {
        cameraMovementPermitter = new CameraMovementPermitter(mouse, cameraMovementController, elementsBounds);
    }

    public Vector3 AxisMovement()
    {
        xySpeed = cameraMovementController.XYSpeed;
        if (cameraMovementController.ShouldCameraMoveInDirection(Direction.Left))
        {
            cameraMove.x -= CameraMovementDistance(xySpeed);
        }
        else if (cameraMovementController.ShouldCameraMoveInDirection(Direction.Right))
        {
            cameraMove.x += CameraMovementDistance(xySpeed);
        }

        if (cameraMovementController.ShouldCameraMoveInDirection(Direction.Up))
        {
            cameraMove.y += CameraMovementDistance(xySpeed);
        }
        else if (cameraMovementController.ShouldCameraMoveInDirection(Direction.Down))
        {
            cameraMove.y -= CameraMovementDistance(xySpeed);

        }
        return cameraMove;
    }

    public float CameraMovementDistance(float speed)
    {

        return cameraMovementController.CameraMovementDistance(speed);
    }

   
    public bool ShouldCameraMoveInDirection(Direction moveDirection)
    {
        bool ret = false;

        if (cameraMovementPermitter.IsMouseBehindScreenOffset(moveDirection) && cameraMovementPermitter.IsCameraCenterInsideGamePlaneSquare(moveDirection))
        {
            ret = true;
        }
                           
        return ret;
    }
}

