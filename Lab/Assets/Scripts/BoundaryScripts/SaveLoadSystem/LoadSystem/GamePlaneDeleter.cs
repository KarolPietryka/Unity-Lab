using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGamePlaneDeleter
{
    void DeleteAllMazeElements();
}
public class GamePlaneDeleter : IGamePlaneDeleter {

    IPlaneBuilder planeBuilder;

    public GamePlaneDeleter(IPlaneBuilder _planeBuilder)
    {
        planeBuilder = _planeBuilder;
    }

    public void DeleteAllMazeElements()
    {
        for (int i = 0; i < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.x; i++)
        {
            for (int j = 0; j < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.y; j++)
            {
                planeBuilder.GetFromMazeArray(i, j).DeleteMazeElement();
            }
        }
    }
}
