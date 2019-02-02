using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterBoundary : MonoBehaviour, ITimeProvider
{
    public static GameMasterBoundary instance = null;//3
    private Bounds mazeElementBounds;
    private Bounds gamePlaneBounds;
    private GameMaster gameMaster = new GameMaster();//3
    
    public IInputProvider InputProvider { get; set; }
    public IMouse Mouse { get; set; }
    public IBuildingController BuildingController { get; set; }
    public IPlaneController PlaneController { get; set; }
    

    public bool InBuildingProcesss { get; set; }//buildingConstructor


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

        gameMaster.SetBuildingController(BuildingController);
        gameMaster.SetInputProvider(InputProvider);
        gameMaster.SetTimeProvider(this);
        gameMaster.SetMouse(Mouse);
        gameMaster.SetPlaneController(PlaneController);

        //mazeElementBounds = MazeElementPrefab.GetComponent<SpriteRenderer>().bounds;
       // gamePlaneBounds = GamePlane.transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds;
    }

    public void Start()
    {
        //IntagerNumberOfMazeElementsOnXAndY = GamePlane.GetComponent<PlaneBoundry>().IntagerNumberOfMazeElementsOnXAndY;
    }

    public void Update()
    {
        if (Input.GetMouseButton(0) && Mouse.CurrentMouseOnMazeElement != null)
        {
            Direction buildingDirection = BuildingController.UpdateBuildingDirection();

            if (Input.GetMouseButtonDown(0))//execute only once. in one moment when click is doneh
            {
                gameMaster.FirstMazeWallConstruct();
            }

           // if (currentMouseOnMazeElement.Equals(NextPossibleMazeElementsToProcess[0]) || currentMouseOnMazeElement.Equals(NextPossibleMazeElementsToProcess[1]))//current have hanged and now it is one of nextMazeElements
           // {
                gameMaster.ProcessNextMazeElement();
          //  }
            //NextPossibleMazeElementsToProcess = GamePlane.GetComponent<PlaneBoundry>().NextPossibleMazeElementsToProcess(buildingDirection, Mouse.CurrentMouseOnMazeElement);
        }
        if (Input.GetMouseButtonUp(0))
        {
            InBuildingProcesss = false;
        }
    }

    
    #region IInputProvider
    public Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }


    public float GetMouseScrollWheel()
    {
        return Input.GetAxis("Mouse ScrollWheel");
    }

    /*public bool GetMouseButton(int button)
    {
        return Input.GetMouseButton(button);
    }

    public bool GetMouseButtonDown(int button)
    {
        return Input.GetMouseButtonDown(button);
    }*/
    #endregion

    #region ITimeProvider
    public float GetDeltaTime()
    {
        return Time.deltaTime;
    }
    #endregion
}

public interface IMazeBouildController
{
    void SetBuildingStatus();
}

public interface IInputProvider
{
    Vector3 GetMousePosition();
   // Vector3 GetMousePositionInWorldSpace();
    float GetMouseScrollWheel();
    bool WasHorizontalMoveInReferenceToLastClick();
    /*bool GetMouseButton(int button);
    bool GetMouseButtonDown(int button);*/
}

public interface ITimeProvider
{
    float GetDeltaTime();
}

public interface IBuildingController
{
    Direction UpdateBuildingDirection();   
    BuildingStatus BuildingStatus { get; set; }
    void SetBuldingStatus(bool isMazeWall);
    //Vector2
    //bool InBuildingProcesss { get; set; }
    IMazeElement[] NextPossibleMazeElementsToProcess { get; set; }
    Direction BuildingDirection { get; set; }
    bool IsCurrentMazeElementLayOnAnyNextMazeElementAxisLine();

    Vector2[] GetNextPossibleMazeElementsToProcessIndexes();

}
public interface IMouse
{
    MazeElementBoundary CurrentMouseOnMazeElement { get; set; }
    Vector3 LastMouseClickPosition { get; set; }
    bool CurrentMouseOnMazeElementHadBeenChanged { get; set; }
    bool WasHorizontalMoveInReferenceToLastClick(Vector3 mousePosition);

    Vector2 CurrentMouseOnMazeElementIndex();
    void UpdateLastMouseClickPosition(Vector3 newLastMouseClickPosition);

}

public interface IElementsBounds
{
    Bounds GamePlaneBounds { get; set; }
    Bounds MazeElementBounds { get; set; }
}

public interface IPlaneElementsBounds
{
    Bounds GamePlaneBounds { get; set; }
    Bounds MazeElementBounds { get; set; }
    float MazeElementGapBetween { get; set; }
    Vector2 GamePlaneSidesLenght { get; set; }
    Vector2 MazeElementSidesLenght { get; set; }
    Vector2 MazeElementAndGapSumOn { get; set; }
}

public interface ICameraMovementController
{
    float Offset { get; set; }
    float XYSpeed { get; set; }
    float ScreenWidth { get; set; }
    float ScreenHeight { get; set; }
    Vector2 CurrentCameraPosition { get; set; }
    float CameraMovementDistance(float speed);
    bool CanCameraMoveInDirection(Direction moveDirection);

    float ScrollSpeed { get; set; }
    Vector2 ScrollWheelLimit { get; set; }
    float CameraOrthographicSize { get; set; }
}

public interface IMazeElement
{
    bool IsMazeWall { get; set; }
    Vector2 Index { get; set; }
    Direction PositionInReferenceToCurrentMazeElement { get; set; }
    void ReverseIsMazeWall();
    void ChangeOnMazeWallColor();
}