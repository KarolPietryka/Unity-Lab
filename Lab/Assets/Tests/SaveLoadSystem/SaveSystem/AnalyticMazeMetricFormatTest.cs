using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class AnalyticMazeMetricFormatTest {

    IMazeMetricCollector GetMazeMetricCollector(
        int totalNumberOfNodes,
        int totalNumberOfWalkableNodes,
        int totalNumberOfJunctions,
        int totalNumberOfThreeWayJunctions,
        int totalNumberOfFourWayJunctions,
        int totalNumberOfDeadEnds,
        int totalNumberOfHallwayNodes)
    {
        var mazeMetricCollector = Substitute.For<IMazeMetricCollector>();

        mazeMetricCollector.TotalNumberOfNodes.Returns(totalNumberOfNodes);
        mazeMetricCollector.TotalNumberOfWalkableNodes.Returns(totalNumberOfWalkableNodes);
        mazeMetricCollector.TotalNumberOfJunctions.Returns(totalNumberOfJunctions);
        mazeMetricCollector.TotalNumberOfThreeWayJunctions.Returns(totalNumberOfThreeWayJunctions);
        mazeMetricCollector.TotalNumberOfFourWayJunctions.Returns(totalNumberOfFourWayJunctions);
        mazeMetricCollector.TotalNumberOfDeadEnds.Returns(totalNumberOfDeadEnds);
        mazeMetricCollector.TotalNumberOfHallwayNodes.Returns(totalNumberOfHallwayNodes);

        return mazeMetricCollector;
    }
    [Test]
    public void _1_1_AddToListForAnalyticMetricFormat_ContainCheck()
    {
        List<string> text = new List<string>();
        IMazeMetricCollector mazeMetricCollector = GetMazeMetricCollector(1, 2, 3, 4, 5, 6, 7);

        AnalyticMazeMetricFormat analyticMazeMetricFormat = new AnalyticMazeMetricFormat(text, mazeMetricCollector);
        analyticMazeMetricFormat.AddToListForAnalyticMetricFormat();

        Assert.AreEqual(text[0], "");
        Assert.AreEqual(text[1], "Analytic Format: ");
        Assert.AreEqual(text[2], "1 | 2 | 3 | 4 | 5 | 6 | 7");
    }
}
