using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextPossibleRegularMazeElements: INextPossibleRegularMazeElements {

    Vector2 currentMouseOnMazeElementIndex;
    Direction buildingDirection;
    IPlaneBuilder planeBuilder;

    public NextPossibleRegularMazeElements() { }
    public NextPossibleRegularMazeElements(Vector2 _currentMouseOnMazeElementIndex, Direction _buildingDirection, IPlaneBuilder _planeBuilder)
    {
        buildingDirection = _buildingDirection;
        planeBuilder = _planeBuilder;
        currentMouseOnMazeElementIndex = _currentMouseOnMazeElementIndex;
    }

    public IMazeElement[] NextRegularPossibleMazeElementsToProcess()
    {
        IMazeElement[] NextPossibleMazeElementsToProcess = new IMazeElement[2];
 
        if (buildingDirection == Direction.Left || buildingDirection == Direction.Right)
        {
            NextPossibleMazeElementsToProcess[0] = planeBuilder.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x - 1, (int)currentMouseOnMazeElementIndex.y);
            NextPossibleMazeElementsToProcess[0].PositionInReferenceToCurrentMazeElement = Direction.Left;

            NextPossibleMazeElementsToProcess[1] = planeBuilder.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x + 1, (int)currentMouseOnMazeElementIndex.y);
            NextPossibleMazeElementsToProcess[1].PositionInReferenceToCurrentMazeElement = Direction.Right;
        }
        else if (buildingDirection == Direction.Up || buildingDirection == Direction.Down)
        {
            NextPossibleMazeElementsToProcess[0] = planeBuilder.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y - 1);
            NextPossibleMazeElementsToProcess[0].PositionInReferenceToCurrentMazeElement = Direction.Up;

            NextPossibleMazeElementsToProcess[1] = planeBuilder.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y + 1);
            NextPossibleMazeElementsToProcess[1].PositionInReferenceToCurrentMazeElement = Direction.Down;
        }

        return NextPossibleMazeElementsToProcess;
    }
}

public interface INextPossibleRegularMazeElements
{
    IMazeElement[] NextRegularPossibleMazeElementsToProcess();
}
