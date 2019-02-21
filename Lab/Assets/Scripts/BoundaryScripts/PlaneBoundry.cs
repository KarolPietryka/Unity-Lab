using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBoundry : MonoBehaviour, IPlaneBuilder, IPlaneElementsBounds
{
    private Bounds gamePlaneBound;
    private Bounds mazeElementBound;
    private PlaneBuilder gamePlaneBuilder;
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
        gamePlaneBuilder = new PlaneBuilder();

        MazeElementBounds = MazeElementPrefab.GetComponent<SpriteRenderer>().bounds;
        GamePlaneBounds = new Bounds(transform.Find("Sprite").position, transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds.size);
          
        MazeElementAndGapSumOn = new Vector2(MazeElementSidesLenght.x + MazeElementGapBetween, MazeElementSidesLenght.y + MazeElementGapBetween);

        gamePlaneBuilder.SetInterfaces(this, this);
        //nextPossibleMazeElementsToProcess.SetPlaneController(this);
        CreateGamePlaneGridInScene();
    }

    void CreateGamePlaneGridInScene()
    {
        gamePlaneBuilder.CreateGamePlaneGridInScene(); 
    }

    public void CreateMazeElementPrefab(Vector3 positionOfMazeElement, int i, int j)
    {
        GameObject clone = Instantiate(MazeElementPrefab, positionOfMazeElement, Quaternion.identity, MazeGroup.transform);

        clone.GetComponent<MazeElementBoundary>().Index = new Vector2(i, j);
        MazeArray[i, j] = clone.GetComponent<MazeElementBoundary>();
    }

    public void InitMazeArray()
    {
         MazeArray = new IMazeElement[(int)IntagerNumberOfMazeElementsOnXAndY.x, (int)IntagerNumberOfMazeElementsOnXAndY.y];
    }

    public IMazeElement[] NextPossibleMazeElementsToProcess(Direction buildingDirection, IMazeElement currentMouseOnMazeElement)
    {
        nextPossibleMazeElementsToProcess = new NextPossibleMazeElementsProvider(currentMouseOnMazeElement.Index, buildingDirection, this);
        return nextPossibleMazeElementsToProcess.GetNextPossibleMazeElementsToProcess();
    }

    public IMazeElement GetFromMazeArray(int x, int y)
    {
        return MazeArray[x, y];
    }
}
