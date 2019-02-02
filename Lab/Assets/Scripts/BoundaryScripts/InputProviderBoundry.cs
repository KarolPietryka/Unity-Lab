using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProviderBoundry : MonoBehaviour, IInputProvider {

    private Mouse mouse;

    private void Awake()
    {
        mouse = new Mouse();
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
}
