using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFolderPath
{
    string GetValidatedFolderPath();
}

public class FolderPath : IFolderPath{

    string saveFolderpath;
    string defauldFolderPath;
    IPathValidator saveFolderPathValidator;

    public FolderPath(string _folderPath, string _defauldFolderPath, IPathValidator _saveFolderPathValidator)
    {
        saveFolderpath = _folderPath;
        saveFolderPathValidator = _saveFolderPathValidator;
        defauldFolderPath = _defauldFolderPath;
    }

    public string GetValidatedFolderPath()
    {
        saveFolderPathValidator.SetDefaultIfFolderPathEmpty(ref saveFolderpath, defauldFolderPath);
        return saveFolderpath + "/testc.txt";
    }



}
