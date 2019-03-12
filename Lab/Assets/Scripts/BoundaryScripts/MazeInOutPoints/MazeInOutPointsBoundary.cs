using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeInOutPointsBoundary : MonoBehaviour, IInputMouseButtons
{
    private IMouse mouseBoundary;

    private IMazeInOutPoints mazeInOutPoints;

    private void Awake()
    {
        mouseBoundary = transform.parent.GetComponent<MouseBoundry>();
        mazeInOutPoints = new MazeInOutPoints(
            mouseBoundary,
            this);
    }

    private void Update()
    {
        mazeInOutPoints.SetInOutPoints();
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
