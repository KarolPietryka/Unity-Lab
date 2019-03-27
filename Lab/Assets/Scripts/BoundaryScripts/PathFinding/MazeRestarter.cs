using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeElementsPathFindParametersRestarter
{
    void RestartMazeElementsParameters();
}

public class MazeRestarter : IMazeElementsPathFindParametersRestarter
{
    IPlaneBuilder planeBuilder;

    public MazeRestarter(IPlaneBuilder _planeBuilder)
    {
        planeBuilder = _planeBuilder;
    }


    public void RestartMazeElementsParameters()
    {
        for (int i = 0; i < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.x; i++)
        {
            for (int j = 0; j < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.y; j++)
            {
                IMazeElement mazeElement = planeBuilder.GetFromMazeArray(i, j);
                ResetPathFindingParameters(mazeElement);
            }
        }
    }


    private void ResetPathFindingParameters(IMazeElement mazeElement)
    {
        mazeElement.ResetPathFindingParameters();
    }

}

