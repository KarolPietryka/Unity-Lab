﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum BuildingStatus { Building, Dismantling }
public enum Direction { Left, Up, Right, Down }

public class GameMasterBoundary : MonoBehaviour, ITimeProvider //TODO to del?
{
    [SerializeField]
    private GameObject MazeElementPrefab;
    [SerializeField]
    private GameObject GamePlane;

    public static GameMasterBoundary instance = null;
    private Bounds mazeElementBounds;
    private Bounds gamePlaneBounds;
    
    public IMouse Mouse { get; set; }
    public IPlaneBuilder PlaneBuilder { get; set; }
    

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

        Mouse = GetComponent<MouseBoundry>();

        mazeElementBounds = MazeElementPrefab.GetComponent<SpriteRenderer>().bounds;
        gamePlaneBounds = GamePlane.transform.Find("Sprite").GetComponent<SpriteRenderer>().bounds;
    }



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


public interface ITimeProvider
{
    float GetDeltaTime();
}

public interface IBuildingController
{
    Direction UpdateBuildingDirection();   
    BuildingStatus BuildingStatus { get; set; }
    void SetBuldingStatus(bool isMazeWall);
    IMazeElement[] NextPossibleMazeElementsToProcess { get; set; }
    Direction BuildingDirection { get; set; }
    bool IsCurrentMazeElementLayOnAnyNextMazeElementAxisLine();

    Vector2[] GetNextPossibleMazeElementsToProcessIndexes();

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
    void GamePlaneSizeUpdate(Bounds newBound);
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
    bool ShouldCameraMoveInDirection(Direction moveDirection);

    float ScrollSpeed { get; set; }
    Vector2 ScrollWheelLimit { get; set; }
    float CameraOrthographicSize { get; set; }
}


