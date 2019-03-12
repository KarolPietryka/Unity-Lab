using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeElementsListUpdate
{
    void UpdateList(List<IMazeElement> _mazeElementsToProcess, Direction _processDirection, bool newIsMazeWallForRootMazeElement);
}
public class MazeElementsListUpdate : IMazeElementsListUpdate{

    private IPlaneBuilder planeBuilder;
    private IMouse mouseBoundary;

    public List<IMazeElement> mazeElementsToProcess;

    public MazeElementsListUpdate(IMouse _mouseBoundary, IPlaneBuilder _planeBuilder)
    {
        mouseBoundary = _mouseBoundary;
        planeBuilder = _planeBuilder;
    }
    public void UpdateList(List<IMazeElement> _mazeElementsToProcess, Direction _processDirection, bool newIsMazeWallForRootMazeElement)
    {
        mazeElementsToProcess = _mazeElementsToProcess;

        Vector2 LastMouseClickMazeElementIndex = mouseBoundary.GetLastMouseClickMazeElementIndex();
        Vector2 CurrenMouseOntMazeElementIndex = mouseBoundary.GetCurrentMouseOnMazeElementIndex();

        AddToListMouseClickOnMazeElement(LastMouseClickMazeElementIndex, newIsMazeWallForRootMazeElement);
        switch (_processDirection)
        {
            case Direction.Left:
                {
                    for (int i = (int)LastMouseClickMazeElementIndex.x - 1; i >= (int)CurrenMouseOntMazeElementIndex.x; i--)
                    {
                        IMazeElement MazeElementBoundary = planeBuilder.GetFromMazeArray(i, (int)LastMouseClickMazeElementIndex.y);
                        AddToListIfNotBelongToAnotherWall(MazeElementBoundary, newIsMazeWallForRootMazeElement);
                    }

                    break;
                }
            case Direction.Right:
                {
                    for (int i = (int)LastMouseClickMazeElementIndex.x + 1; i <= (int)CurrenMouseOntMazeElementIndex.x; i++)
                    {
                        IMazeElement MazeElementBoundary = planeBuilder.GetFromMazeArray(i, (int)LastMouseClickMazeElementIndex.y);
                        AddToListIfNotBelongToAnotherWall(MazeElementBoundary, newIsMazeWallForRootMazeElement);
                    }
                    break;
                }
            case Direction.Up:
                {
                    for (int i = (int)LastMouseClickMazeElementIndex.y - 1; i >= (int)CurrenMouseOntMazeElementIndex.y; i--)
                    {
                        IMazeElement MazeElementBoundary = planeBuilder.GetFromMazeArray((int)LastMouseClickMazeElementIndex.x, i);
                        AddToListIfNotBelongToAnotherWall(MazeElementBoundary, newIsMazeWallForRootMazeElement);
                    }

                    break;
                }
            case Direction.Down:
                {
                    for (int i = (int)LastMouseClickMazeElementIndex.y + 1; i <= (int)CurrenMouseOntMazeElementIndex.y; i++)
                    {
                        IMazeElement MazeElementBoundary = planeBuilder.GetFromMazeArray((int)LastMouseClickMazeElementIndex.x, i);
                        AddToListIfNotBelongToAnotherWall(MazeElementBoundary, newIsMazeWallForRootMazeElement);
                    }
                    break;
                }
            default:
                {
                    throw new System.NotImplementedException();
                }
        }
    }

    private void AddToListIfNotBelongToAnotherWall(IMazeElement MazeElementBoundary,bool newIsMazeWallForRootMazeElement)
    {
        if (newIsMazeWallForRootMazeElement == true && !MazeElementBoundary.IsElementOfAnotherWall ||
            newIsMazeWallForRootMazeElement == false && MazeElementBoundary.IsElementOfAnotherWall)
        {
            mazeElementsToProcess.Add(MazeElementBoundary);
        }
    }

    private void AddToListMouseClickOnMazeElement(Vector2 LastMouseClickMazeElementIndex, bool newIsMazeWallForRootMazeElement)
    {
        AddToListIfNotBelongToAnotherWall(planeBuilder.GetFromMazeArray((int)LastMouseClickMazeElementIndex.x, (int)LastMouseClickMazeElementIndex.y), newIsMazeWallForRootMazeElement);
    }
}
