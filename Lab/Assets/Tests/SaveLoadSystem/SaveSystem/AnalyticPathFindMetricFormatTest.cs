using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;
using System.Collections.Generic;

public class AnalyticPathFindMetricFormatTest {

    IPathFindProcessMetricCollector GetPathFindProcessMetricCollector(
        int numberOfVisitedNodes,
        int pathLengthExpressedInNumberOfNodes,
        int numberOfVisitedJunctions,
        int numberOfVisitedThreeWayJunctions,
        int numberOfVisitedFourWayJunctions,
        int numberOfVisitedDeadEnds,
        int numberOfVisitedHallwayNodes)
    {
        var pathFindProcessMetricCollector = Substitute.For<IPathFindProcessMetricCollector>();

        pathFindProcessMetricCollector.NumberOfVisitedNodes.Returns(numberOfVisitedNodes);
        pathFindProcessMetricCollector.PathLengthExpressedInNumberOfNodes.Returns(pathLengthExpressedInNumberOfNodes);
        pathFindProcessMetricCollector.NumberOfVisitedJunctions.Returns(numberOfVisitedJunctions);
        pathFindProcessMetricCollector.NumberOfVisitedThreeWayJunctions.Returns(numberOfVisitedThreeWayJunctions);
        pathFindProcessMetricCollector.NumberOfVisitedFourWayJunctions.Returns(numberOfVisitedFourWayJunctions);
        pathFindProcessMetricCollector.NumberOfVisitedDeadEnds.Returns(numberOfVisitedDeadEnds);
        pathFindProcessMetricCollector.NumberOfVisitedHallwayNodes.Returns(numberOfVisitedHallwayNodes);

        return pathFindProcessMetricCollector;
    }
    [Test]
    public void _1_1_AddToListForAnalyticMetricFormat_ContainCheck()
    {
        List<string> text = new List<string>();
        IPathFindProcessMetricCollector pathFindProcessMetricCollector = GetPathFindProcessMetricCollector(1, 2, 3, 4, 5, 6, 7);

        AnalyticPathFindMetricFormat analyticPathFindMetricFormat = new AnalyticPathFindMetricFormat(text, pathFindProcessMetricCollector);
        analyticPathFindMetricFormat.AddToListForAnalyticMetricFormat();

        Assert.AreEqual(text[0], "");
        Assert.AreEqual(text[1], "Analytic Format: ");
        Assert.AreEqual(text[2], "1 | 2 | 3 | 4 | 5 | 6 | 7");
    }
}
