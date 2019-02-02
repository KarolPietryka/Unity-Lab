using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputProvider : MonoBehaviour {

    IInputProvider inputPrivider;
    IMouse mouse;

    public void SetInputProvider(IInputProvider _inputProvider)
    {
        inputPrivider = _inputProvider;
    }

    public void SetIMouse(IMouse _mouse)
    {
        mouse = _mouse;
    }

}
