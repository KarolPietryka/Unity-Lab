using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstUpLeftMazeElementPositionProvider{

    public IPlaneBuilder planeController;
    public IPlaneElementsBounds planeElementsBounds;

    public void SetPlaneController(IPlaneBuilder _planeController)
    {
        planeController = _planeController;
    }
    public void SetPlaneElementsBounds(IPlaneElementsBounds _planeElementsBounds)
    {
        planeElementsBounds = _planeElementsBounds;
    }

    public Vector2 PositionOfFirstUpLeftMazeElementOnGamePlaneArea()
    {
        Vector2 mazeElementsAndGapsLenghtSumOnAxis = MazeElementsAndGapsLenghtSumOnAxis();
        float lastGapAfterMazeElementsRaw = planeElementsBounds.GamePlaneBounds.size.x - mazeElementsAndGapsLenghtSumOnAxis.x;
        float firstMazeElementStartPositionX = -planeElementsBounds.GamePlaneBounds.extents.x + (lastGapAfterMazeElementsRaw / 2) + (planeElementsBounds.MazeElementBounds.size.x / 2);

        float lastGapUnderMazeElementsColumn = planeElementsBounds.GamePlaneBounds.size.y - mazeElementsAndGapsLenghtSumOnAxis.y;
        float firstMazeElementStartPositionY = planeElementsBounds.GamePlaneBounds.extents.y - (lastGapUnderMazeElementsColumn / 2) - (planeElementsBounds.MazeElementBounds.size.y / 2);

        return new Vector3(firstMazeElementStartPositionX, firstMazeElementStartPositionY, planeElementsBounds.GamePlaneBounds.center.z);
    }

    public Vector2 MazeElementsAndGapsLenghtSumOnAxis()
    {
        Vector2 mazeElementsAndGapsLenghtSumOnAxis = new Vector2();
        mazeElementsAndGapsLenghtSumOnAxis.x = planeController.IntagerNumberOfMazeElementsOnXAndY.x * planeElementsBounds.MazeElementBounds.size.x + (planeController.IntagerNumberOfMazeElementsOnXAndY.x - 1) * planeElementsBounds.MazeElementGapBetween;
        mazeElementsAndGapsLenghtSumOnAxis.y = planeController.IntagerNumberOfMazeElementsOnXAndY.y * planeElementsBounds.MazeElementBounds.size.y + (planeController.IntagerNumberOfMazeElementsOnXAndY.y - 1) * planeElementsBounds.MazeElementGapBetween;

        return mazeElementsAndGapsLenghtSumOnAxis;
    }
}
