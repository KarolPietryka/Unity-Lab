using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPossibleExtreamPointMazeElements : INextPossibleExtreamPointMazeElements {

    Vector2 currentMouseOnMazeElementIndex;
    Direction buildingDirection;
    IPlaneBuilder planeBuilder;

    public NextPossibleExtreamPointMazeElements() { }
    public NextPossibleExtreamPointMazeElements(Vector2 _currentMouseOnMazeElementIndex, Direction _buildingDirection, IPlaneBuilder _planeBuilder)
    {
        currentMouseOnMazeElementIndex = _currentMouseOnMazeElementIndex;
        buildingDirection = _buildingDirection;
        planeBuilder = _planeBuilder;
    }

    public IMazeElement[] NextPossibleMazeElementsToProcessForExtremePoints()
    {
        IMazeElement[] NextPossibleMazeElementsToProcess = new IMazeElement[2];

        Vector2 intagerNumberOfMazeElementsOnXAndY = planeBuilder.IntagerNumberOfMazeElementsOnXAndY;

        if ((int)currentMouseOnMazeElementIndex.x == 0 && (buildingDirection == Direction.Left || buildingDirection == Direction.Right))
        {
            NextPossibleMazeElementsToProcess[1] = planeBuilder.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x + 1, (int)currentMouseOnMazeElementIndex.y);
            NextPossibleMazeElementsToProcess[1].PositionInReferenceToCurrentMazeElement = Direction.Right;
            NextPossibleMazeElementsToProcess[0] = NextPossibleMazeElementsToProcess[1];
        }
        else if ((int)currentMouseOnMazeElementIndex.x == intagerNumberOfMazeElementsOnXAndY.x && (buildingDirection == Direction.Left || buildingDirection == Direction.Right))
        {
            NextPossibleMazeElementsToProcess[0] = planeBuilder.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x - 1, (int)currentMouseOnMazeElementIndex.y);
            NextPossibleMazeElementsToProcess[0].PositionInReferenceToCurrentMazeElement = Direction.Left;
            NextPossibleMazeElementsToProcess[1] = NextPossibleMazeElementsToProcess[0];
        }
        else if ((int)currentMouseOnMazeElementIndex.y == 0 && (buildingDirection == Direction.Up | buildingDirection == Direction.Down))
        {

            NextPossibleMazeElementsToProcess[1] = planeBuilder.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y + 1);
            NextPossibleMazeElementsToProcess[1].PositionInReferenceToCurrentMazeElement = Direction.Down;
            NextPossibleMazeElementsToProcess[0] = NextPossibleMazeElementsToProcess[1];
        }
        else if ((int)currentMouseOnMazeElementIndex.y == intagerNumberOfMazeElementsOnXAndY.y && (buildingDirection == Direction.Up || buildingDirection == Direction.Down))
        {
            NextPossibleMazeElementsToProcess[0] = planeBuilder.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y - 1);
            NextPossibleMazeElementsToProcess[0].PositionInReferenceToCurrentMazeElement = Direction.Up;
            NextPossibleMazeElementsToProcess[1] = NextPossibleMazeElementsToProcess[0];
        }
        if (NextPossibleMazeElementsToProcess[0] == null || NextPossibleMazeElementsToProcess[1] == null)
        { throw new System.InvalidOperationException(); }
        return NextPossibleMazeElementsToProcess;
    }
}

public interface INextPossibleExtreamPointMazeElements
{
    IMazeElement[] NextPossibleMazeElementsToProcessForExtremePoints();
}
