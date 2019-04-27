using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraMovementBoundary : MonoBehaviour, ITimeProvider, IElementsBounds, ICameraMovementController {

    private CameraMovement cameraMovement;
    private CameraScroll cameraScroll;
    [SerializeField]
    private float offset;
    [SerializeField]
    private float xySpeed;

    public IMouse Mouse { get; set; }

    #region cameraMovementControll
    public float Offset { get { return offset; } set { offset = value; } }
    public float XYSpeed { get { return xySpeed; } set { xySpeed = value; } }
    public Bounds MazeElementBounds { get; set; }
    public Bounds GamePlaneBounds { get; set; }
    public Vector2 CurrentCameraPosition { get; set; }
    public float ScreenWidth { get; set; }
    public float ScreenHeight { get; set; }
    #endregion

    #region cameraScroll
    private float scrollSpeed = 1;
    private Vector2 scrollWheelLimit = new Vector2(5, 200);
    public float ScrollSpeed { get { return scrollSpeed; } set { scrollSpeed = value; } }
    public Vector2 ScrollWheelLimit
    {
        get { return scrollWheelLimit; }
        set
        {
            if (value.x < value.y && value.x > 0 && value.y > 0)
            {
                scrollWheelLimit = value;
            }
        }
    }
    public float CameraOrthographicSize {
        get
        {
            return Camera.main.orthographicSize;
        }
        set
        {
            Camera.main.orthographicSize = value;
        }
    }
#endregion

    void Start()
    {
        ScreenWidth = Screen.width;
        ScreenHeight = Screen.height;
        GamePlaneBounds = GameObject.Find("Plane").GetComponent<PlaneBoundry>().GamePlaneBounds;

        CameraOrthographicSize = ScrollWheelLimit.y / 6;
        Mouse = GetComponent<MouseBoundry>();

        cameraMovement = cameraMovementInit();
        cameraScroll = cameraScrollInit();

    }

    CameraMovement cameraMovementInit()
    {
        cameraMovement = new CameraMovement();
        cameraMovement.SetMouse(Mouse);
        cameraMovement.SetTimeProvider(this);
        cameraMovement.SetElementsBounds(this);
        cameraMovement.SetCameraMovementController(this);
        cameraMovement.CreateCameraMovementPermitter();
        return cameraMovement;
    }

    CameraScroll cameraScrollInit()
    {
        cameraScroll = new CameraScroll();
        cameraScroll.SetMouse(Mouse);
        cameraScroll.SetCameraMovementController(this);
        return cameraScroll;
    }
    
    void FixedUpdate()
    {
        cameraMove();       
    }

    void cameraMove()
    {
        CurrentCameraPosition = Camera.main.transform.position;

        transform.position = cameraMovement.AxisMovement();
        transform.GetComponent<Camera>().orthographicSize = cameraScroll.ScrollWheel();
    }

    #region ICameraMovementController
    public float CameraMovementDistance(float speed)
    {
        return (speed * GetDeltaTime());
    }

    public bool ShouldCameraMoveInDirection(Direction moveDirection)
    {
        return cameraMovement.ShouldCameraMoveInDirection(moveDirection);
    }
    #endregion

    #region ITimeProvider
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
    #endregion
}






