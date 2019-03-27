using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFolderPath
{
    void FolderPathValidation();
}

public class FolderPath : IFolderPath{

    string saveFolderpath;
    string defauldFolderPath;
    IPathValidator saveFolderPathValidator;

    public FolderPath(string _folderPath, string _defauldFolderPath, IPathValidator _saveFolderPathValidator)
    {
        saveFolderpath = _folderPath;
        saveFolderPathValidator = _saveFolderPathValidator;
    }

    public void FolderPathValidation()
    {
        saveFolderPathValidator.SetDefaultIfFolderPathEmpty(ref saveFolderpath, defauldFolderPath);
    }


}
