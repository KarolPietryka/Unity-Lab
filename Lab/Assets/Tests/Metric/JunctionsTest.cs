using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class JunctionsTest{

    IUniversalMetric GetMetric()
    {
        var metric = Substitute.For<IUniversalMetric>();
        return metric;
    }

    List<IMazeElement> GetNeighbourMazeElementList(int numberOfNeighbourMazeElementThatAreMazeWalls)
    {
        List<IMazeElement> neighbourMazeElementList = new List<IMazeElement>();
        for (int i = 0; i < 4; i++)
        {
            IMazeElement neighbourMazeElement;
            if (numberOfNeighbourMazeElementThatAreMazeWalls > 0)
            {
                 neighbourMazeElement = GetMazeElement(true);
                 numberOfNeighbourMazeElementThatAreMazeWalls--;
            }
            else
            {
                 neighbourMazeElement = GetMazeElement(false);
            }
            neighbourMazeElementList.Add(neighbourMazeElement);

        }
        return neighbourMazeElementList;
    }

    IMazeElement GetMazeElement(bool isMazeWall)
    {
        var mazeElement = Substitute.For<IMazeElement>();

        mazeElement.IsMazeWall.Returns(isMazeWall);

        return mazeElement;
        
    }
    [Test]
    public void _1_1_ProcessJunctionParametersBaseOn_ListCountCheck_IncreaseNumberOfDeadEnd()
    {
        var metric = GetMetric();
        var numberOfNeighbourMazeElementThatAreMazeWalls = 3;
        List<IMazeElement> neighbourMazeElementList = GetNeighbourMazeElementList(numberOfNeighbourMazeElementThatAreMazeWalls);
        Junctions.ProcessJunctionParametersBaseOn(metric, neighbourMazeElementList);
        metric.Received().IncreaseNumberOfDeadEnds();
    }
    [Test]
    public void _1_2_ProcessJunctionParametersBaseOn_ListCountCheck_IncreaseNumberOfHallwayNodes()
    {
        var metric = GetMetric();
        var numberOfNeighbourMazeElementThatAreMazeWalls = 2;
        List<IMazeElement> neighbourMazeElementList = GetNeighbourMazeElementList(numberOfNeighbourMazeElementThatAreMazeWalls);
        Junctions.ProcessJunctionParametersBaseOn(metric, neighbourMazeElementList);
        metric.Received().IncreaseNumberOfHallwayNodes();
    }
    [Test]
    public void _1_3_ProcessJunctionParametersBaseOn_ListCountCheck_IncreaseNumberOfThreeWayJunctions()
    {
        var metric = GetMetric();
        var numberOfNeighbourMazeElementThatAreMazeWalls = 1;
        List<IMazeElement> neighbourMazeElementList = GetNeighbourMazeElementList(numberOfNeighbourMazeElementThatAreMazeWalls);
        Junctions.ProcessJunctionParametersBaseOn(metric, neighbourMazeElementList);
        metric.Received().IncreaseNumberOfThreeWayJunctions();
    }
    [Test]
    public void _1_4_ProcessJunctionParametersBaseOn_ListCountCheck_IncreaseNumberOfFourWayJunctions()
    {
        var metric = GetMetric();
        var numberOfNeighbourMazeElementThatAreMazeWalls = 0;
        List<IMazeElement> neighbourMazeElementList = GetNeighbourMazeElementList(numberOfNeighbourMazeElementThatAreMazeWalls);
        Junctions.ProcessJunctionParametersBaseOn(metric, neighbourMazeElementList);
        metric.Received().IncreaseNumberOfFourWayJunctions();
    }
    //Test for invalid values
    /*
    [Test]
    public void _1_5_ProcessJunctionParametersBaseOn_ListCountCheck_Error()
    {
        var metric = GetMetric();
        var numberOfNeighbourMazeElementThatAreMazeWalls = 5;
        List<IMazeElement> neighbourMazeElementList = GetNeighbourMazeElementList(numberOfNeighbourMazeElementThatAreMazeWalls);
        Assert.Throws<System.NotImplementedException>(() => Junctions.ProcessJunctionParametersBaseOn(metric, neighbourMazeElementList));
    }*/

    
}
