using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using System.Collections.Generic;
using NSubstitute;


public class PlaneTest: AbstractionPlaneTestRoot
{
    IPlaneBuilder GetPlaneBuilderMock(Vector2 gamePlaneSize)
    {
        var planeBuilder = Substitute.For<IPlaneBuilder>();
        planeBuilder.IntagerNumberOfMazeElementsOnXAndY.Returns(new Vector2(gamePlaneSize.x, gamePlaneSize.y));
        for (int i = 0; i <= gamePlaneSize.x; i++)
        {
            for (int j = 0; j <= gamePlaneSize.y; j++)
            {
                var mazeElement = Substitute.For<IMazeElement>();
                mazeElement.Index.Returns(new Vector2(i, j));
             
                planeBuilder.GetFromMazeArray(i, j).Returns(mazeElement);
            }
        }
        return planeBuilder;
    }

    List<IMazeElement> CreateNeighbourList(IPlaneBuilder planeBuilder, IMazeElement mazeElement)
    {
        List<IMazeElement> mazeElementsList = new List<IMazeElement>();
        mazeElementsList.Add(planeBuilder.GetFromMazeArray((int)mazeElement.Index.x - 1, (int)mazeElement.Index.y));
        mazeElementsList.Add(planeBuilder.GetFromMazeArray((int)mazeElement.Index.x + 1, (int)mazeElement.Index.y));
        mazeElementsList.Add(planeBuilder.GetFromMazeArray((int)mazeElement.Index.x, (int)mazeElement.Index.y - 1));
        mazeElementsList.Add(planeBuilder.GetFromMazeArray((int)mazeElement.Index.x, (int)mazeElement.Index.y + 1));

        return mazeElementsList;
    }

    #region 1_CountDistanceBetweenTwoMazeElementsCentersOnAxis
    [Test]
    public void _1_1_CountDistanceBetweenTwoMazeElementsCentersOnAxis()
    {
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 3, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(mazeElementBounds, mazeElementsGapBetween);
        var gamePlaneBuilder = Substitute.For<PlaneBuilder>();
        gamePlaneBuilder.SetPlaneElementsBounds(planeElementsBounds);

        Vector2 distanceBetweenTwoMazeElementsCentersOnAxis = gamePlaneBuilder.CountDistanceBetweenTwoMazeElementsCentersOnAxis();
        Assert.AreEqual(distanceBetweenTwoMazeElementsCentersOnAxis, new Vector2(11, 4));
    }
    #endregion

    #region  GetNeighboursOfMazeElement
    [Test]
    public void _2_1_GetNeighboursOfMazeElement_CheckIfresultIsEqualWithCorrect()
    {
        Vector2 gamePlaneSize = new Vector2(10, 10);
        IPlaneBuilder planeBoundry = GetPlaneBuilderMock(gamePlaneSize);
        PlaneBuilder planeBuilder =  Substitute.For<PlaneBuilder>();
        planeBuilder.SetPlaneController(planeBoundry);

        IMazeElement currentMazeElement = planeBoundry.GetFromMazeArray((int)gamePlaneSize.x / 2, (int)gamePlaneSize.y / 2);
        List<IMazeElement> neighbourMazeElementList = planeBuilder.GetNeighboursOfMazeElement(currentMazeElement);

        List<IMazeElement> list = CreateNeighbourList(planeBoundry, currentMazeElement);

        Assert.AreEqual(neighbourMazeElementList, list);
    }

    [Test]
    public void _2_2_GetNeighboursOfMazeElement_CheckIfresultIsEqualWithCorrect()
    {
        Vector2 gamePlaneSize = new Vector2(10, 10);
        IPlaneBuilder planeBoundry = GetPlaneBuilderMock(gamePlaneSize);
        PlaneBuilder planeBuilder = Substitute.For<PlaneBuilder>();
        planeBuilder.SetPlaneController(planeBoundry);

        IMazeElement currentMazeElement = planeBoundry.GetFromMazeArray(2, 8);
        List<IMazeElement> neighbourMazeElementList = planeBuilder.GetNeighboursOfMazeElement(currentMazeElement);

        List<IMazeElement> list = CreateNeighbourList(planeBoundry, currentMazeElement);

        Assert.AreEqual(neighbourMazeElementList, list);
    }

    [Test]
    public void _2_3_GetNeighboursOfMazeElement_CheckIfresultIsEqualWithCorrect_BoundaryCase()
    {
        Vector2 gamePlaneSize = new Vector2(10, 10);
        IPlaneBuilder planeBoundry = GetPlaneBuilderMock(gamePlaneSize);
        PlaneBuilder planeBuilder = Substitute.For<PlaneBuilder>();
        planeBuilder.SetPlaneController(planeBoundry);

        IMazeElement currentMazeElement = planeBoundry.GetFromMazeArray(2, 9);
        List<IMazeElement> neighbourMazeElementList = planeBuilder.GetNeighboursOfMazeElement(currentMazeElement);

        List<IMazeElement> list = CreateNeighbourList(planeBoundry, currentMazeElement);
        list[3] = planeBoundry.GetFromMazeArray(2, 9);

        Assert.AreEqual(neighbourMazeElementList, list);
    }
    #endregion
}
