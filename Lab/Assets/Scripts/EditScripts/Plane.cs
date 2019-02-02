using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlaneController
{
    void CreateMazeElementPrefab(Vector3 positionOfMazeElement, int i, int j);
    Vector2 IntagerNumberOfMazeElementsOnXAndY { get; set; }
    IMazeElement[,] MazeArray { get; set; }
    IMazeElement GetFromMazeArray(int x, int y);
    IMazeElement[] NextPossibleMazeElementsToProcess(Direction buildingDirection, IMazeElement currentMouseOnMazeElement);
}
public class Plane
{
    public IPlaneController planeController;
    public IPlaneElementsBounds planeElementsBounds;

    public void SetPlaneController(IPlaneController _planeController)
    {
        planeController = _planeController;
    }
    public void SetPlaneElementsBounds(IPlaneElementsBounds _planeElementsBounds)
    {
        planeElementsBounds = _planeElementsBounds;
    }


    public void CreateGamePlaneGridInScene()
    {
        Vector3 positionOfMazeElement;
        Vector3 positionOfFirstUpLeftMazeElement = CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(planeElementsBounds.GamePlaneBounds.center.z);
        Vector2 distanceBetweenTwoMazeElementsCentersOnAxis = CountDistanceBetweenTwoMazeElementsCentersOnAxis();

        planeController.MazeArray = new IMazeElement[(int)planeController.IntagerNumberOfMazeElementsOnXAndY.x, (int)planeController.IntagerNumberOfMazeElementsOnXAndY.y];

        for (int i = 0; i < planeController.IntagerNumberOfMazeElementsOnXAndY.x; i++)
        {
            positionOfMazeElement.x = positionOfFirstUpLeftMazeElement.x + i * distanceBetweenTwoMazeElementsCentersOnAxis.x;
            for (int j = 0; j < planeController.IntagerNumberOfMazeElementsOnXAndY.y; j++)
            {
                positionOfMazeElement.y = positionOfFirstUpLeftMazeElement.y - j * distanceBetweenTwoMazeElementsCentersOnAxis.y;
                positionOfMazeElement.z = planeElementsBounds.GamePlaneBounds.center.z - 1;
                
                Debug.Log(positionOfMazeElement.z);
                planeController.CreateMazeElementPrefab(positionOfMazeElement, i, j);
            }
        }
    }

    public Vector2 CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(float _gamePlaneBoundsZAxis)
    {
        Vector2 mazeElementsAndGapsLenghtSumOnAxis = MazeElementsAndGapsLenghtSumOnAxis();
        float lastGapAfterMazeElementsRaw = planeElementsBounds.GamePlaneSidesLenght.x - mazeElementsAndGapsLenghtSumOnAxis.x;
        float firstMazeElementStartPositionX = -planeElementsBounds.GamePlaneBounds.extents.x + (lastGapAfterMazeElementsRaw / 2) + (planeElementsBounds.MazeElementSidesLenght.x / 2);

        float lastGapUnderMazeElementsColumn = planeElementsBounds.GamePlaneSidesLenght.y - mazeElementsAndGapsLenghtSumOnAxis.y;
        float firstMazeElementStartPositionY = planeElementsBounds.GamePlaneBounds.extents.y - (lastGapUnderMazeElementsColumn / 2) - (planeElementsBounds.MazeElementSidesLenght.y / 2);

        return new Vector3(firstMazeElementStartPositionX, firstMazeElementStartPositionY, _gamePlaneBoundsZAxis);
    }

    public Vector2 MazeElementsAndGapsLenghtSumOnAxis()
    {
        Vector2 mazeElementsAndGapsLenghtSumOnAxis = new Vector2();
        mazeElementsAndGapsLenghtSumOnAxis.x = planeController.IntagerNumberOfMazeElementsOnXAndY.x * planeElementsBounds.MazeElementSidesLenght.x + (planeController.IntagerNumberOfMazeElementsOnXAndY.x - 1) * planeElementsBounds.MazeElementGapBetween;
        mazeElementsAndGapsLenghtSumOnAxis.y = planeController.IntagerNumberOfMazeElementsOnXAndY.y * planeElementsBounds.MazeElementSidesLenght.y + (planeController.IntagerNumberOfMazeElementsOnXAndY.y - 1) * planeElementsBounds.MazeElementGapBetween;

        return mazeElementsAndGapsLenghtSumOnAxis;
    }

    public Vector2 CountDistanceBetweenTwoMazeElementsCentersOnAxis()
    {
        Vector2 distanceBetweenTwoMazeElementsCentersOnAxis = new Vector2();
        distanceBetweenTwoMazeElementsCentersOnAxis.x = 2 * planeElementsBounds.MazeElementBounds.extents.x + planeElementsBounds.MazeElementGapBetween;
        distanceBetweenTwoMazeElementsCentersOnAxis.y = 2 * planeElementsBounds.MazeElementBounds.extents.y + planeElementsBounds.MazeElementGapBetween;

        return distanceBetweenTwoMazeElementsCentersOnAxis;
    }

    public Vector2 CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea()
    {
        //formula : mazeElementSideLenght * N + (N - 1) * mazeElementGap = gamePlaneSideLenght
        int numberOfMazeElementsInXAxis = (int)((planeElementsBounds.GamePlaneSidesLenght.x + planeElementsBounds.MazeElementGapBetween) / (planeElementsBounds.MazeElementSidesLenght.x + planeElementsBounds.MazeElementGapBetween));
        int numberOfMazeElementsInYAxis = (int)((planeElementsBounds.GamePlaneSidesLenght.y + planeElementsBounds.MazeElementGapBetween) / (planeElementsBounds.MazeElementSidesLenght.y + planeElementsBounds.MazeElementGapBetween));
        return new Vector2(numberOfMazeElementsInXAxis, numberOfMazeElementsInYAxis);
    }

    
}