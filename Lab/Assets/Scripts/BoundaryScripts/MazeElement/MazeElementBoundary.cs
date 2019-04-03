using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeElementPathFindDrawingParameters
{
    void ChangeOnPathFindColor();
    IMazeElement PathFindParent { get; set; }
}
public interface IMazeElementPathFindParameters
{
    bool IsMazeWall { get; set; }
    float PathFindWeight { get; set; }
    float PathFindDistanceHeuristic { get; set; }
    void ResetPathFindingParameters();
}
public interface IMazeElement: IMazeElementPathFindDrawingParameters, IMazeElementPathFindParameters
{
    string Tag { get; set; }
    bool IsElementOfAnotherWall { get; set; }
    Vector2 Index { get; set; }
    void ReverseIsMazeWall();
    void ChangeOnNormalColor();
    void ChangeOnNormalScale();
    void ChangeOnMazeStartPointColor();
    void ChangeOnMazeEndPointColor();

    void DeleteMazeElement();
}

public class MazeElementBoundary : MonoBehaviour, IMazeElement
{
    Color hightlightColor;
    Color whiteColor;
    Color mazeWallColor;
    Color pathFindColor;
    Color mazeStartPointColor;
    Color mazeEndPointColor;
    SpriteRenderer spriteRenderer;

    IPathFindingParameters pathFindingParameters;

    public IMazeElement PathFindParent { get { return pathFindingParameters.PathFindParent; } set { pathFindingParameters.PathFindParent = value; } }
    public float PathFindWeight { get { return pathFindingParameters.Weight; } set { pathFindingParameters.Weight = value; } }
    public float PathFindDistanceHeuristic { get { return pathFindingParameters.DistanceHeuristic; } set { pathFindingParameters.DistanceHeuristic = value; } }
    public bool IsMazeWall { get; set; }
    public bool IsElementOfAnotherWall { get; set; }
    public Vector2 Index { get; set; }
    public string Tag { get { return transform.tag; } set { transform.tag = value; } }

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        hightlightColor = new Color32(152, 152, 152, 255);
        whiteColor = new Color(1, 1, 1, 1);
        mazeWallColor = new Color(0, 0, 0, 1);
        pathFindColor = new Color32(97, 227, 152, 180);
        mazeStartPointColor = new Color32(154, 154, 154, 230);//new Color32(85, 197, 234, 230);
        mazeEndPointColor = new Color32(154, 154, 154, 230);//new Color32(251, 170, 182, 230);

        pathFindingParameters = new PathFindParameters();
    }

    private void OnMouseOver()//holding button
    {
        if (Input.GetMouseButton(0))
        {
            GameMasterBoundary.instance.Mouse.CurrentMouseOnMazeElement = this;
        }
    }
    private void OnMouseEnter()
    {
        if (!Input.GetMouseButton(0) && !this.IsElementOfAnotherWall)
        {
            if (transform.tag == "MazeElement")
            {
                ChangeOnHightlightColor();
                ChangeOnHightlightScale();
                GameMasterBoundary.instance.Mouse.CurrentMouseOnMazeElement = this;
            }
            else if (transform.tag == "PathFindStartNode" || transform.tag == "PathFindDestinationNode")
                GameMasterBoundary.instance.Mouse.CurrentMouseOnMazeElement = this;

        }
    }
    private void OnMouseExit()
    {
        if (!Input.GetMouseButton(0) && !this.IsElementOfAnotherWall && transform.tag == "MazeElement")
        {
            ChangeOnNormalColor();
            ChangeOnNormalScale();
            // GameMasterBoundary.instance.Mouse.CurrentMouseOnMazeElement = null;
        }
    }

    public void ReverseIsMazeWall()
    {
        IsMazeWall = !IsMazeWall;
        if (IsMazeWall)
        {
            ChangeOnMazeWallColor();
        }
        else
        {
            ChangeOnNormalColor();
        }
    }

    public void ResetPathFindingParameters()
    {
        pathFindingParameters.ResetPathFindingParameters();
    }


    public void ChangeOnMazeStartPointColor()
    {
        spriteRenderer.color = mazeStartPointColor;
    }
    public void ChangeOnMazeEndPointColor()
    {
        spriteRenderer.color = mazeEndPointColor;
    }
    public void ChangeOnHightlightColor()
    {
        spriteRenderer.color = hightlightColor;
    }
    public void ChangeOnPathFindColor()
    {
        spriteRenderer.color = pathFindColor;
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
    public void DeleteMazeElement()
    {
        DestroyImmediate(gameObject);
    }
}

