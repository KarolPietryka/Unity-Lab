using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaneBuilder
{
    void CreateMazeElementPrefab(Vector3 positionOfMazeElement, int i, int j);
    Vector2 IntagerNumberOfMazeElementsOnXAndY { get; set; }
    void InitMazeArray();
    IMazeElement GetFromMazeArray(int x, int y);
    IMazeElement[] NextPossibleMazeElementsToProcess(Direction buildingDirection, IMazeElement currentMouseOnMazeElement);
}
public class PlaneBuilder:PlaneBuilderInitiator
{
    public PlaneBuilder()
    {
        firstUpLeftMazeElementProvider = new FirstUpLeftMazeElementPositionProvider();
        numberOfMazeElementsInGamePlaneArea = new NumberOfMazeElementsInGamePlaneArea();
    }
    public void SetInterfaces(IPlaneBuilder _planeBuilder, IPlaneElementsBounds _planeElementsBounds)
    {
        SetPlaneController(_planeBuilder);
        SetPlaneElementsBounds(_planeElementsBounds);

        InitFirstUpLeftMazeElementProvider();
        InitNumberOfMazeElementsInGamePlaneArea();
    }

    public void CreateGamePlaneGridInScene()
    {
        PlaneBuilder.IntagerNumberOfMazeElementsOnXAndY = numberOfMazeElementsInGamePlaneArea.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea();
        Vector3 positionOfMazeElement;
        Vector3 positionOfFirstUpLeftMazeElement = firstUpLeftMazeElementProvider.PositionOfFirstUpLeftMazeElementOnGamePlaneArea();
        Vector2 distanceBetweenTwoMazeElementsCentersOnAxis = CountDistanceBetweenTwoMazeElementsCentersOnAxis();

        PlaneBuilder.InitMazeArray();

        for (int i = 0; i < PlaneBuilder.IntagerNumberOfMazeElementsOnXAndY.x; i++)
        {
            positionOfMazeElement.x = positionOfFirstUpLeftMazeElement.x + i * distanceBetweenTwoMazeElementsCentersOnAxis.x;
            for (int j = 0; j < PlaneBuilder.IntagerNumberOfMazeElementsOnXAndY.y; j++)
            {
                positionOfMazeElement.y = positionOfFirstUpLeftMazeElement.y - j * distanceBetweenTwoMazeElementsCentersOnAxis.y;
                positionOfMazeElement.z = PlaneElementsBounds.GamePlaneBounds.center.z - 1;

                PlaneBuilder.CreateMazeElementPrefab(positionOfMazeElement, i, j);
            }
        }
    }


    public Vector2 CountDistanceBetweenTwoMazeElementsCentersOnAxis()
    {
        Vector2 distanceBetweenTwoMazeElementsCentersOnAxis = new Vector2();
        distanceBetweenTwoMazeElementsCentersOnAxis.x = PlaneElementsBounds.MazeElementBounds.size.x + PlaneElementsBounds.MazeElementGapBetween;
        distanceBetweenTwoMazeElementsCentersOnAxis.y = PlaneElementsBounds.MazeElementBounds.size.y + PlaneElementsBounds.MazeElementGapBetween;

        return distanceBetweenTwoMazeElementsCentersOnAxis;
    }

}