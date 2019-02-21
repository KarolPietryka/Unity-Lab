using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IReversalOfMazeElements
{
    void ReverseFromToInList(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, Direction processDirection, List<IMazeElement> mazeElementsToProcess);
}
public class ReversalOfMazeElements : IReversalOfMazeElements{

    private delegate void Reverse(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess);

    public void ReverseFromToInList(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, Direction processDirection, List<IMazeElement> mazeElementsToProcess)
    {
        Reverse reversion;
        switch (processDirection)
        {
            case Direction.Left:
                {
                    reversion = new Reverse(ReverseOnLeftDirection);
                    break;
                }
            case Direction.Right:
                {
                    reversion = new Reverse(ReverseOnRightDirection);
                    break;
                }
            case Direction.Up:
                {
                    reversion = new Reverse(ReverseOnUpDirection);

                    break;
                }
            case Direction.Down:
                {
                    reversion = new Reverse(ReverseOnDownDirection);
                    break;
                }
            default:
                {
                    throw new System.NotImplementedException();
                }
        }

        reversion(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, mazeElementsToProcess);
    }

    #region Reversion
    private void ReverseOnLeftDirection(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess)
    {
        mazeElementsToProcess.ForEach(delegate (IMazeElement mazeElement)
        {
            if (mazeElement.Index.x <= firstMazeElementToReverseIndex.x && mazeElement.Index.x >= lastMazeElementToReverseIndex.x)
            {
                mazeElement.ReverseIsMazeWall();
            }
        });
    }
    private void ReverseOnRightDirection(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess)
    {
        mazeElementsToProcess.ForEach(delegate (IMazeElement mazeElement)
        {
            if (mazeElement.Index.x >= firstMazeElementToReverseIndex.x && mazeElement.Index.x <= lastMazeElementToReverseIndex.x)
            {
                mazeElement.ReverseIsMazeWall();
            }
        });
    }
    private void ReverseOnUpDirection(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess)
    {
        mazeElementsToProcess.ForEach(delegate (IMazeElement mazeElement)
        {
            if (mazeElement.Index.y <= firstMazeElementToReverseIndex.y && mazeElement.Index.y >= lastMazeElementToReverseIndex.y)
            {
                mazeElement.ReverseIsMazeWall();
            }
        });
    }
    private void ReverseOnDownDirection(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, List<IMazeElement> mazeElementsToProcess)
    {
        mazeElementsToProcess.ForEach(delegate (IMazeElement mazeElement)
        {
            if (mazeElement.Index.y >= firstMazeElementToReverseIndex.y && mazeElement.Index.y <= lastMazeElementToReverseIndex.y)
            {
                mazeElement.ReverseIsMazeWall();
            }
        });
    }
    #endregion
}
