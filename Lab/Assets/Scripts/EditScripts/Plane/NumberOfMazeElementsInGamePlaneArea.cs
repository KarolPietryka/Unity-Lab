using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INumberOfMazeElementsInGamePlaneArea
{
    Vector2 IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea();
}
public class NumberOfMazeElementsInGamePlaneArea : INumberOfMazeElementsInGamePlaneArea
{
    public IPlaneElementsBounds planeElementsBounds;

    public NumberOfMazeElementsInGamePlaneArea(IPlaneElementsBounds _planeElementsBounds)
    {
        planeElementsBounds = _planeElementsBounds;
    }
    /*
    public void SetPlaneElementsBounds(IPlaneElementsBounds _planeElementsBounds)
    {
        planeElementsBounds = _planeElementsBounds;
    }*/

    public Vector2 IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea()
    {
        //formula : mazeElementSideLenght * N + (N - 1) * mazeElementGap = gamePlaneSideLenght
        int numberOfMazeElementsInXAxis = (int)((planeElementsBounds.GamePlaneBounds.size.x + planeElementsBounds.MazeElementGapBetween) / (planeElementsBounds.MazeElementBounds.size.x + planeElementsBounds.MazeElementGapBetween));
        int numberOfMazeElementsInYAxis = (int)((planeElementsBounds.GamePlaneBounds.size.y + planeElementsBounds.MazeElementGapBetween) / (planeElementsBounds.MazeElementBounds.size.y + planeElementsBounds.MazeElementGapBetween));
        return new Vector2(numberOfMazeElementsInXAxis, numberOfMazeElementsInYAxis);
    }
}
