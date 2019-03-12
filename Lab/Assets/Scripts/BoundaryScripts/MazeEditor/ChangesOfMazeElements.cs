using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IChangesOfMazeElements
{
    void ChangeMazeElementsInListFromTo(IMouse MouseBoundry, Direction processDirection, List<IMazeElement> mazeElementsToProcess, bool newIsMazeWallForRoot);
}
    
public class ChangesOfMazeElements : IChangesOfMazeElements{

    List<IMazeElement> unexploredWalkableMazeElementsList;

    private delegate void Change(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess, bool newIsMazeWallValue);

    public ChangesOfMazeElements() { }

    public void ChangeMazeElementsInListFromTo(IMouse MouseBoundry, Direction processDirection, List<IMazeElement> mazeElementsToProcess, bool newIsMazeWallForRoot)
    {
        Vector2 firstMazeElementToReverseIndex = MouseBoundry.GetLastMouseClickMazeElementIndex();
        Vector2 lastMazeElementToReverseIndex = MouseBoundry.GetCurrentMouseOnMazeElementIndex(); ;
        Change change;
        switch (processDirection)
        {
            case Direction.Left:
                {
                    change = new Change(ChangeOnLeftDirection);
                    break;
                }
            case Direction.Right:
                {
                    change = new Change(ChangeOnRightDirection);
                    break;
                }
            case Direction.Up:
                {
                    change = new Change(ChangeOnUpDirection);
                    break;
                }
            case Direction.Down:
                {
                    change = new Change(ChangeOnDownDirection);
                    break;
                }
            default:
                {
                    throw new System.NotImplementedException();
                }
        }

        change(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess, newIsMazeWallForRoot);
    }

    #region Change
    private void ChangeOnLeftDirection(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess, bool newIsMazeWallValue)
    {
        mazeElementsToProcess.ForEach(delegate (IMazeElement mazeElement)
        {
            if (mazeElement.IsMazeWall != newIsMazeWallValue)
            {
                if (mazeElement.Index.x <= firstMazeElementToReverseIndex.x && mazeElement.Index.x >= lastMazeElementToReverseIndex.x)
                {
                    mazeElement.ReverseIsMazeWall();
                }
            }         
        });
    }
    private void ChangeOnRightDirection(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess, bool newIsMazeWallValue)
    {
        mazeElementsToProcess.ForEach(delegate (IMazeElement mazeElement)
        {
            if (mazeElement.IsMazeWall != newIsMazeWallValue)
            {
                if (mazeElement.Index.x >= firstMazeElementToReverseIndex.x && mazeElement.Index.x <= lastMazeElementToReverseIndex.x)
                {
                    mazeElement.ReverseIsMazeWall();
                }
            }
        });
    }
    private void ChangeOnUpDirection(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess, bool newIsMazeWallValue)
    {
        mazeElementsToProcess.ForEach(delegate (IMazeElement mazeElement)
        {
            if (mazeElement.IsMazeWall != newIsMazeWallValue)
            {
                if (mazeElement.Index.y <= firstMazeElementToReverseIndex.y && mazeElement.Index.y >= lastMazeElementToReverseIndex.y)
                {
                    mazeElement.ReverseIsMazeWall();
                }
            }
        });
    }
    private void ChangeOnDownDirection(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess, bool newIsMazeWallValue)
    {
        mazeElementsToProcess.ForEach(delegate (IMazeElement mazeElement)
        {
            if (mazeElement.IsMazeWall != newIsMazeWallValue)
            {
                if (mazeElement.Index.y >= firstMazeElementToReverseIndex.y && mazeElement.Index.y <= lastMazeElementToReverseIndex.y)
                {
                    mazeElement.ReverseIsMazeWall();
                }
            }
        });
    }
    #endregion

}


