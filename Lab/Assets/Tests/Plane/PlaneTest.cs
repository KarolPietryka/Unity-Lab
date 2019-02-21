using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using NSubstitute;


public class PlaneTest: AbstractionPlaneTestRoot
{

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
}
