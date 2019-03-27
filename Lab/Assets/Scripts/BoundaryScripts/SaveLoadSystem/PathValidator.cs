using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPathValidator
{
    void SetDefaultIfFolderPathEmpty(ref string folderPath, string defauldFolderPath);
}
public class PathValidator : IPathValidator {


    public void SetDefaultIfFolderPathEmpty(ref string folderPath, string defauldFolderPath)
    {
        if (IsFolderPathEmpty(folderPath, defauldFolderPath))
        {
            folderPath = defauldFolderPath;
        }
    }



    private bool IsFolderPathEmpty(string folderPath, string defauldFolderPath)
    {
        bool ret = false;
        if (folderPath == string.Empty)
        {
            ret = true;
        }
        return ret;
    }
}
