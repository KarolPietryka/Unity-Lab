using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMouseMovementInReferenceToLastClick
{
    bool WasHorizontalMoveInReferenceToLastClick();
}

public interface IMouse : IMouseMovementInReferenceToLastClick
{
    MazeElementBoundary CurrentMouseOnMazeElement { get; set; }
    MazeElementBoundary LastMouseClickMazeElement { get; set; }
    Vector2 GetCurrentMouseOnMazeElementIndex();
    Vector2 GetLastMouseClickMazeElementIndex();
    bool GetLastMouseClickMazeElementIsMazeElement();
    bool GetCurrentMouseOnMazeElementIsMazeElement();

    Vector3 LastMouseClickPosition { get; set; }
    Vector3 GetMousePosition();
    float GetMouseScrollWheel();
}

public class MouseBoundry : MonoBehaviour, IMouse{

    private IMouseLogic mouse;

    private IMouseLogic Mouse { get { return mouse; } }
    public Vector3 LastMouseClickPosition { get; set; }
    public MazeElementBoundary CurrentMouseOnMazeElement { get; set; }
    public MazeElementBoundary LastMouseClickMazeElement { get; set; }

    private void Awake()
    {
        mouse = new Mouse(this);
    }

    public Vector3 GetMousePosition()
    {
        return Input.mousePosition;
    }

    public float GetMouseScrollWheel()
    {
        return Input.GetAxis("Mouse ScrollWheel");
    }

    public bool WasHorizontalMoveInReferenceToLastClick()
    {
        Vector3 currentMousePosition = GetMousePosition();
        return mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);
    }

    public Vector2 GetCurrentMouseOnMazeElementIndex()
    {
        return CurrentMouseOnMazeElement.Index;
    }

    public Vector2 GetLastMouseClickMazeElementIndex()
    {
        try
        {
            return LastMouseClickMazeElement.Index;
        }
        catch (System.NullReferenceException)
        {
            return CurrentMouseOnMazeElement.Index;
        }
    }

    public void UpdateLastMouseClickPosition(Vector3 newLastMouseClickPosition)
    {
        LastMouseClickPosition = newLastMouseClickPosition;
    }

    public bool GetLastMouseClickMazeElementIsMazeElement()
    {
        return LastMouseClickMazeElement.IsMazeWall;
    }

    public bool GetCurrentMouseOnMazeElementIsMazeElement()
    {
        return CurrentMouseOnMazeElement.IsMazeWall;
    }
}
