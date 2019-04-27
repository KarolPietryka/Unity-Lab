using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;


public class SaveSystemFactory{

    public ISaveSystem CreateSaveSystemForMazeSaving(
         string defaultSaveFolderPath,
         PlaneBoundry planeBuilder,
         string mazeSaveFolderPath,
         IMazeSpecialElementsSeeker mazeSpecialElementsSeeker)
    {
        ISaveSystem saveSystem;

        saveSystem = new SaveSystem(
            new FolderPath(
                mazeSaveFolderPath,
                defaultSaveFolderPath,
                new PathValidator()),
            new MazeSaveTextCreator(
                planeBuilder,
                planeBuilder,
                new List<string>(),
                mazeSpecialElementsSeeker),
            new List<string>(),
            new StreamWriter(mazeSaveFolderPath, false));

        return saveSystem;
    }

    public ISaveSystem CreateSaveSystemForMazeMark(
        string currentMazeDirectory,
        string defaultSaveFolderPath,
        Dropdown markingDropdownList
        )
    {
        ISaveSystem saveSystem;

        saveSystem = new SaveSystem(
            new FolderPath(
                currentMazeDirectory,
                defaultSaveFolderPath,
                new PathValidator()),
            new MarkSaveTextCreator(
                markingDropdownList.value + 1,
                new List<string>(),
                currentMazeDirectory),
            new List<string>(),
            new StreamWriter(currentMazeDirectory, true));

        return saveSystem;
    }

    public ISaveSystem CreateSaveSystemForPathFindProcessMetric(
        string currentMazeDirectory,
        string defaultSaveFolderPath,
        IPathFindProcessMetricCollector pathFindProcessMetricCollector)
    {
        ISaveSystem saveSystem;
        List<string> saveText = new List<string>();


        saveSystem = new SaveSystem(
            new FolderPath(
                currentMazeDirectory,
                defaultSaveFolderPath,
                new PathValidator()),
            new PathFindProcessMetricSaveTextCreator(
                pathFindProcessMetricCollector,
                saveText,
                new AnalyticPathFindMetricFormat(
                    saveText,
                    pathFindProcessMetricCollector)),
            new List<string>(),
            new StreamWriter(currentMazeDirectory, false));

        return saveSystem;
    }

    public ISaveSystem CreateSaveSystemForMazeMetric(
        string currentMazeDirectory,
        string defaultSaveFolderPath,
        IMazeMetricCollector mazeMetricCollector)
    {
        ISaveSystem saveSystem;
        List<string> saveText = new List<string>();

        FolderPath folderPath = new FolderPath(
                currentMazeDirectory,
                defaultSaveFolderPath,
                new PathValidator());

        currentMazeDirectory = folderPath.GetValidatedFolderPath();

        saveSystem = new SaveSystem(
            folderPath,
            new MazeMetricSaveTextCreator(
                mazeMetricCollector,
                saveText,
                new AnalyticMazeMetricFormat(
                    saveText,
                    mazeMetricCollector)),
            new List<string>(),
            new StreamWriter(currentMazeDirectory, false));

        return saveSystem;
    }
}
