using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBoundry : MonoBehaviour, IPlaneController, IPlaneElementsBounds
{
    private Bounds gamePlaneBound;
    private Bounds mazeElementBound;
    private Plane gamePlane;
    private NextPossibleMazeElementsProvider nextPossibleMazeElementsToProcess;
    [SerializeField]
    private float mazeElementGapBetween;
    [SerializeField]
    private GameObject MazeElementPrefab;
    [SerializeField]
    private GameObject MazeGroup;

    public Vector2 IntagerNumberOfMazeElementsOnXAndY { get; set; }
    public IMazeElement[,] MazeArray { get; set; }
    public Bounds GamePlaneBounds {
        get { return gamePlaneBound; }
        set
        {
            gamePlaneBound = value;
            GamePlaneSidesLenght = new Vector2(2 * GamePlaneBounds.extents.x, 2 * GamePlaneBounds.extents.y);
            if (GamePlaneSidesLenght.x <= 0 || GamePlaneSidesLenght.y <= 0) throw new System.ArgumentOutOfRangeException();

        }
    }
    public Bounds MazeElementBounds {
        get { return mazeElementBound; }
        set
        {
            mazeElementBound = value;
            MazeElementSidesLenght = new Vector2(2 * MazeElementBounds.extents.x, 2 * MazeElementBounds.extents.y);
            if (MazeElementSidesLenght.x <= 0 || MazeElementSidesLenght.y <= 0) throw new System.ArgumentOutOfRangeException();

        }
    }
    public Vector2 GamePlaneSidesLenght { get; set; }
    public Vector2 MazeElementSidesLenght { get; set; }
    public float MazeElementGapBetween {
        get { return mazeElementGapBetween; }
        set
        {
            mazeElementGapBetween = value;
            if (MazeElementGapBetween <= 0) throw new System.ArgumentOutOfRangeException();
        }
    }
    public Vector2 MazeElementAndGapSumOn { get; set; }

    void Awake ()
    {
        gamePlane = new Plane();
        nextPossibleMazeElementsToProcess = new NextPossibleMazeElementsProvider();

        MazeElementBounds = MazeElementPrefab.GetComponent<SpriteRenderer>().bounds;
        //GamePlaneBounds = transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds;
        GamePlaneBounds = new Bounds(transform.Find("Sprite").position, transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds.size);
        Debug.Log(transform.Find("Sprite").transform.position.z);
          
        MazeElementAndGapSumOn = new Vector2(MazeElementSidesLenght.x + MazeElementGapBetween, MazeElementSidesLenght.y + MazeElementGapBetween);

        gamePlane.SetPlaneController(this);
        gamePlane.SetPlaneElementsBounds(this);
        nextPossibleMazeElementsToProcess.SetPlaneController(this);
        CreateGamePlaneGridInScene();
    }

    void CreateGamePlaneGridInScene()
    {
        IntagerNumberOfMazeElementsOnXAndY = gamePlane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea();
        gamePlane.CreateGamePlaneGridInScene(); 
    }

    public void CreateMazeElementPrefab(Vector3 positionOfMazeElement, int i, int j)
    {
        GameObject clone = Instantiate(MazeElementPrefab, positionOfMazeElement, Quaternion.identity, MazeGroup.transform);
        Debug.Log(positionOfMazeElement.z);

        clone.GetComponent<MazeElementBoundary>().Index = new Vector2(i, j);
        MazeArray[i, j] = clone.GetComponent<MazeElementBoundary>();
    }
    
    public IMazeElement[] NextPossibleMazeElementsToProcess(Direction buildingDirection, IMazeElement currentMouseOnMazeElement)
    {
        return nextPossibleMazeElementsToProcess.GetNextPossibleMazeElementsToProcess(buildingDirection, currentMouseOnMazeElement);
    }

    public IMazeElement GetFromMazeArray(int x, int y)
    {
        return MazeArray[x, y];
    }
}
