using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public interface ITextFileController
{
    string[] GetNTextFromList(int N);
}
public interface IMazeWallseLoader
{
    void LoadMazeWalls(int saveTextNumberFromList);
}
public class LoadSystemBoundary : MonoBehaviour, ITextFileController, IMazeWallseLoader
{
    [SerializeField]
    private string loadFolderPath;
    [SerializeField]
    private PlaneBoundry planeBuilder;
    [SerializeField]
    private MazeInOutPointsBoundary mazeInOutPoints;
    [SerializeField]
    private InputField SaveInputField;
    private int currentLoadedMazeNumber;

    private FileInfo[] filesInfo;

    private ILoadSystem loadSystem;
    private IFilePathName filePathName;

    private void Awake()
    {
        currentLoadedMazeNumber = -1;
        var info = new DirectoryInfo(loadFolderPath);
        filesInfo = info.GetFiles("*.txt");
        

        loadSystem = new LoadSystem(
        new GamePlaneLoader(
            planeBuilder,
            new SaveTextReader(
                this,
                new Vector2(),
                new Vector2FromTextLinesGetter()),
            new GamePlaneDeleter(
                planeBuilder),
            this,
            mazeInOutPoints));

        filePathName = new FilePathName(filesInfo);

    }

    public void LoadMaze()
    {
        currentLoadedMazeNumber += 1;
        if (currentLoadedMazeNumber + 1 > filesInfo.Length)
        {
            UnityEditor.EditorApplication.isPlaying = false;
            Application.Quit();
        }
        SaveInputField.GetComponent<TextField>().SetText(filesInfo[currentLoadedMazeNumber].FullName);
        loadSystem.LoadMaze(currentLoadedMazeNumber);
    }



    public string[] GetNTextFromList(int  N)
    {
        string[] saveText = File.ReadAllLines(filesInfo[N].FullName);

        return saveText;
    }



    public void LoadMazeWalls(int saveTextNumberFromList)
    {
        StartCoroutine(LoadMazeWalssCorutine(saveTextNumberFromList));
    }
    private IEnumerator LoadMazeWalssCorutine(int saveTextNumberFromList)
    {
        yield return new WaitForEndOfFrame();
        loadSystem.BuildMazeWalls(saveTextNumberFromList);
    }



    public string GetCurrentMazeFullNameWithoutExtension()
    {
        return filePathName.GetFullNameWithoutExtension(currentLoadedMazeNumber);
    }
    public string GetCurrentMazeDirectionFolder()
    {
        return filePathName.GetCurrentMazeDirectionFolder(currentLoadedMazeNumber);
    }
    public string GetCurrentMazeNameWithoutExtensions()
    {
        return filePathName.GetCurrentMazeNameWithoutExtensions(currentLoadedMazeNumber);
    }
}
