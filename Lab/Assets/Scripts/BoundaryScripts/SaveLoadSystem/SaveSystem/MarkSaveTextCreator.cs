using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MarkSaveTextCreator : ISaveTextCreator
{
    int mazeMark;
    List<string> saveText;
    string currentMazeDirectory;

    public MarkSaveTextCreator(int _mazeMark, List<string> _saveText, string _currentMazeDirectory)
    {
        mazeMark = _mazeMark;
        saveText = _saveText;
        currentMazeDirectory = _currentMazeDirectory;
    }
    public List<string> CreateSaveText()
    {
        saveText.Add(mazeMark + " is player difficulty mark for maze with directory: " + currentMazeDirectory);
        return saveText;
    }
}
