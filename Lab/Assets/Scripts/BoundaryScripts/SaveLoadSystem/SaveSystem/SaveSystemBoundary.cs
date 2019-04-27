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

        saveSystem = new SaveSystemFactory().CreateSaveSystemForMazeSaving(defaultSaveFolderPath,
            planeBuilder,
            mazeSaveFolderPath,
            this);

        saveSystem.Save();
    }

    public void SaveMarkForCurrentMaze()
    {
        string currentMazeDirectory;
        try
        {
            currentMazeDirectory = transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeDirectionFolder() + "/PlayerMarks/" + transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeNameWithoutExtensions() + "_PlayerMark.txt";
        }
        catch (System.IndexOutOfRangeException)
        {
            currentMazeDirectory = string.Empty;
        }

        Debug.Log(currentMazeDirectory);

        saveSystem = new SaveSystemFactory().CreateSaveSystemForMazeMark(
            currentMazeDirectory,
            defaultSaveFolderPath,
            markingDropdownList);

        saveSystem.Save();
        transform.GetComponent<LoadSystemBoundary>().LoadMaze();
    }

    public void SaveMetricForPathFindProcess(IPathFindProcessMetricCollector pathFindProcessMetric, EPathFindAlgorithms pathFindAlgorithms)
    {
        string currentMazeDirectory;
        try
        {
            currentMazeDirectory = transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeDirectionFolder() + "/PathFindMetric/" + transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeNameWithoutExtensions() + "_" + pathFindAlgorithms.ToString() + "_PathFindMetric.txt";
        }
        catch (System.IndexOutOfRangeException)
        {
            currentMazeDirectory = string.Empty;
        }

        saveSystem = new SaveSystemFactory().CreateSaveSystemForPathFindProcessMetric(
            currentMazeDirectory,
            defaultSaveFolderPath,
            pathFindProcessMetric);

        saveSystem.Save();
       
    }

    public void SaveMazeMetric(IMazeMetricCollector mazeMetricCollector)
    {
        string currentMazeDirectory;
        try
        {
           currentMazeDirectory = transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeDirectionFolder() + "/MazeMetric/" + transform.GetComponent<LoadSystemBoundary>().GetCurrentMazeNameWithoutExtensions() + "_MazeMetric.txt";
        }
        catch (System.IndexOutOfRangeException)
        {
            currentMazeDirectory = string.Empty;
        }

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
