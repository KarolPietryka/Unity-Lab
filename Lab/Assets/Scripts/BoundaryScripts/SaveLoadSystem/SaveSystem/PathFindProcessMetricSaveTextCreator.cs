using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFindProcessMetricSaveTextCreator : ISaveTextCreator {

    IPathFindProcessMetricCollector pathFindProcessMetricCollector;
    IAnalyticMetricFormat analyticPathFindMetricFormat;
    List<string> saveText;

    public PathFindProcessMetricSaveTextCreator(IPathFindProcessMetricCollector _pathFindProcessMetricCollector, List<string> _saveText, IAnalyticMetricFormat _analyticPathFindMetricFormat)
    {
        pathFindProcessMetricCollector = _pathFindProcessMetricCollector;
        analyticPathFindMetricFormat = _analyticPathFindMetricFormat;
        saveText = _saveText;
    }

    public List<string> CreateSaveText()
    {
        saveText.Add(pathFindProcessMetricCollector.NumberOfVisitedNodes + " is NumberOfVisitedNodes"); 

        saveText.Add(pathFindProcessMetricCollector.NumberOfVisitedJunctions + " is NumberOfVisitedJunctions");

        saveText.Add(pathFindProcessMetricCollector.NumberOfVisitedThreeWayJunctions + " is NumberOfVisitedThreeWayJunctions"); 

        saveText.Add(pathFindProcessMetricCollector.NumberOfVisitedFourWayJunctions + " is NumberOfVisitedFourWayJunctions"); 

        saveText.Add(pathFindProcessMetricCollector.NumberOfVisitedDeadEnds + " is NumberOfVisitedDeadEnds"); 

        saveText.Add(pathFindProcessMetricCollector.NumberOfVisitedHallwayNodes + " is NumberOfVisitedHallwayNodes"); 

        saveText.Add(pathFindProcessMetricCollector.PathLengthExpressedInNumberOfNodes + " is PathLengthExpressedInNumberOfNodes");

        analyticPathFindMetricFormat.AddToListForAnalyticMetricFormat();
        return saveText;
    }

    /*private void AddToListForAnalyticMetricFormat()
    {
        saveText.Add("");
        saveText.Add("AnalysisFormat: ");
        saveText.Add(pathFindProcessMetricCollector.NumberOfVisitedNodes + " | " +
            pathFindProcessMetricCollector.PathLengthExpressedInNumberOfNodes + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedJunctions + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedThreeWayJunctions + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedFourWayJunctions + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedDeadEnds + " | " +
            pathFindProcessMetricCollector.NumberOfVisitedHallwayNodes);
    }*/
}

