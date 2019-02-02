using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScroll{

    private IInputProvider inputProvider;
    private ICameraMovementController cameraMovementController;

    public void SetInputProvider(IInputProvider _inputProvider)
    {
        inputProvider = _inputProvider;
    }

    public void SetCameraMovementController(ICameraMovementController _cameraMovementController)
    {
        cameraMovementController = _cameraMovementController;
    }

    public float ScrollWheel()
    {
        Vector2 scrollWheelLimit = cameraMovementController.ScrollWheelLimit;
        float cameraOrthographicSize = cameraMovementController.CameraOrthographicSize;
        float mouseScrollWheel = inputProvider.GetMouseScrollWheel();

        if (mouseScrollWheel > 0)
        {
            if (cameraOrthographicSize > scrollWheelLimit.x && cameraOrthographicSize < scrollWheelLimit.y
                || cameraOrthographicSize >= scrollWheelLimit.y)
            {
                cameraOrthographicSize -= cameraMovementController.ScrollSpeed;
            }
        }
        else if (mouseScrollWheel < 0)
        {
            if (cameraOrthographicSize > scrollWheelLimit.x && cameraOrthographicSize < scrollWheelLimit.y
                || cameraOrthographicSize <= scrollWheelLimit.x)
            {
                cameraOrthographicSize += cameraMovementController.ScrollSpeed;
            }
        }
        return cameraOrthographicSize;
    }
}
