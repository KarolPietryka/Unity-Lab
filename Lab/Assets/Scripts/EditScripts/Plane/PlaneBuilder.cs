using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaneBuilder: IPlaneElementsBounds
{
    void CreateMazeElementPrefab(Vector3 positionOfMazeElement, int i, int j);
    Vector2 IntagerNumberOfMazeElementsOnXAndY { get; set; }
    void InitMazeArray();
    IMazeElement GetFromMazeArray(int x, int y);
    List<IMazeElement> GetNeighboursOfMazeElement(IMazeElement mazeElement);
    void CreateGamePlaneGridInScene();
}
public class PlaneBuilder : PlaneBuilderInitiator
{
    public PlaneBuilder() { }
    public PlaneBuilder(IFirstUpLeftMazeElementPositionProvider _firstUpLeftMazeElementPositionProvider, INumberOfMazeElementsInGamePlaneArea _numberOfMazeElementsInGamePlaneArea, IPlaneBuilder _planeBuilder,
        IPlaneElementsBounds _planeElementsBounds)
    {
        firstUpLeftMazeElementPositionProvider = _firstUpLeftMazeElementPositionProvider;
        numberOfMazeElementsInGamePlaneArea = _numberOfMazeElementsInGamePlaneArea;
        PlaneBuilder = _planeBuilder;
        PlaneElementsBounds = _planeElementsBounds;
    }

    
    public void CreateGamePlaneGridInScene()
    {
        PlaneBuilder.IntagerNumberOfMazeElementsOnXAndY = numberOfMazeElementsInGamePlaneArea.IntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea();
        Vector3 positionOfMazeElement;
        Vector3 positionOfFirstUpLeftMazeElement = firstUpLeftMazeElementPositionProvider.PositionOfFirstUpLeftMazeElementOnGamePlaneArea();
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

    public List<IMazeElement> GetNeighboursOfMazeElement(IMazeElement mazeElement)
    {
        List<IMazeElement> NeighboursList = new List<IMazeElement>();

        NeighboursList.Add(PlaneBuilder.GetFromMazeArray(Mathf.Clamp((int)mazeElement.Index.x - 1, 0, (int)PlaneBuilder.IntagerNumberOfMazeElementsOnXAndY.x - 1), (int)mazeElement.Index.y));
        NeighboursList.Add(PlaneBuilder.GetFromMazeArray(Mathf.Clamp((int)mazeElement.Index.x + 1, 0, (int)PlaneBuilder.IntagerNumberOfMazeElementsOnXAndY.x - 1), (int)mazeElement.Index.y));
        NeighboursList.Add(PlaneBuilder.GetFromMazeArray((int)mazeElement.Index.x, Mathf.Clamp((int)mazeElement.Index.y - 1, 0, (int)PlaneBuilder.IntagerNumberOfMazeElementsOnXAndY.y - 1)));
        NeighboursList.Add(PlaneBuilder.GetFromMazeArray((int)mazeElement.Index.x, Mathf.Clamp((int)mazeElement.Index.y + 1, 0, (int)PlaneBuilder.IntagerNumberOfMazeElementsOnXAndY.y - 1)));


        return NeighboursList;
    }
}