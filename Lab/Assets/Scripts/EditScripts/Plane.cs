using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IPlane
{
    Bounds GamePlaneBound { get; set; }
    Bounds MazeElementBound { get; set; }
    Vector2 GamePlaneSidesLenght { get; set; }
    Vector2 MazeElementSidesLenght { get; set; }

    float MazeElementGapBetween { get; set; }
    Vector2 CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea();
    Vector2 CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(Vector2 _intagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea);


}
public class Plane : IPlane {

    public Bounds GamePlaneBound { get; set; }
    public Bounds MazeElementBound { get; set; }
    public Vector2 GamePlaneSidesLenght { get; set; }
    public Vector2 MazeElementSidesLenght { get; set; }

    public float MazeElementGapBetween { get; set; }


    public Plane() { }
    public Plane(Bounds _gamePlaneBounds, Bounds _mazeElementBounds, float _mazeElementsGapBetween)
    {
        GamePlaneBound = _gamePlaneBounds;
        MazeElementBound = _mazeElementBounds;
        MazeElementGapBetween = _mazeElementsGapBetween;

        GamePlaneSidesLenght = new Vector2(2 * GamePlaneBound.extents.x, 2 * GamePlaneBound.extents.y);
        MazeElementSidesLenght = new Vector2(2 * MazeElementBound.extents.x, 2 * MazeElementBound.extents.y);
    }

    public Vector2 CountIntagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea()
    {
     
        if (GamePlaneSidesLenght.x <= 0  || GamePlaneSidesLenght.y <= 0|| MazeElementSidesLenght.x <= 0 || MazeElementSidesLenght.y <= 0 || MazeElementGapBetween <= 0)
        {
            throw new System.ArgumentOutOfRangeException();
        }

        int numberOfMazeElementsInXAxis = (int)(GamePlaneSidesLenght.x / (MazeElementSidesLenght.x + MazeElementGapBetween));
        int numberOfMazeElementsInYAxis = (int)(GamePlaneSidesLenght.y / (MazeElementSidesLenght.y + MazeElementGapBetween));

        return new Vector2(numberOfMazeElementsInXAxis, numberOfMazeElementsInYAxis);
    }

    public Vector2 CountPositionOfFirstUpLeftMazeElementOnGamePlaneArea(Vector2 _intagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea)
    {
        float mazeElementsAndGapsLenghtSumOnX = _intagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea.x * (MazeElementSidesLenght.x + MazeElementGapBetween);
        float lastGapAfterMazeElementsRaw = GamePlaneSidesLenght.x - mazeElementsAndGapsLenghtSumOnX;      
        float firstMazeElementStartPositionX = lastGapAfterMazeElementsRaw / 2 + MazeElementSidesLenght.x / 2;


        float mazeElementsAndGapsLenghtSumOnY = _intagerNumberOfMazeElementOnXAndYAxisInGamePlaneArea.y * (MazeElementSidesLenght.y + MazeElementGapBetween);
        float lastGapUnderMazeElementsColumn = GamePlaneSidesLenght.y - mazeElementsAndGapsLenghtSumOnY;
        float firstMazeElementStartPositionY = lastGapUnderMazeElementsColumn / 2 + MazeElementSidesLenght.y / 2;

        return new Vector2(firstMazeElementStartPositionX, firstMazeElementStartPositionY);
    }
}
