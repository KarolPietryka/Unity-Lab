using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;


public class PlaneTest {

    [Test]
    public void _1_1_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return20()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(4, 4, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;
       
        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea,  20);
    }

    [Test]
    public void _1_2_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return20()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(4, 4, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 20);
    }

    [Test]
    public void _2_1_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return16()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(5, 4, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 16);
    }

    [Test]
    public void _2_2_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return16()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(4, 5, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 16);
    }

    [Test]
    public void _3_1_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return0()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 4, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 0);
    }

    [Test]
    public void _3_2_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return0()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 0);
    }

    [Test]
    public void _4_1_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_ReturnNo0()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 4, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreNotEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 100);
    }

    [Test]
    public void _4_2_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_ReturnNo0()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 4, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreNotEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 100);
    }

    [Test]
    public void _5_1_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return2()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 2);
    }

    [Test]
    public void _5_2_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return5()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 5);
    }

    [Test]
    public void _6_CountIntagerNumberOfMazeElementInGamePlaneArea_ReturnException()
    {
        Plane plane = new Plane();

        Assert.Throws<System.ArgumentOutOfRangeException>(() => plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea());
    }

    [Test]
    public void _7_1_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnXAxis_Return2_5()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        float mazeElementsGapBetween = 1;

        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(new Vector2(2, 5));
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.x, 2.5f);
    }

    [Test]
    public void _7_2_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnYAxis_Return0_5()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        float mazeElementsGapBetween = 1;

        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(new Vector2(2, 5));
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.y, 0.5f);
    }
    [Test]
    public void _5_3_CountIntagerNumberOfMazeElementInGamePlaneAreaOnxAxis_Return9()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 9);
    }
    [Test]
    public void _5_4_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return6()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        float mazeElementsGapBetween = 1;
        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 6);
    }

    [Test]
    public void _8_1_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnXAxis_Return5_5()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        float mazeElementsGapBetween = 1;

        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(new Vector2(9, 6));
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.x, 5.5f);
    }

    [Test]
    public void _8_2_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnYAxis_Return0_9_5()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        float mazeElementsGapBetween = 1;

        Plane plane = new Plane(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(new Vector2(9, 6));
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.y, 9.5f);
    }

}
