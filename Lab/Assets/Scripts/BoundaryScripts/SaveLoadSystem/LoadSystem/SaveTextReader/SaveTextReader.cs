using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public interface ISaveTextReader
{
    Vector2 GetIntagerNumberOfMazeElementsOnXAndY(int numberOfSave);
    List<Vector2> GetListOfMazeElementsThatAreMazeWall(int numberOfSave);
    Bounds GetGamePlaneBounds(int numberOfSave);
    Vector2 GetStartPlaceForPathFinding(int numberOfSave);
    Vector2 GetDestinationPlaceForPathFinding(int numberOfSave);
}
public class SaveTextReader : ISaveTextReader {

    private ITextFileController textFileController;
    private IVector2FromTextLinesGetter vector2FromTextLinesGetter;

    public SaveTextReader(ITextFileController _textFileController, Vector2 _intagerNumberOfMazeElementsOnXAndY, IVector2FromTextLinesGetter _vector2FromTextLinesGetter)
    {
        textFileController = _textFileController;
        vector2FromTextLinesGetter = _vector2FromTextLinesGetter;
    }

    public Vector2 GetIntagerNumberOfMazeElementsOnXAndY(int numberOfSave)
    {
        string[] saveTextLines = GetTextLinesFromSave(numberOfSave);
        return vector2FromTextLinesGetter.GetVector2FromTextLineThatContainsString("IntagerNumberOfElementsOnXAndY", saveTextLines);
    }
    public Vector2 GetStartPlaceForPathFinding(int numberOfSave)
    {
        string[] saveTextLines = GetTextLinesFromSave(numberOfSave);
        return vector2FromTextLinesGetter.GetVector2FromTextLineThatContainsString("StartPlaceForPathFinding", saveTextLines);
    }
    public Vector2 GetDestinationPlaceForPathFinding(int numberOfSave)
    {
        string[] saveTextLines = GetTextLinesFromSave(numberOfSave);
        return vector2FromTextLinesGetter.GetVector2FromTextLineThatContainsString("DestinationPlaceForPathFinding", saveTextLines);
    }
    public List<Vector2> GetListOfMazeElementsThatAreMazeWall(int numberOfSave)
    {
        string[] saveTextLines = GetTextLinesFromSave(numberOfSave);
        return vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
    }

    public Bounds GetGamePlaneBounds(int numberOfSave)
    {
        string[] saveTextLines = GetTextLinesFromSave(numberOfSave);
        int lineTextWithGamePlaneBounds = GetLineTextWithGamePlaneBounds(saveTextLines);

        return BoundsReader.GetBoundsFromString(saveTextLines[lineTextWithGamePlaneBounds]);
    }





    private static int GetLineTextWithGamePlaneBounds(string[] saveTexLines)// Bounds format: "Center: (0,0, 0,0, 0,0), Extents: (5,0, 5,0, 5,0)"
    {
        int lineWithCenterWord = TextHandler.FindFirstLineWhichContainsString("Center:", saveTexLines);
        int lineWithExtentsWord = TextHandler.FindFirstLineWhichContainsString("Extents:", saveTexLines);
        if (lineWithCenterWord == lineWithExtentsWord)
        {
            return lineWithExtentsWord;
        }
        else
        {
            throw new System.NullReferenceException();
        }
    }
    private string[] GetTextLinesFromSave(int numberOfSave)
    {
        string[] saveTextLines = textFileController.GetNTextFromList(numberOfSave);
        return saveTextLines;
    }
}
