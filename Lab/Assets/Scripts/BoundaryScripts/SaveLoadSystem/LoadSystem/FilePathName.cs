using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;


public interface IFilePathName
{
    string GetFullNameWithoutExtension(int currentNumberOfFileInLis);
    string GetCurrentMazeDirectionFolder(int currentNumberOfFileInLis);
    string GetCurrentMazeNameWithoutExtensions(int currentNumberOfFileInLis);
}
public class FilePathName : IFilePathName {

    private FileInfo[] filesInfo;
    //private int currentNumberOfFileInList;

    public FilePathName(FileInfo[] _filesInfo)//,ref int _currentNumberOfFileInList)
    {
        filesInfo = _filesInfo;
        //currentNumberOfFileInList = _currentNumberOfFileInList;
    }
    public string GetFullNameWithoutExtension(int currentNumberOfFileInLis)
    {
        string fileDirectoryToFolder = GetCurrentMazeDirectionFolder(currentNumberOfFileInLis);
        string fileName = GetCurrentMazeNameWithoutExtensions(currentNumberOfFileInLis);
        return fileDirectoryToFolder + "/" + fileName;
    }
    public string GetCurrentMazeDirectionFolder(int currentNumberOfFileInList)
    {
        string fileDirectoryToFolder = filesInfo[currentNumberOfFileInList].DirectoryName;
        return fileDirectoryToFolder;
    }
    public string GetCurrentMazeNameWithoutExtensions(int currentNumberOfFileInList)
    {
        string fileName = Path.GetFileNameWithoutExtension(filesInfo[currentNumberOfFileInList].FullName);
        return fileName;

    }
}
