using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse
{
    //private readonly IMousePositionProvider mousePosition;//?
    private Vector2 minMaxXPositionOfGamePlane;
    private Vector2 minMaxYPositionOfGamePlane;

    private Vector2 minMaxXPositionOfMazeElement;
    private Vector2 minMaxYPositionOfMazeElement;

    private IMousePositionProvider mousePositionProvider;

    float halfOfXLenghtMazeElement;
    float halfOfYLenghtMazeElement;

    float xLenghtOfGamePlane;
    float yLenghtOfGamePlane;

    public Mouse(Vector2 _minMaxXPositionOfMazeElement, 
        Vector2 _minMaxYPositionOfMazeElement,
        Vector2 _minMaxXPositionOfGamePlane,
        Vector2 _minMaxYPositionOfGamePlane, 
        IMousePositionProvider _mousePositionProvider)
    {
        minMaxXPositionOfMazeElement = _minMaxXPositionOfMazeElement;
        minMaxYPositionOfMazeElement = _minMaxYPositionOfMazeElement;
        minMaxXPositionOfGamePlane = _minMaxXPositionOfGamePlane;
        minMaxYPositionOfGamePlane = _minMaxYPositionOfGamePlane;

        mousePositionProvider = _mousePositionProvider;

        halfOfXLenghtMazeElement = (Mathf.Abs(minMaxXPositionOfMazeElement.x) + Mathf.Abs(minMaxXPositionOfMazeElement.y)) / 2;
        halfOfYLenghtMazeElement = (Mathf.Abs(minMaxYPositionOfMazeElement.x) + Mathf.Abs(minMaxYPositionOfMazeElement.y)) / 2;
        Debug.Log(minMaxYPositionOfMazeElement.x);
        Debug.Log(minMaxYPositionOfMazeElement.y);

        xLenghtOfGamePlane = Mathf.Abs(minMaxXPositionOfGamePlane.x) + Mathf.Abs(minMaxXPositionOfGamePlane.y);
        yLenghtOfGamePlane = Mathf.Abs(minMaxYPositionOfGamePlane.x) + Mathf.Abs(minMaxYPositionOfGamePlane.y);
    }



    public bool InInstantiationArea()
    {
        Vector2 mousePositionInWorldSpace = mousePositionProvider.GetMousePositionInWorldSpace();

        Bounds bounds = new Bounds(new Vector3(0, 0, 0), new Vector3(xLenghtOfGamePlane - 2 * halfOfXLenghtMazeElement, yLenghtOfGamePlane - 2 * halfOfYLenghtMazeElement, 2));
        Debug.Log(bounds);
        //Debug.Log(mousePositionInWorldSpace);
        if (bounds.Contains(mousePositionInWorldSpace))
        {
            return true;
        }
        return false;
    }

}

