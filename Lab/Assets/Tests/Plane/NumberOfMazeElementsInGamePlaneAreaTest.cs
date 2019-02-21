using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using NSubstitute;

public class NumberOfMazeElementsInGamePlaneAreaTest: AbstractionPlaneTestRoot
{

    #region 1_CountIntagerNumberOfMazeElementInGamePlaneArea
    [Test]
    public void _1_1_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return20()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(4, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 20);
    }

    [Test]
    public void _1_2_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return16()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(5, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 16);
    }


    [Test]
    public void _1_3_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return1()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 1);
    }

    [Test]
    public void _1_4_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_ReturnNo100()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreNotEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 100);
    }

    [Test]
    public void _1_5_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return2()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 2);
    }

    [Test]
    public void _1_6_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return9()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 9);
    }

    [Test]
    public void _2_1_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return20()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(4, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 20);
    }

    [Test]
    public void _2_2_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return14()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(5, 6, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 14);
    }



    [Test]
    public void _2_3_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return1()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 1);
    }


    [Test]
    public void _2_4_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_ReturnNo100()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreNotEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 100);
    }


    [Test]
    public void _2_5_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return5()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 5);
    }


    [Test]
    public void _2_6_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return6()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var numberOfMazeElementsInGamePlaneAreaTest = Substitute.For<NumberOfMazeElementsInGamePlaneArea>();
        numberOfMazeElementsInGamePlaneAreaTest.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)numberOfMazeElementsInGamePlaneAreaTest.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 6);
    }
    #endregion
}
