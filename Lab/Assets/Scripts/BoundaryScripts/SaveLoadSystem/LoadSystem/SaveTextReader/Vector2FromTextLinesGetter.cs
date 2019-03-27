using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IVector2FromTextLinesGetter
{
    List<Vector2> GetVectorsFromTextLinesThatContainsString(string[] textLines, string stringOccuredInEveryVector2TextLine);
    Vector2 GetVector2FromTextLineThatContainsString(string stringOccuredInVector2TextLine, string[] textLines);
}
public class Vector2FromTextLinesGetter: IVector2FromTextLinesGetter
{
    private string[] textLines;
    private string stringOccuredInEveryVector2TextLine;
    private List<Vector2> foundListOfVectors;

    public Vector2 GetVector2FromTextLineThatContainsString(string stringOccuredInVector2TextLine, string[] textLines)
    {
        int numberOfLineThatContainsString = TextHandler.FindFirstLineWhichContainsString(stringOccuredInVector2TextLine, textLines);

        string vector2FoundInTextLineInStringType = TextHandler.RemoveAllNonVectorPartsOfString(textLines[numberOfLineThatContainsString]);

        Vector2 foundVector2 = StringToVector2Parser.Parse(vector2FoundInTextLineInStringType);

        return foundVector2;
    }

    public List<Vector2> GetVectorsFromTextLinesThatContainsString(string[] _textLines, string _stringOccuredInEveryVector2TextLine)
    {
        textLines = _textLines;
        stringOccuredInEveryVector2TextLine = _stringOccuredInEveryVector2TextLine;
        foundListOfVectors = new List<Vector2>();

        int numberOfFirstVector2TextLine = TextHandler.FindFirstLineWhichContainsString(stringOccuredInEveryVector2TextLine, textLines);

        int numberOfLastVector2TextLine = GetNumberOfLastTextLineWhichContainsString(numberOfFirstVector2TextLine);

        for (int i = numberOfFirstVector2TextLine; i < numberOfLastVector2TextLine; i++)
        {
            string foundVector2String = TextHandler.RemoveAllNonVectorPartsOfString(textLines[i]);
            Vector2 foundVector2 = StringToVector2Parser.Parse(foundVector2String);
            foundListOfVectors.Add(foundVector2);
        }

        return foundListOfVectors;
    }

    private int GetNumberOfLastTextLineWhichContainsString(int numberOfFirstVector2TextLine)
    {
        int vector2BlockLenghtCounter = 0;

        for (int i = numberOfFirstVector2TextLine; i < textLines.Length; i++)
        {
            if (textLines[i].Contains(stringOccuredInEveryVector2TextLine))
            {
                vector2BlockLenghtCounter++;
            }
            else
            {
                break;
            }      
        }
        return numberOfFirstVector2TextLine + vector2BlockLenghtCounter;
    }
}
