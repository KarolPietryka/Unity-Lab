using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using NSubstitute;

public class FirstUpLeftMazeElementProviderTest: AbstractionPlaneTestRoot
{

    #region 1_CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea
    [Test]
    public void _1_1_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnXAxis_Return_m2_5()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(2, 5);
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneBuilderrMock(intagerNumberOfMazeElementsOnXAndY);
        var firstUpLeftMazeElementProvider = Substitute.For<FirstUpLeftMazeElementPositionProvider>(planeController, planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneElementsBounds(planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneController(planeController);


        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = firstUpLeftMazeElementProvider.PositionOfFirstUpLeftMazeElementOnGamePlaneArea();
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.x, -2.0f);
    }

    [Test]
    public void _1_2_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnXAxis_Return_m44()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(9, 6);
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneBuilderrMock(intagerNumberOfMazeElementsOnXAndY);
        var firstUpLeftMazeElementProvider = Substitute.For<FirstUpLeftMazeElementPositionProvider>(planeController, planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneElementsBounds(planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = firstUpLeftMazeElementProvider.PositionOfFirstUpLeftMazeElementOnGamePlaneArea();
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.x, -44.0f);
    }

    [Test]
    public void _1_3_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnXAxis_Return_m4()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(12, 7, -5));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 3, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(3, 1);
        float mazeElementsGapBetween = 3;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneBuilderrMock(intagerNumberOfMazeElementsOnXAndY);
        var firstUpLeftMazeElementProvider = Substitute.For<FirstUpLeftMazeElementPositionProvider>(planeController, planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneElementsBounds(planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = firstUpLeftMazeElementProvider.PositionOfFirstUpLeftMazeElementOnGamePlaneArea();
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.x, -4f);
    }

    [Test]
    public void _2_1_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnYAxis_Return_4()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(2, 5);
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneBuilderrMock(intagerNumberOfMazeElementsOnXAndY);
        var firstUpLeftMazeElementProvider = Substitute.For<FirstUpLeftMazeElementPositionProvider>(planeController, planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneElementsBounds(planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = firstUpLeftMazeElementProvider.PositionOfFirstUpLeftMazeElementOnGamePlaneArea();
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.y, 4.0f);
    }

    [Test]
    public void _2_2_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnYAxis_Return_40()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(9, 6);
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneBuilderrMock(intagerNumberOfMazeElementsOnXAndY);
        var firstUpLeftMazeElementProvider = Substitute.For<FirstUpLeftMazeElementPositionProvider>(planeController, planeElementsBounds);
       // firstUpLeftMazeElementProvider.SetPlaneElementsBounds(planeElementsBounds);
       // firstUpLeftMazeElementProvider.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = firstUpLeftMazeElementProvider.PositionOfFirstUpLeftMazeElementOnGamePlaneArea();
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.y, 40.0f);
    }

    [Test]
    public void _2_3_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnYAxis_Return_0()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(12, 7, -5));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 3, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(3, 1);
        float mazeElementsGapBetween = 3;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneBuilderrMock(intagerNumberOfMazeElementsOnXAndY);
        var firstUpLeftMazeElementProvider = Substitute.For<FirstUpLeftMazeElementPositionProvider>(planeController, planeElementsBounds);
       // firstUpLeftMazeElementProvider.SetPlaneElementsBounds(planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = firstUpLeftMazeElementProvider.PositionOfFirstUpLeftMazeElementOnGamePlaneArea();
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.y, 0f);
    }

    #endregion
    #region 2_MazeElementsAndGapsLenghtSumOnAxis
    [Test]
    public void _2_1_MazeElementsAndGapsLenghtSumOnAxis_Return_10And34()
    {
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(2, 4, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(3, 6);
        float mazeElementsGapBetween = 2;

        var planeElementsBounds = getPlaneElementsBoundsMock(mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneBuilderrMock(intagerNumberOfMazeElementsOnXAndY);
        var firstUpLeftMazeElementProvider = Substitute.For<FirstUpLeftMazeElementPositionProvider>(planeController, planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneElementsBounds(planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneController(planeController);

        Vector2 mazeElementsAndGapsLenghtSumOnAxis = firstUpLeftMazeElementProvider.MazeElementsAndGapsLenghtSumOnAxis();
        Assert.AreEqual(mazeElementsAndGapsLenghtSumOnAxis.x, 10f);
        Assert.AreEqual(mazeElementsAndGapsLenghtSumOnAxis.y, 34f);
    }

    [Test]
    public void _2_2_MazeElementsAndGapsLenghtSumOnAxis_Return_4And30()
    {
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(4, 5, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(1, 6);
        float mazeElementsGapBetween = 0;

        var planeElementsBounds = getPlaneElementsBoundsMock(mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneBuilderrMock(intagerNumberOfMazeElementsOnXAndY);
        var firstUpLeftMazeElementProvider = Substitute.For<FirstUpLeftMazeElementPositionProvider>(planeController, planeElementsBounds);
        //firstUpLeftMazeElementProvider.SetPlaneElementsBounds(planeElementsBounds);
       // firstUpLeftMazeElementProvider.SetPlaneController(planeController);

        Vector2 mazeElementsAndGapsLenghtSumOnAxis = firstUpLeftMazeElementProvider.MazeElementsAndGapsLenghtSumOnAxis();
        Assert.AreEqual(mazeElementsAndGapsLenghtSumOnAxis.x, 4f);
        Assert.AreEqual(mazeElementsAndGapsLenghtSumOnAxis.y, 30f);
    }
    #endregion
}
