using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface INextPossibleMazeElementsProvider
{
    IMazeElement[] GetNextPossibleMazeElementsToProcess(Direction buildingDirection, IMazeElement currentMouseOnMazeElement);

}
public class NextPossibleMazeElementsProvider{

    public IPlaneController planeController;

    public void SetPlaneController(IPlaneController _planeController)
    {
        planeController = _planeController;
    }

    public IMazeElement[] GetNextPossibleMazeElementsToProcess(Direction buildingDirection, IMazeElement currentMouseOnMazeElement)
    {
        IMazeElement[] NextPossibleMazeElementsToProcess = new IMazeElement[2];

        Vector2 currentMouseOnMazeElementIndex = currentMouseOnMazeElement.Index;
        Vector2 intagerNumberOfMazeElementsOnXAndY = planeController.IntagerNumberOfMazeElementsOnXAndY;
        try
        {
            if (buildingDirection == Direction.Left || buildingDirection == Direction.Right)
            {
                NextPossibleMazeElementsToProcess[0] = planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x - 1, (int)currentMouseOnMazeElementIndex.y);

                NextPossibleMazeElementsToProcess[1] = planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x + 1, (int)currentMouseOnMazeElementIndex.y);
                NextPossibleMazeElementsToProcess[1].PositionInReferenceToCurrentMazeElement = Direction.Right;
            }
            else if (buildingDirection == Direction.Up || buildingDirection == Direction.Down)
            {
                NextPossibleMazeElementsToProcess[0] = planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y - 1);
                NextPossibleMazeElementsToProcess[0].PositionInReferenceToCurrentMazeElement = Direction.Up;

                NextPossibleMazeElementsToProcess[1] = planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y + 1);
                NextPossibleMazeElementsToProcess[1].PositionInReferenceToCurrentMazeElement = Direction.Down;
            }
        }
        catch (System.IndexOutOfRangeException)
        {
            NextPossibleMazeElementsToProcessForExtremePoints(buildingDirection, currentMouseOnMazeElement);
        }
        return NextPossibleMazeElementsToProcess;
    }

    public IMazeElement[] NextPossibleMazeElementsToProcessForExtremePoints(Direction buildingDirection, IMazeElement currentMouseOnMazeElement)
    {
        IMazeElement[] NextPossibleMazeElementsToProcess = new IMazeElement[2];

        Vector2 currentMouseOnMazeElementIndex = currentMouseOnMazeElement.Index;
        Vector2 intagerNumberOfMazeElementsOnXAndY = planeController.IntagerNumberOfMazeElementsOnXAndY;

        if ((int)currentMouseOnMazeElementIndex.x == 0 && (buildingDirection == Direction.Left || buildingDirection == Direction.Right))
        {

            NextPossibleMazeElementsToProcess[1] = planeController.MazeArray[(int)currentMouseOnMazeElementIndex.x + 1, (int)currentMouseOnMazeElementIndex.y];
            NextPossibleMazeElementsToProcess[1].PositionInReferenceToCurrentMazeElement = Direction.Right;
            NextPossibleMazeElementsToProcess[0] = NextPossibleMazeElementsToProcess[1];
        }
        else if ((int)currentMouseOnMazeElementIndex.x == intagerNumberOfMazeElementsOnXAndY.x && (buildingDirection == Direction.Left || buildingDirection == Direction.Right))
        {
            NextPossibleMazeElementsToProcess[0] = planeController.MazeArray[(int)currentMouseOnMazeElementIndex.x - 1, (int)currentMouseOnMazeElementIndex.y];
            NextPossibleMazeElementsToProcess[0].PositionInReferenceToCurrentMazeElement = Direction.Left;
            NextPossibleMazeElementsToProcess[1] = NextPossibleMazeElementsToProcess[0];
        }
        else if ((int)currentMouseOnMazeElementIndex.y == 0 && (buildingDirection == Direction.Up | buildingDirection == Direction.Down))
        {

            NextPossibleMazeElementsToProcess[1] = planeController.MazeArray[(int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y + 1];
            NextPossibleMazeElementsToProcess[1].PositionInReferenceToCurrentMazeElement = Direction.Down;
            NextPossibleMazeElementsToProcess[0] = NextPossibleMazeElementsToProcess[1];
        }
        else if ((int)currentMouseOnMazeElementIndex.y == intagerNumberOfMazeElementsOnXAndY.y && (buildingDirection == Direction.Up || buildingDirection == Direction.Down))
        {
            NextPossibleMazeElementsToProcess[0] = planeController.MazeArray[(int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y - 1];
            NextPossibleMazeElementsToProcess[0].PositionInReferenceToCurrentMazeElement = Direction.Up;
            NextPossibleMazeElementsToProcess[1] = NextPossibleMazeElementsToProcess[0];
        }
        return NextPossibleMazeElementsToProcess;
    }
}
