using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterInit : MonoBehaviour
{
    public static GameMasterInit instance = null;

    public GameObject MazeElement;
    public GameObject GamePlane;

    public Vector2 minMaxXPositionOfGamePlane;
    public Vector2 minMaxYPositionOfGamePlane;

    public Vector2 minMaxXPositionOfMazeElement;
    public Vector2 minMaxYPositionOfMazeElement;
    private Mouse mouse;

    public readonly IMousePositionProvider mousePositionProvider = new CorrectInputMousePositionProvider();
    public readonly ITimeProvider timeProvider = new CorrectTimeProvider();

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        else if (instance != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        setMinMaxPositionOf(GamePlane, out minMaxXPositionOfGamePlane, out minMaxYPositionOfGamePlane);
        setMinMaxPositionOf(MazeElement, out minMaxXPositionOfMazeElement, out minMaxYPositionOfMazeElement);

        GameMaster.Instance.GamePlane = GamePlane;
        GameMaster.Instance.MazeElement = MazeElement;
        mouse = new Mouse(minMaxXPositionOfMazeElement, minMaxYPositionOfMazeElement, minMaxXPositionOfGamePlane, minMaxYPositionOfGamePlane, mousePositionProvider);
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Buttn Push");
            if (mouse.InInstantiationArea())
            {
                Debug.Log("In area");
                InstantiateMazeElement();
            }
        }
    }

    public GameObject InstantiateMazeElement()
    {
        return Instantiate(MazeElement, mousePositionProvider.GetMousePositionInWorldSpace(), transform.rotation);       
    }

    void setMinMaxPositionOf(GameObject gameObject, out Vector2 minMaxXPosition, out Vector2 minMaxYPosition)
    {
        minMaxXPosition.x = gameObject.transform.Find("Left").transform.position.x;
        minMaxXPosition.y = gameObject.transform.Find("Right").transform.position.x;

        minMaxYPosition.x = gameObject.transform.Find("Bottom").transform.position.y;
        minMaxYPosition.y = gameObject.transform.Find("Top").transform.position.y;
    }

}
