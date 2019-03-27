using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnalyticMetricFormat
{
    void AddToListForAnalyticMetricFormat();
}
public class AnalyticPathFindMetricFormat : IAnalyticMetricFormat {

    List<string> saveText;
    IPathFindProcessMetricCollector pathFindProcessMetricCollector;

    public AnalyticPathFindMetricFormat(List<string> _saveText, IPathFindProcessMetricCollector _pathFindProcessMetricCollector)
    {
        saveText = _saveText;
        pathFindProcessMetricCollector = _pathFindProcessMetricCollector;
    }
    public void AddToListForAnalyticMetricFormat()
    {
        saveText.Add("");
        saveText.Add("Analytic Format: ");
        saveText.Add(pathFindProcessMetricCollector.NumberOfVisitedNodes + " | " +
            pathFindProcessMetricCollector.PathLengthExpressedInNumberOfNodes + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedJunctions + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedThreeWayJunctions + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedFourWayJunctions + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedDeadEnds + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedHallwayNodes);
    }
}
