using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnalyticMazeMetricFormat : IAnalyticMetricFormat
{
    List<string> saveText;
    IMazeMetricCollector mazeMetricCollector;

    public AnalyticMazeMetricFormat(List<string> _saveText, IMazeMetricCollector _mazeMetricCollector)
    {
        saveText = _saveText;
        mazeMetricCollector = _mazeMetricCollector;
    }
    public void AddToListForAnalyticMetricFormat()
    {
        saveText.Add("");
        saveText.Add("Analytic Format: ");
        saveText.Add(mazeMetricCollector.TotalNumberOfNodes + " | " +
            mazeMetricCollector.TotalNumberOfWalkableNodes + " | " +
            mazeMetricCollector.TotalNumberOfJunctions + " | " +
            mazeMetricCollector.TotalNumberOfThreeWayJunctions + " | " +
            mazeMetricCollector.TotalNumberOfFourWayJunctions + " | " +
            mazeMetricCollector.TotalNumberOfDeadEnds + " | " +
            mazeMetricCollector.TotalNumberOfHallwayNodes);
    }
}
