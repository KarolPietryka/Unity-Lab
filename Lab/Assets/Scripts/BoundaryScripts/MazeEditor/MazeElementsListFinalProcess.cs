using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeElementsListFinalProcess
{
    void Execute(List<IMazeElement> mazeElementsToProcess, bool newIsMazeWallForRootMazeElement);
}
public class MazeElementsListFinalProcess : IMazeElementsListFinalProcess
{

    public void Execute(List<IMazeElement> mazeElementsToProcess, bool newIsMazeWallForRootMazeElement)
    {
        mazeElementsToProcess.ForEach(delegate (IMazeElement mazeElement)
        {
            if (newIsMazeWallForRootMazeElement == true)
                mazeElement.IsElementOfAnotherWall = true;
            else
                mazeElement.IsElementOfAnotherWall = false;
        });
        mazeElementsToProcess.Clear();
    }
}
