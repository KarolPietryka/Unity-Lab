using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGamePlaneLoader
{
    void LoadMaze(int mazeNumber);
    void BuildMazeWalls(int mazeNumber);
}
public class GamePlaneLoader : IGamePlaneLoader
{
    private IPlaneBuilder planeBuilder;
    private IGamePlaneDeleter gamePlaneDeleter;
    private ISaveTextReader saveTextReader;
    private IMazeWallseLoader mazeWallseLoader;
    private IMazeInOutPoints mazeInOutPoints;
    private IPlaneElementsBounds elementsBounds;


    public GamePlaneLoader(IPlaneBuilder _planeBuilder, 
        ISaveTextReader _saveTextReader, 
        IGamePlaneDeleter _gamePlaneDeleter, 
        IMazeWallseLoader _mazeWallseLoader, 
        IMazeInOutPoints _mazeInOutPoints)
    {
        planeBuilder = _planeBuilder;
        saveTextReader = _saveTextReader;
        gamePlaneDeleter = _gamePlaneDeleter;
        mazeWallseLoader = _mazeWallseLoader;
        mazeInOutPoints = _mazeInOutPoints;
    }

    public void LoadMaze(int mazeNumber)
    {
        mazeInOutPoints.RemoveInOutPoints();

        gamePlaneDeleter.DeleteAllMazeElements();

        UpdateGamePlaneSizeFromSaveText(mazeNumber);

        planeBuilder.CreateGamePlaneGridInScene();

        mazeWallseLoader.LoadMazeWalls(mazeNumber);      
    }

    private void  UpdateGamePlaneSizeFromSaveText(int mazeNumber)
    {
        Bounds newGamePlaneBound = saveTextReader.GetGamePlaneBounds(mazeNumber);
        planeBuilder.GamePlaneSizeUpdate(newGamePlaneBound);

        //elementsBounds.GamePlaneBounds = newGamePlaneBound;
    }

    public void BuildMazeWalls(int mazeNumber)
    {
        Vector2 intagerNumberOfMazeElementsOnXAndY = saveTextReader.GetIntagerNumberOfMazeElementsOnXAndY(mazeNumber);
        List<Vector2> listOfMazeElementsThatareMazeWall = saveTextReader.GetListOfMazeElementsThatAreMazeWall(mazeNumber);
        for (int i = 0; i < intagerNumberOfMazeElementsOnXAndY.x; i++)
        {
            for (int j = 0; j < intagerNumberOfMazeElementsOnXAndY.y; j++)
            {
                if (listOfMazeElementsThatareMazeWall.Contains(new Vector2(i, j)))
                {
                    planeBuilder.GetFromMazeArray(i, j).ReverseIsMazeWall();
                    planeBuilder.GetFromMazeArray(i, j).IsElementOfAnotherWall = true;
                }
            }
        }
        SetSpecialPoints(mazeNumber);
    }

    private void SetSpecialPoints(int mazeNumber)
    {
        Vector2 startPlaceForPathFinding = saveTextReader.GetStartPlaceForPathFinding(mazeNumber);
        Vector2 destinationPlaceForPathFinding = saveTextReader.GetDestinationPlaceForPathFinding(mazeNumber);

        IMazeElement startMazeElementForPathfind = planeBuilder.GetFromMazeArray((int)startPlaceForPathFinding.x, (int)startPlaceForPathFinding.y);
        IMazeElement destinationMazeElementForPathFind = planeBuilder.GetFromMazeArray((int)destinationPlaceForPathFinding.x, (int)destinationPlaceForPathFinding.y);

        mazeInOutPoints.SetInOutPointsAt(startMazeElementForPathfind, destinationMazeElementForPathFind);
    }
}
