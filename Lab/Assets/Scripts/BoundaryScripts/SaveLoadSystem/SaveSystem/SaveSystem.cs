using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public interface ISaveSystem
{
    void Save();
}
public class SaveSystem : ISaveSystem {

    IFolderPath pathToSaveFolder;
    ISaveTextCreator saveTextCreator;
    List<string> saveText;
    StreamWriter writer;


    public SaveSystem(IFolderPath _pathToSaveFolder, ISaveTextCreator _saveTextCreator, List<string> _saveText, StreamWriter _writer)
    {
        pathToSaveFolder = _pathToSaveFolder;
        saveTextCreator = _saveTextCreator;
        saveText = _saveText;
        writer = _writer;
    }

    public void Save()
    {
        pathToSaveFolder.GetValidatedFolderPath();
        saveText = saveTextCreator.CreateSaveText();

        for (int i = 0; i < saveText.Count; i++)
        {
            writer.WriteLine(saveText[i]);
        }
        writer.Close();
    }
}
