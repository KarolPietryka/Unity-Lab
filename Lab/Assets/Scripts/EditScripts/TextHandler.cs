using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TextHandler{

	public static string RemoveAllNonVectorPartsOfString(string _stringToProcess)
    {
        string stringToProcess = _stringToProcess;

        int positionOfVectorOpenBracket = stringToProcess.IndexOf("(");
        stringToProcess = stringToProcess.Remove(0, positionOfVectorOpenBracket);
        int positionOfVectorColseBracket = stringToProcess.IndexOf(")");
        stringToProcess = stringToProcess.Remove(positionOfVectorColseBracket);

        stringToProcess = stringToProcess.Replace("(", "");
        stringToProcess = stringToProcess.Replace(")", "");

        return stringToProcess;
    }

    public static int FindFirstLineWhichContainsString(string stringToFind, string[] saveTextLines)
    {
        int lineWithString = -1;
        for (int i = 0; i < saveTextLines.Length; i++)
        {
            if (saveTextLines[i].Contains(stringToFind))
            {
                lineWithString = i;
                break;
            }
        }
        if (lineWithString == -1)
        {
            throw new System.NotImplementedException("There is no such stringtoFind in File");
        }
        return lineWithString;
    }
}
