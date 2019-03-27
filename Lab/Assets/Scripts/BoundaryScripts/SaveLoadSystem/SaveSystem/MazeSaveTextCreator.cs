using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISaveTextCreator
{
    List<string> CreateSaveText();
}
public class MazeSaveTextCreator : ISaveTextCreator {

    IPlaneBuilder planeBuilder;
    IPlaneElementsBounds elementsBounds;
    List<string> saveText;
    IMazeSpecialElementsSeeker saveSystemBoundary;

    public MazeSaveTextCreator(IPlaneBuilder _planeBuilder, IPlaneElementsBounds _elementsBounds, List<string> _saveText, IMazeSpecialElementsSeeker _saveSystemBoundary)
    {
        planeBuilder = _planeBuilder;
        elementsBounds = _elementsBounds;
        saveText = _saveText;
        saveSystemBoundary = _saveSystemBoundary;
    }

    public List<string> CreateSaveText()
    {
        saveText.Add(elementsBounds.GamePlaneBounds.ToString() + " is GamePlaneBounds");
        saveText.Add(saveSystemBoundary.FindStartPlaceForPathFinding().Index + "is StartPlaceForPathFinding");
        saveText.Add(saveSystemBoundary.FindDestinationPlaceForPathFinding().Index + "is DestinationPlaceForPathFinding");
        saveText.Add(planeBuilder.IntagerNumberOfMazeElementsOnXAndY.ToString() + " is IntagerNumberOfElementsOnXAndY");

        for (int i = 0; i < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.x; i++)
        {
            for (int j = 0; j < planeBuilder.IntagerNumberOfMazeElementsOnXAndY.y; j++)
            {
                if (planeBuilder.GetFromMazeArray(i, j).IsMazeWall)
                {
                    string mazeElementIndex = planeBuilder.GetFromMazeArray(i, j).Index.ToString();
                    saveText.Add(mazeElementIndex + " is maze wall element");
                }
            }
        }
        return saveText;
    }
}
