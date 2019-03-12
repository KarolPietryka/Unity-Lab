using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface INextPossibleMazeElementsProvider
{
    IMazeElement[] GetNextPossibleMazeElementsToProcess();
}
public class NextPossibleMazeElementsProvider{ //: INextPossibleMazeElementsProvider{

   /* INextPossibleRegularMazeElements nextPossibleRegularMazeElements;
    INextPossibleExtreamPointMazeElements nextPossibleExtreamPointMazeElements;

    public NextPossibleMazeElementsProvider(
        INextPossibleRegularMazeElements _nextPossibleRegularMazeElements,
        INextPossibleExtreamPointMazeElements _nextPossibleExtreamPointMazeElements) {

        nextPossibleRegularMazeElements = _nextPossibleRegularMazeElements;
        nextPossibleExtreamPointMazeElements = _nextPossibleExtreamPointMazeElements;
    }
    public NextPossibleMazeElementsProvider(Vector2 _currentMouseOnMazeElementIndex, Direction _buildingDirection, IPlaneBuilder _planeBuilder)
    {
        nextPossibleRegularMazeElements = new NextPossibleRegularMazeElements(_currentMouseOnMazeElementIndex, _buildingDirection, _planeBuilder);
        nextPossibleExtreamPointMazeElements = new NextPossibleExtreamPointMazeElements(_currentMouseOnMazeElementIndex, _buildingDirection, _planeBuilder);
    }

    public IMazeElement[] GetNextPossibleMazeElementsToProcess()
    {
        IMazeElement[] NextPossibleMazeElementsToProcess = new IMazeElement[2];
        try
        {
            NextPossibleMazeElementsToProcess = nextPossibleRegularMazeElements.NextRegularPossibleMazeElementsToProcess();
        }
        catch (System.IndexOutOfRangeException)
        {
            NextPossibleMazeElementsToProcess = nextPossibleExtreamPointMazeElements.NextPossibleMazeElementsToProcessForExtremePoints();
        }
        return NextPossibleMazeElementsToProcess;
    }  */
}
