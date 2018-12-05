using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovementInit : MonoBehaviour{


    private CameraMovement mouseMovement;

    public float offset;
    public float speed;
    //x - min y - max
    private Vector2 minMaxXPosition;
    private Vector2 minMaxYPosition;
    private float screenWidth;
    private float screenHeight;
    private Vector3 cameraMove;

    void Start()
    {
        screenWidth = Screen.width;
        screenHeight = Screen.height;
        cameraMove.x = transform.position.x;
        cameraMove.y = transform.position.y;
        cameraMove.z = transform.position.z;

        //setminMaxXandYPosition();//TODO: change name

        mouseMovement = new CameraMovement(screenWidth, screenHeight, GameMasterInit.instance.mousePositionProvider, GameMasterInit.instance.timeProvider);
    }

    void Update()
    {
        transform.position = mouseMovement.Movement(offset, speed, GameMasterInit.instance.minMaxXPositionOfGamePlane, GameMasterInit.instance.minMaxYPositionOfGamePlane, transform.position);
    }

    float MoveSpeed()
    {
        return speed * Time.deltaTime;
    }

    /*void setminMaxXandYPosition()
    {
        minMaxXPosition.x = GameMasterInit.instance.GamePlane.transform.Find("Left").transform.position.x;
        minMaxXPosition.y = GameMasterInit.instance.GamePlane.transform.Find("Right").transform.position.x;

        minMaxYPosition.x = GameMasterInit.instance.GamePlane.transform.Find("Bottom").transform.position.y;
        minMaxYPosition.y = GameMasterInit.instance.GamePlane.transform.Find("Top").transform.position.y;
    }*/
}





