using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NSubstitute;

public abstract class AbstractionPlaneTestRoot{

    public IPlaneBuilder getPlaneControllerMock(Vector2 intagerNumberOfMazeElementsOnXAndY)
    {
        var planeController = Substitute.For<IPlaneBuilder>();
        planeController.IntagerNumberOfMazeElementsOnXAndY.Returns(intagerNumberOfMazeElementsOnXAndY);

        return planeController;
    }

    public IPlaneElementsBounds getPlaneElementsBoundsMock(Bounds gamePlaneBounds, Bounds mazeElementBounds, float mazeElementsGapBetween)
    {
        Vector2 mazeElementAndGapSumOn = new Vector2(mazeElementBounds.size.x + mazeElementsGapBetween, mazeElementBounds.size.y + mazeElementsGapBetween);

        var planeElementsBounds = Substitute.For<IPlaneElementsBounds>();
        planeElementsBounds.GamePlaneBounds.Returns(gamePlaneBounds);
        planeElementsBounds.MazeElementBounds.Returns(mazeElementBounds);
        planeElementsBounds.MazeElementGapBetween.Returns(mazeElementsGapBetween);
        planeElementsBounds.MazeElementAndGapSumOn.Returns(mazeElementAndGapSumOn);

        return planeElementsBounds;
    }

    public IPlaneElementsBounds getPlaneElementsBoundsMock(Bounds mazeElementBounds, float mazeElementsGapBetween)
    {
        var planeElementsBounds = Substitute.For<IPlaneElementsBounds>();
        planeElementsBounds.MazeElementBounds.Returns(mazeElementBounds);
        planeElementsBounds.MazeElementGapBetween.Returns(mazeElementsGapBetween);

        return planeElementsBounds;
    }

    public IMazeElement getMazeElementMock(Vector2 mazeElementIndex)
    {
        var currentMouseOnMazeElement = Substitute.For<IMazeElement>();
        currentMouseOnMazeElement.Index.Returns(mazeElementIndex);

        return currentMouseOnMazeElement;
    }
}
