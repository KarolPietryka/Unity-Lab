using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMetricSaveTextCreator : ISaveTextCreator
{
    IMazeMetricCollector mazeMetricCollector;
    IAnalyticMetricFormat analyticMazeMetricFormat;
    List<string> saveText;

    public MazeMetricSaveTextCreator(IMazeMetricCollector _mazeMetricCollector, List<string> _saveText, IAnalyticMetricFormat _analyticMazeMetricFormat)
    {
        mazeMetricCollector = _mazeMetricCollector;
        analyticMazeMetricFormat = _analyticMazeMetricFormat;
        saveText = _saveText;
    }

    public List<string> CreateSaveText()
    {
        saveText.Add(mazeMetricCollector.TotalNumberOfNodes + " is TotalNumberOfNodes");

        saveText.Add(mazeMetricCollector.TotalNumberOfWalkableNodes + " is TotalNumberOfWalkableNodes");

        saveText.Add(mazeMetricCollector.TotalNumberOfJunctions + " is TotalNumberOfJunctions");

        saveText.Add(mazeMetricCollector.TotalNumberOfThreeWayJunctions + " is TotalNumberOfThreeWayJunctions");

        saveText.Add(mazeMetricCollector.TotalNumberOfFourWayJunctions + " is TotalNumberOfFourWayJunctions");

        saveText.Add(mazeMetricCollector.TotalNumberOfDeadEnds + " is TotalNumberOfDeadEnds");

        saveText.Add(mazeMetricCollector.TotalNumberOfHallwayNodes + " is TotalNumberOfHallwayNodes");

        analyticMazeMetricFormat.AddToListForAnalyticMetricFormat();
        return saveText;
    }

    /*private void AddToListForAnalyticMetricFormat()
    {
        saveText.Add("");
        saveText.Add("AnalysisFormat: ");
        saveText.Add(mazeMetricCollector.TotalNumberOfNodes + " | " +
            mazeMetricCollector.TotalNumberOfWalkableNodes + " | " +
            mazeMetricCollector.TotalNumberOfJunctions + " | " +
            mazeMetricCollector.TotalNumberOfThreeWayJunctions + " | " +
            mazeMetricCollector.TotalNumberOfFourWayJunctions + " | " +
            mazeMetricCollector.TotalNumberOfDeadEnds + " | " +
            mazeMetricCollector.TotalNumberOfHallwayNodes);
    }*/
}
