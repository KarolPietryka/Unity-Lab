using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class SaveSystemBoundary : MonoBehaviour, IMazeSpecialElementsSeeker
{
    [SerializeField]
    PlaneBoundry planeBuilder;
    [SerializeField]
    GameObject SaveFolderPathFromInputField;
    [SerializeField]
    private Dropdown markingDropdownList;

    public string defaultSaveFolderPath;

    ISaveSystem saveSystem; 


    public void SaveMaze()
    {
        string mazeSaveFolderPath = SaveFolderPathFromInputField.GetComponent<InputField>().text;

        Debug.Log(mazeSaveFolderPath);
        /*saveSystem = new SaveSystem(
            new FolderPath(
                mazeSaveFolderPath,
                defaultSaveFolderPath,
                new PathValidator()),
            new MazeSaveTextCreator(
                planeBuilder,
                planeBuilder,
                new List<string>(),
                this),
            new List<string>(),
            new StreamWriter(mazeSaveFolderPath, false));*/

        saveSystem = new SaveSystemFactory().CreateSaveSystemForMazeSaving(defaultSaveFolderPath,
            planeBuilder,
            mazeSaveFolderPath,
            this);

        saveSystem.Save();
    }

    public void SaveMarkForCurrentMaze()
    {
        string currentMazeDirectory = transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeDirectionFolder() + "/PlayerMarks/" + transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeNameWithoutExtensions()+ "_PlayerMark.txt";

        Debug.Log(currentMazeDirectory);
        /*saveSystem = new SaveSystem(
            new FolderPath(
                currentMazeDirectory,
                defaultSaveFolderPath,
                new PathValidator()),
            new MarkSaveTextCreator(
                markingDropdownList.value,                
                new List<string>(),
                currentMazeDirectory),
            new List<string>(),
            new StreamWriter(currentMazeDirectory, true));*/

        saveSystem = new SaveSystemFactory().CreateSaveSystemForMazeMark(
            currentMazeDirectory,
            defaultSaveFolderPath,
            markingDropdownList);

        saveSystem.Save();
        transform.GetComponent<LoadSystemBoundary>().LoadMaze();
    }

    public void SaveMetricForPathFindProcess(IPathFindProcessMetricCollector pathFindProcessMetric, EPathFindAlgorithms pathFindAlgorithms)
    {
        string currentMazeDirectory = transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeDirectionFolder() + "/PathFindMetric/" + transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeNameWithoutExtensions() + pathFindAlgorithms.ToString() + "_PathFindMetric.txt";

        /*saveSystem = new SaveSystem(
            new FolderPath(
                currentMazeDirectory,
                defaultSaveFolderPath,
                new PathValidator()),
            new PathFindProcessMetricSaveTextCreator(
                pathFindProcessMetric,
                new List<string>()),
            new List<string>(),
            new StreamWriter(currentMazeDirectory, false));*/

        saveSystem = new SaveSystemFactory().CreateSaveSystemForPathFindProcessMetric(
            currentMazeDirectory,
            defaultSaveFolderPath,
            pathFindProcessMetric);

        saveSystem.Save();
       
    }

    public void SaveMazeMetric(IMazeMetricCollector mazeMetricCollector)
    {
        string currentMazeDirectory = transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeDirectionFolder() + "/MazeMetric/" + transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeNameWithoutExtensions() + "_MazeMetric.txt";

        Debug.Log(transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeDirectionFolder());
        Debug.Log(transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeNameWithoutExtensions());
        /*saveSystem = new SaveSystem(
            new FolderPath(
                currentMazeDirectory,
                defaultSaveFolderPath,
                new PathValidator()),
            new MazeMetricSaveTextCreator(
                mazeMetricCollector,
                new List<string>()),
            new List<string>(),
            new StreamWriter(currentMazeDirectory, false));*/

        saveSystem = new SaveSystemFactory().CreateSaveSystemForMazeMetric(
            currentMazeDirectory,
            defaultSaveFolderPath,
            mazeMetricCollector);

        saveSystem.Save();

    }
    public IMazeElement FindStartPlaceForPathFinding()
    {
        return GameObject.FindGameObjectWithTag("PathFindStartNode").GetComponent<MazeElementBoundary>();
    }
    public IMazeElement FindDestinationPlaceForPathFinding()
    {
        return GameObject.FindGameObjectWithTag("PathFindDestinationNode").GetComponent<MazeElementBoundary>();
    }
}
