using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeInOutPointsBoundary : MonoBehaviour, IInputMouseButtons, IMazeInOutPoints
{
    private IMouse mouseBoundary;

    private IMazeInOutPoints mazeInOutPoints;

    private void Awake()
    {
        mouseBoundary = transform.parent.GetComponent<MouseBoundry>();
        mazeInOutPoints = new MazeInOutPoints(
            mouseBoundary,
            this,
            new MazeInOutPointsController());
    }

    private void Update()
    {
        SetInOutPoints();
    }
    

    public void SetInOutPoints()
    {
        mazeInOutPoints.SetInOutPoints();

    }

    public void RemoveInOutPoints()
    {
        mazeInOutPoints.RemoveInOutPoints();
    }

    public void SetInOutPointsAt(IMazeElement inPoint, IMazeElement outPoint)
    {
        mazeInOutPoints.SetInOutPointsAt(inPoint, outPoint);
    }

    public bool GetMouseButtonDown(int button)
    {
        return Input.GetMouseButtonDown(button);
    }
    public bool GetMouseButton(int button)
    {
        return Input.GetMouseButton(button);
    }
    public bool GetMouseButtonUp(int button)
    {
        return Input.GetMouseButtonUp(button);
    }
}
