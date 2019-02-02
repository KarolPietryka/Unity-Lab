using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using NSubstitute;


public class PlaneTest {


    private IPlaneController getPlaneControllerMock(Vector2 intagerNumberOfMazeElementsOnXAndY)
    {
        var planeController = Substitute.For<IPlaneController>();   
        planeController.IntagerNumberOfMazeElementsOnXAndY.Returns(intagerNumberOfMazeElementsOnXAndY);

        return planeController;
    }

    private IPlaneElementsBounds getPlaneElementsBoundsMock(Bounds gamePlaneBounds, Bounds mazeElementBounds, float mazeElementsGapBetween)
    {

        Vector2 gamePlaneSidesLenght = new Vector2(2 * gamePlaneBounds.extents.x, 2 * gamePlaneBounds.extents.y);
        Vector2 mazeElementSidesLenght = new Vector2(2 * mazeElementBounds.extents.x, 2 * mazeElementBounds.extents.y);
        Vector2 mazeElementAndGapSumOn = new Vector2(mazeElementSidesLenght.x + mazeElementsGapBetween, mazeElementSidesLenght.y + mazeElementsGapBetween);

        var planeElementsBounds = Substitute.For<IPlaneElementsBounds>();
        planeElementsBounds.GamePlaneBounds.Returns(gamePlaneBounds);
        planeElementsBounds.MazeElementBounds.Returns(mazeElementBounds);
        planeElementsBounds.MazeElementGapBetween.Returns(mazeElementsGapBetween);
        planeElementsBounds.GamePlaneSidesLenght.Returns(gamePlaneSidesLenght);
        planeElementsBounds.MazeElementSidesLenght.Returns(mazeElementSidesLenght);
        planeElementsBounds.MazeElementAndGapSumOn.Returns(mazeElementAndGapSumOn);


        return planeElementsBounds;
    }

    private IPlaneElementsBounds getPlaneElementsBoundsMock(Bounds mazeElementBounds, float mazeElementsGapBetween)
    {
        Vector2 mazeElementSidesLenght = new Vector2(2 * mazeElementBounds.extents.x, 2 * mazeElementBounds.extents.y);
 
        var planeElementsBounds = Substitute.For<IPlaneElementsBounds>(); 
        planeElementsBounds.MazeElementBounds.Returns(mazeElementBounds);
        planeElementsBounds.MazeElementGapBetween.Returns(mazeElementsGapBetween);
        planeElementsBounds.MazeElementSidesLenght.Returns(mazeElementSidesLenght);

        return planeElementsBounds;

    }
    private IMazeElement getMazeElementMock(Vector2 mazeElementIndex)
    {
        var currentMouseOnMazeElement = Substitute.For<IMazeElement>();
        currentMouseOnMazeElement.Index.Returns(mazeElementIndex);

        return currentMouseOnMazeElement;
    }

