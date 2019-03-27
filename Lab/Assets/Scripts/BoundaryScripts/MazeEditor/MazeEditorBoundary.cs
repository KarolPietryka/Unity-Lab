using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

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
        Mouse = GameObject.Find("GameMaster").GetComponent<MouseBoundry>();
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
        bool ret = false;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            ret = Input.GetMouseButtonDown(button);
        }
        return ret;
    }
    public bool GetMouseButton(int button)
    {
        bool ret = false;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            return Input.GetMouseButton(button);
        }
        return ret;
    }
    public bool GetMouseButtonUp(int button)
    {
        bool ret = false;
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            return Input.GetMouseButtonUp(button);
        }
        return ret;

    }

    private void Update()
    {
        MazeEditor.Update();
    }
}
