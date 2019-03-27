using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ILoadSystem
{
    void LoadMaze(int saveTextNumberFromList);
    void BuildMazeWalls(int saveTextNumberFromList);
}
public class LoadSystem : ILoadSystem {

    private IGamePlaneLoader gamePlaneLoader;

    public LoadSystem(IGamePlaneLoader _gamePlaneLoader)
    {
        gamePlaneLoader = _gamePlaneLoader;
    }

    public void LoadMaze(int saveTextNumberFromList)
    {
        gamePlaneLoader.LoadMaze(saveTextNumberFromList);
    }
    public void BuildMazeWalls(int saveTextNumberFromList)
    {
        gamePlaneLoader.BuildMazeWalls(saveTextNumberFromList);
    }

}