    #region 1,2 CountIntagerNumberOfMazeElementInGamePlaneArea
    [Test]
    public void _1_1_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return20()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(4, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;
       
        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea,  20);
    }

    [Test]
    public void _1_2_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return16()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(5, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 16);
    }


    [Test]
    public void _1_3_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return1()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 1);
    }

    [Test]
    public void _1_4_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_ReturnNo100()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreNotEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 100);
    }

    [Test]
    public void _1_5_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return2()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 2);
    }

    [Test]
    public void _1_6_CountIntagerNumberOfMazeElementInGamePlaneAreaOnXAxis_Return9()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().x;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 9);
    }

    [Test]
    public void _2_1_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return20()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(4, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 20);
    }

    [Test]
    public void _2_2_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return14()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(5, 6, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 14);
    }

    

    [Test]
    public void _2_3_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return1()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 1);
    }
   

    [Test]
    public void _2_4_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_ReturnNo100()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 4, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreNotEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 100);
    }
    

    [Test]
    public void _2_5_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return5()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 5);
    }

   
    [Test]
    public void _2_6_CountIntagerNumberOfMazeElementInGamePlaneAreaOnYAxis_Return6()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);

        int intagerNumberOfMazeElementsOnXAxisInGamePlaneArea = (int)plane.CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea().y;

        Assert.AreEqual(intagerNumberOfMazeElementsOnXAxisInGamePlaneArea, 6);
    }
    #endregion
    #region 3,4 CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea
    [Test]
    public void _3_1_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnXAxis_Return_m2_5()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(2, 5);
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);
        plane.SetPlaneController(planeController);


        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(gamePlaneBounds.extents.z);
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.x, -2.0f);
    }

    [Test]
    public void _3_2_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnXAxis_Return_m44()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(9, 6);
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);
        plane.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(gamePlaneBounds.extents.z);
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.x, -44.0f);
    }

    [Test]
    public void _3_3_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnXAxis_Return_m4()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(12, 7, -5));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 3, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(3, 1);
        float mazeElementsGapBetween = 3;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);
        plane.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(gamePlaneBounds.extents.z);
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.x, -4f);
    }

    [Test]
    public void _4_1_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnYAxis_Return_4()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 1));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(3, 1, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(2, 5);
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);
        plane.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(gamePlaneBounds.extents.z);
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.y, 4.0f);
    }

    [Test]
    public void _4_2_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnYAxis_Return_40()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 50));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(10, 15, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(9, 6);
        float mazeElementsGapBetween = 1;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);
        plane.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(gamePlaneBounds.extents.z);
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.y, 40.0f);
    }

    [Test]
    public void _4_3_CountPositionOfFirstUpLeftMazeElementOnGamePlaneAreaOnYAxis_Return_0()
    {
        Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(12, 7, -5));
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(1, 3, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(3, 1);
        float mazeElementsGapBetween = 3;

        var planeElementsBounds = getPlaneElementsBoundsMock(gamePlaneBounds, mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);
        plane.SetPlaneController(planeController);

        Vector2 positionOfFirstUpLeftMazeElementOnGamePlaneArea = plane.CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(gamePlaneBounds.extents.z);
        Assert.AreEqual(positionOfFirstUpLeftMazeElementOnGamePlaneArea.y, 0f);
    }

    #endregion
    #region 5 MazeElementsAndGapsLenghtSumOnAxis
    [Test]
    public void _5_1_MazeElementsAndGapsLenghtSumOnAxis_Return_10And34()
    {
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(2, 4, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(3, 6);
        float mazeElementsGapBetween = 2;

        var planeElementsBounds = getPlaneElementsBoundsMock(mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);
        plane.SetPlaneController(planeController);

        Vector2 mazeElementsAndGapsLenghtSumOnAxis = plane.MazeElementsAndGapsLenghtSumOnAxis();
        Assert.AreEqual(mazeElementsAndGapsLenghtSumOnAxis.x, 10f);
        Assert.AreEqual(mazeElementsAndGapsLenghtSumOnAxis.y, 34f);
    }

    [Test]
    public void _5_2_MazeElementsAndGapsLenghtSumOnAxis_Return_4And30()
    {
        Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(4, 5, 1));
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(1, 6);
        float mazeElementsGapBetween = 0;

        var planeElementsBounds = getPlaneElementsBoundsMock(mazeElementBounds, mazeElementsGapBetween);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY);
        var plane = Substitute.For<Plane>();
        plane.SetPlaneElementsBounds(planeElementsBounds);
        plane.SetPlaneController(planeController);

        Vector2 mazeElementsAndGapsLenghtSumOnAxis = plane.MazeElementsAndGapsLenghtSumOnAxis();
        Assert.AreEqual(mazeElementsAndGapsLenghtSumOnAxis.x, 4f);
        Assert.AreEqual(mazeElementsAndGapsLenghtSumOnAxis.y, 30f);
    }
    #endregion
}
