using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IFarthestMazeElement
{
    Vector2 CurrentFarthestMazeElementIndex { get; set; }
    void UpdateIfCurrentMazeEleIsGreater(Direction updatedProcessDirection);
}
public class FarthestMazeElementFromLastMouseClickMazeElement: IFarthestMazeElement
{
    public Vector2 CurrentFarthestMazeElementIndex { get; set; }
    IMouse MouseBoundary;

    public FarthestMazeElementFromLastMouseClickMazeElement(IMouse _mouseBoundary)
    {
        MouseBoundary = _mouseBoundary;
        try
        {
            CurrentFarthestMazeElementIndex = _mouseBoundary.GetCurrentMouseOnMazeElementIndex();
        }
        catch (System.NullReferenceException)
        {
            CurrentFarthestMazeElementIndex = new Vector2(0, 0);
        }
    }

    public void UpdateIfCurrentMazeEleIsGreater(Direction updatedProcessDirection)
    {
        switch (updatedProcessDirection)
        {
            case Direction.Left:
                {
                    if (CurrentFarthestMazeElementIndex.x > MouseBoundary.GetCurrentMouseOnMazeElementIndex().x)
                    {
                        SetNewFarthestMazeEleOnHorizontalLineOfLastClickMazeEle();
                    }
                    break;
                }
            case Direction.Right:
                {
                    if (CurrentFarthestMazeElementIndex.x < MouseBoundary.GetCurrentMouseOnMazeElementIndex().x)
                    {
                        SetNewFarthestMazeEleOnHorizontalLineOfLastClickMazeEle();
                    }
                    break;
                }
            case Direction.Up:
                {
                    if (CurrentFarthestMazeElementIndex.y > MouseBoundary.GetCurrentMouseOnMazeElementIndex().y)
                    {
                        SetNewFarthestMazeEleOnVerticalLineOfLastClickMazeEle();
                    }
                    break;
                }
            case Direction.Down:
                {
                    if (CurrentFarthestMazeElementIndex.y < MouseBoundary.GetCurrentMouseOnMazeElementIndex().y)
                    {
                        SetNewFarthestMazeEleOnVerticalLineOfLastClickMazeEle();
                    }
                    break;
                }

            default:
                {
                    throw new System.NotImplementedException();
                }
        }
    }

    public void SetNewFarthestMazeEleOnHorizontalLineOfLastClickMazeEle()
    {
        CurrentFarthestMazeElementIndex = new Vector2(MouseBoundary.GetCurrentMouseOnMazeElementIndex().x, MouseBoundary.GetLastMouseClickMazeElementIndex().y);
    }

    public void SetNewFarthestMazeEleOnVerticalLineOfLastClickMazeEle()
    {
        CurrentFarthestMazeElementIndex = new Vector2(MouseBoundary.GetLastMouseClickMazeElementIndex().x, MouseBoundary.GetCurrentMouseOnMazeElementIndex().y);
    }
}
