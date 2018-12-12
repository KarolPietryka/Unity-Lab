using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterBoundary : MonoBehaviour
{
    public static GameMasterBoundary instance = null;

    public readonly IMousePositionProvider mousePositionProvider = new CorrectInputMousePositionProvider();
    public readonly ITimeProvider timeProvider = new CorrectTimeProvider();
    public readonly IMouseScrollWheelProvider mouseScrollWheelProvider=  new CorrectMouseWheelProvider();

    public GameObject MazeElement;
    public GameObject GamePlane;

    public Bounds MazeElementBounds
    {
        get { return mazeElementBounds; }
    }
    public Bounds GamePlaneBounds
    {
        get { return gamePlaneBounds; }
    }
    private Bounds mazeElementBounds;
    private Bounds gamePlaneBounds;

    private Mouse mouse;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        mazeElementBounds = MazeElement.GetComponent<SpriteRenderer>().bounds;
        gamePlaneBounds = GamePlane.transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds;

        float updateMouseScrollWheelLimit = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<CameraMovementBoundary>().ScrollWheelLimit.y;
        mouse = new Mouse(mousePositionProvider, gamePlaneBounds, mazeElementBounds, updateMouseScrollWheelLimit);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Buttn Push");
            if (mouse.InInstantiationArea())
            {
                Debug.Log("In area");
                InstantiateMazeElement();
            }
        }
    }

    public GameObject InstantiateMazeElement()
    {
        Vector3 mousePosition = mousePositionProvider.GetMousePositionInWorldSpace();
        Vector3 mousePositionToInstantiate = new Vector3(mousePosition.x, mousePosition.y, MazeElement.transform.position.z);
        return Instantiate(MazeElement, mousePositionToInstantiate, transform.rotation);       
    }

    public void updateMouseScrollWheelLimit(float mouseSUppercrollWheelLimits)
    {
        mouse.mouseupperScrollLimit = mouseSUppercrollWheelLimits;
    }
}

public class CorrectInputMousePositionProvider : IMousePositionProvider
{
    public Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }
    public Vector3 GetMousePositionInWorldSpace()
    {
        Vector3 mouseInputPosition = Input.mousePosition;
        mouseInputPosition.z = GameMasterBoundary.instance.MazeElement.transform.position.z;//why its take from GameMasterBoundary?
        return Camera.main.ScreenToWorldPoint(mouseInputPosition);
    }
}
public class CorrectTimeProvider : ITimeProvider
{
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
}
public class CorrectMouseWheelProvider : IMouseScrollWheelProvider
{
    public float GetMouseScrollWheel()
    {
        return Input.GetAxis("Mouse ScrollWheel");
    }
}