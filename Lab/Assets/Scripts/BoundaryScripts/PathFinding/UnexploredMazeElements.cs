using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IUnexploredMazeElements
{
    List<IMazeElement> GetUnexploredList();
}
public class UnexploredMazeElements : IUnexploredMazeElements
{
    IPlaneBuilder planeBuilder;
    List<IMazeElement> unexploredMazeElementsList;

    public UnexploredMazeElements(IPlaneBuilder _planeBuilder, List<IMazeElement> _unexploredMazeElementsList)
    {
        planeBuilder = _planeBuilder;
        unexploredMazeElementsList = _unexploredMazeElementsList;
    }



    public List<IMazeElement> GetUnexploredList()
    {
        CreateList();
        return unexploredMazeElementsList;
    }



    private void CreateList()
    {
        for (int i = 0; i < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.x; i++)
        {
            for (int j = 0; j < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.y; j++)
            {
                IMazeElement mazeElement = planeBuilder.GetFromMazeArray(i, j);
                if (!IsMazeElementMazeWall(mazeElement))
                {
                    unexploredMazeElementsList.Add(mazeElement);
                }
            }
        }
    }
    private bool IsMazeElementMazeWall(IMazeElementPathFindParameters mazeElement)
    {
        return mazeElement.IsMazeWall;
    }

}
