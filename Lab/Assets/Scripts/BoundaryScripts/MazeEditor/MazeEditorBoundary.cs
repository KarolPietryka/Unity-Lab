using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IInputMouseButtons
{
    bool GetMouseButtonDown(int button);
    bool GetMouseButton(int button);
    bool GetMouseButtonUp(int button);

}
public class MazeEditorBoundary : MonoBehaviour, IInputMouseButtons {

    private IMouse Mouse;
    private IPlaneBuilder planeBuilder;
    private IMazeEditor MazeEditor;


    public void Awake()
    {
        Mouse = GetComponent<MouseBoundry>();
        planeBuilder = GameObject.Find("Plane").GetComponent<PlaneBoundry>();


        MazeEditor = new MazeEditor(
                        new MazeElementProcessing(
                            new FirstMazeElementProcessing(Mouse),
                            new MazeElementsInLineProcessing(
                                new ProcessDirectionUpdate(Mouse),
                                new FarthestMazeElementFromLastMouseClickMazeElement(Mouse),
                                Mouse,
                                new MazeElementsListToProcess(
                                    new MazeElementsListUpdate(Mouse,
                                        planeBuilder),
                                    new ReversalOfMazeElements(),
                                    new ChangesOfMazeElements(),
                                    new MazeElementsListFinalProcess()))),
                        Mouse,
                        this);
            

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

    private void Update()
    {
        MazeEditor.Update();
    }
}
