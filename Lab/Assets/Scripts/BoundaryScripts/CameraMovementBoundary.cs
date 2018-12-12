using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementBoundary : MonoBehaviour{

    private CameraMovement cameraMovement;

    public float offset;
    public float XYSpeed;
    public float scrollSpeed = 1;
    public Vector2 ScrollWheelLimit
    {
        get { return scrollWheelLimit; }
        set
        {
            value = scrollWheelLimit;
            float updateMouseScrollWheelLimit = value.y;
            GameMasterBoundary.instance.updateMouseScrollWheelLimit(updateMouseScrollWheelLimit);
        }
    }

    private Vector2 scrollWheelLimit = new Vector2(5, 200);
    private Bounds gamePlaneBounds;
    private Vector2 currentCameraPosition;

    private float screenWidth;
    private float screenHeight;

    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;

        cameraMovement = cameraMovementInit();
    }

    CameraMovement cameraMovementInit()
    {
        IMousePositionProvider mousePositionProvider;
        ITimeProvider timeProvider;
        IMouseScrollWheelProvider mouseScrollWheelProvider;

        mousePositionProvider = GameMasterBoundary.instance.mousePositionProvider;
        timeProvider = GameMasterBoundary.instance.timeProvider;
        mouseScrollWheelProvider = GameMasterBoundary.instance.mouseScrollWheelProvider;

        return cameraMovement = new CameraMovement(screenWidth, screenHeight, mousePositionProvider, timeProvider, mouseScrollWheelProvider);
    }

    void Update()
    {
        cameraMove();
        
    }

    void cameraMove()
    {
        gamePlaneBounds = GameMasterBoundary.instance.GamePlaneBounds;
        currentCameraPosition = Camera.main.transform.position;

        cameraUpdateOnXYZAxis();
    }

    void cameraUpdateOnXYZAxis()
    {      
        transform.position = cameraMovement.AxisMovement(offset, XYSpeed, gamePlaneBounds, currentCameraPosition);
        transform.GetComponent<Camera>().orthographicSize = cameraMovement.ScrollWheel(scrollSpeed, Camera.main.orthographicSize, scrollWheelLimit);
    }

 
}





