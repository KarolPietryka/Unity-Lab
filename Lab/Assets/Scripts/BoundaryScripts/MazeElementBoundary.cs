using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeElementBoundary : MonoBehaviour, IMazeElement
{
    Color hightlightColor;
    Color whiteColor;
    Color mazeWallColor;
    SpriteRenderer spriteRenderer;

    public Direction PositionInReferenceToCurrentMazeElement { get; set; }

    public bool IsMazeWall { get; set; }
    public Vector2 Index { get; set; }

    void Start ()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hightlightColor = new Color32(152, 152, 152, 255);
        whiteColor = new Color(1, 1, 1, 1);
        mazeWallColor = new Color(0, 0, 0, 1);

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            GameMasterBoundary.instance.Mouse.CurrentMouseOnMazeElement = this;
        }
    }
    private void OnMouseEnter()
    {
        if (IsMazeWall != true && GameMasterBoundary.instance.InBuildingProcesss != true)
        {
            ChangeOnHightlightColor();
            ChangeOnHightlightScale();
            GameMasterBoundary.instance.Mouse.CurrentMouseOnMazeElement = this;
        }
    }
    private void OnMouseExit()
    {
        if (IsMazeWall != true && GameMasterBoundary.instance.InBuildingProcesss != true)
        {
            ChangeOnNormalColor();
            ChangeOnNormalScale();
            GameMasterBoundary.instance.Mouse.CurrentMouseOnMazeElement = null;
        }
    }

    public void ReverseIsMazeWall()
    {
        IsMazeWall = !IsMazeWall;
    }
    public void ChangeOnHightlightColor()
    { 
        spriteRenderer.color = hightlightColor;
    }
    public void ChangeOnNormalColor()
    { 
        spriteRenderer.color = whiteColor;
    }
    public void ChangeOnMazeWallColor()
    {
        spriteRenderer.color = mazeWallColor;
    }
    public void ChangeOnHightlightScale()
    {
        transform.localScale = new Vector4(1.3f, 1.3f, 1f, 1f);
    }
    public void ChangeOnNormalScale()
    {
        transform.localScale = new Vector4(1f, 1f, 1f, 1f);
    }

}

