using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class MazeMetricTest {

    IPlaneBuilder GetPlaneBuilder(Vector2 gamePlaneSize, List<Vector2> listOfMazeElementsThatAreMazeWall)
    {
        var planeBuilder = Substitute.For<IPlaneBuilder>();
        planeBuilder.IntagerNumberOfMazeElementsOnXAndY.Returns(gamePlaneSize);
        for (int i = 0; i < (int)gamePlaneSize.x; i++)
        {
            for (int j = 0; j < (int)gamePlaneSize.y; j++)
            {
                var mazeElement = Substitute.For<IMazeElement>();
                mazeElement.Index.Returns(new Vector2(i, j));
                if (listOfMazeElementsThatAreMazeWall.Contains(new Vector2(i, j)))
                {
                    mazeElement.IsMazeWall.Returns(true);
                }
                else
                {
                    mazeElement.IsMazeWall.Returns(false);
                }
                planeBuilder.GetFromMazeArray(i, j).Returns(mazeElement);
            }
        }
        SetNeighboursForMazeElement(planeBuilder);
        return planeBuilder;
    }

    public void SetNeighboursForMazeElement(IPlaneBuilder planeBuilder)
    {
        Vector2 gamePlaneSize = planeBuilder.IntagerNumberOfMazeElementsOnXAndY;
        for (int i = 0; i < (int)gamePlaneSize.x; i++)
        {
            for (int j = 0; j < (int)gamePlaneSize.y; j++)
            {
                IMazeElement mazeElement = planeBuilder.GetFromMazeArray(i, j);
                List<IMazeElement> NeighboursList = new List<IMazeElement>();

                //Debug.Log(planeBuilder.GetFromMazeArray(Mathf.Clamp((int)mazeElement.Index.x - 1, 0, (int)planeBuilder.IntagerNumberOfMazeElementsOnXAndY.x - 1), (int)mazeElement.Index.y).Index);

                NeighboursList.Add(planeBuilder.GetFromMazeArray(Mathf.Clamp((int)mazeElement.Index.x - 1, 0, (int)planeBuilder.IntagerNumberOfMazeElementsOnXAndY.x - 1), (int)mazeElement.Index.y));
                NeighboursList.Add(planeBuilder.GetFromMazeArray(Mathf.Clamp((int)mazeElement.Index.x + 1, 0, (int)planeBuilder.IntagerNumberOfMazeElementsOnXAndY.x - 1), (int)mazeElement.Index.y));
                NeighboursList.Add(planeBuilder.GetFromMazeArray((int)mazeElement.Index.x, Mathf.Clamp((int)mazeElement.Index.y - 1, 0, (int)planeBuilder.IntagerNumberOfMazeElementsOnXAndY.y - 1)));
                NeighboursList.Add(planeBuilder.GetFromMazeArray((int)mazeElement.Index.x, Mathf.Clamp((int)mazeElement.Index.y + 1, 0, (int)planeBuilder.IntagerNumberOfMazeElementsOnXAndY.y - 1)));

                planeBuilder.GetNeighboursOfMazeElement(planeBuilder.GetFromMazeArray(i, j)).Returns(NeighboursList);

            }
        }
    }

    IMazeMetricController GetMazeMetricController()
    {
        var mazeMetricController = Substitute.For<IMazeMetricController>();

        return mazeMetricController;
    }
    [Test]
    public void _1_1_SetMazeMetric_IncreaseNumberOfNodes_ReceiveCheck()
    {
        Vector2 gamePlaneSize = new Vector2(3, 3);
        List<Vector2> listOfMazeElementsThatAreMazeWall = new List<Vector2>();
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 2));

        var planeBuilder = GetPlaneBuilder(gamePlaneSize, listOfMazeElementsThatAreMazeWall);

        MazeMetric mazeMetric = new MazeMetric(planeBuilder);
        mazeMetric.SetMazeMetric();

        Assert.AreEqual(mazeMetric.TotalNumberOfNodes, 9);
    }

    [Test]
    public void _1_2_SetMazeMetric_IncreaseNumberOfWalkableNodes_ReceiveCheck()
    {
        Vector2 gamePlaneSize = new Vector2(3, 3);

        List<Vector2> listOfMazeElementsThatAreMazeWall = new List<Vector2>();
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 2));

        var planeBuilder = GetPlaneBuilder(gamePlaneSize, listOfMazeElementsThatAreMazeWall);

        MazeMetric mazeMetric = new MazeMetric(planeBuilder);
        mazeMetric.SetMazeMetric();

        Assert.AreEqual(mazeMetric.TotalNumberOfWalkableNodes, 5);
    }

    [Test]
    public void _1_3_SetMazeMetric_IncreaseNumberOfDeadEnds_MazeMetricCheck()
    {
        Vector2 gamePlaneSize = new Vector2(5, 5);

        List<Vector2> listOfMazeElementsThatAreMazeWall = new List<Vector2>();
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 0));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 3));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 4));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 3));
        
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 4));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 2));

        /*      Maze Construction
         *      o o o o o 
         *      o       o 
         *      o   o   o
         *      o       o
         *      o o o o o 
         */

        var planeBuilder = GetPlaneBuilder(gamePlaneSize, listOfMazeElementsThatAreMazeWall);

        MazeMetric mazeMetric = new MazeMetric(planeBuilder);
        mazeMetric.SetMazeMetric();

        Assert.AreEqual(mazeMetric.TotalNumberOfDeadEnds, 0);
        Assert.AreEqual(mazeMetric.TotalNumberOfFourWayJunctions, 0);
        Assert.AreEqual(mazeMetric.TotalNumberOfHallwayNodes, 8);
        Assert.AreEqual(mazeMetric.TotalNumberOfJunctions, 0);
        Assert.AreEqual(mazeMetric.TotalNumberOfNodes, 25);
        Assert.AreEqual(mazeMetric.TotalNumberOfThreeWayJunctions, 0);
        Assert.AreEqual(mazeMetric.TotalNumberOfWalkableNodes, 8);
    }

    [Test]
    public void _1_4_SetMazeMetric_IncreaseNumberOfDeadEnds_ReceiveCheck()
    {
        Vector2 gamePlaneSize = new Vector2(5, 5);

        List<Vector2> listOfMazeElementsThatAreMazeWall = new List<Vector2>();
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 0));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 3));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 4));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 3));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 4));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 3));

        /*      Maze Construction
         *      o o o o o 
         *      o   o   o 
         *      o       o
         *      o   o   o
         *      o o o o o 
         */

        var planeBuilder = GetPlaneBuilder(gamePlaneSize, listOfMazeElementsThatAreMazeWall);

        MazeMetric mazeMetric = new MazeMetric(planeBuilder);
        mazeMetric.SetMazeMetric();

        Assert.AreEqual(mazeMetric.TotalNumberOfDeadEnds, 4);
        Assert.AreEqual(mazeMetric.TotalNumberOfFourWayJunctions, 0);
        Assert.AreEqual(mazeMetric.TotalNumberOfHallwayNodes, 1);
        Assert.AreEqual(mazeMetric.TotalNumberOfJunctions, 2);
        Assert.AreEqual(mazeMetric.TotalNumberOfNodes, 25);
        Assert.AreEqual(mazeMetric.TotalNumberOfThreeWayJunctions, 2);
        Assert.AreEqual(mazeMetric.TotalNumberOfWalkableNodes, 7);
    }

    [Test]
    public void _1_5_SetMazeMetric_IncreaseNumberOfDeadEnds_ReceiveCheck()
    {
        Vector2 gamePlaneSize = new Vector2(6, 6);

        List<Vector2> listOfMazeElementsThatAreMazeWall = new List<Vector2>();
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 0));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 3));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 5));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 3));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 5));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 5));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 5));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 5));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 5));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 3));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 4));


        /*      Maze Construction
         *      o o o o o o
         *      o   o   o o
         *      o   o     o
         *      o       o o
         *      o   o   o o
         *      o o o o o o 
         */


        var planeBuilder = GetPlaneBuilder(gamePlaneSize, listOfMazeElementsThatAreMazeWall);

        MazeMetric mazeMetric = new MazeMetric(planeBuilder);
        mazeMetric.SetMazeMetric();

        Assert.AreEqual(mazeMetric.TotalNumberOfDeadEnds, 5);
        Assert.AreEqual(mazeMetric.TotalNumberOfFourWayJunctions, 0);
        Assert.AreEqual(mazeMetric.TotalNumberOfHallwayNodes, 2);
        Assert.AreEqual(mazeMetric.TotalNumberOfJunctions, 3);
        Assert.AreEqual(mazeMetric.TotalNumberOfNodes, 36);
        Assert.AreEqual(mazeMetric.TotalNumberOfThreeWayJunctions, 3);
        Assert.AreEqual(mazeMetric.TotalNumberOfWalkableNodes, 10);
    }

    [Test]
    public void _1_6_SetMazeMetric_IncreaseNumberOfDeadEnds_ReceiveCheck()
    {
        Vector2 gamePlaneSize = new Vector2(6, 6);

        List<Vector2> listOfMazeElementsThatAreMazeWall = new List<Vector2>();
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 0));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 3));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(5, 5));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 3));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 5));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 5));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 5));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 5));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(4, 5));

        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(1, 4));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(2, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 2));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(3, 4));


        /*      Maze Construction
         *      o o o o o o
         *      o   o     o
         *      o o   o   o
         *      o         o
         *      o o   o   o
         *      o o o o o o 
         */


        var planeBuilder = GetPlaneBuilder(gamePlaneSize, listOfMazeElementsThatAreMazeWall);

        MazeMetric mazeMetric = new MazeMetric(planeBuilder);
        mazeMetric.SetMazeMetric();

        Assert.AreEqual(mazeMetric.TotalNumberOfDeadEnds, 5);
        Assert.AreEqual(mazeMetric.TotalNumberOfFourWayJunctions, 1);
        Assert.AreEqual(mazeMetric.TotalNumberOfHallwayNodes, 3);
        Assert.AreEqual(mazeMetric.TotalNumberOfJunctions, 2);
        Assert.AreEqual(mazeMetric.TotalNumberOfNodes, 36);
        Assert.AreEqual(mazeMetric.TotalNumberOfThreeWayJunctions, 1);
        Assert.AreEqual(mazeMetric.TotalNumberOfWalkableNodes, 11);
    }
}
