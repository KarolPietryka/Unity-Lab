using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneBoundry : MonoBehaviour {

    public float MazeElementGapBetween;

    private Bounds GamePlaneBound;
    private Bounds MazeElementBound;
    private Plane gamePlane;

    void Start ()
    {
        GamePlaneBound = GameMasterBoundary.instance.GamePlaneBounds;
        MazeElementBound = GameMasterBoundary.instance.MazeElementBounds;
        gamePlane = new Plane(GamePlaneBound, MazeElementBound, MazeElementGapBetween);

        CreateGamePlaneInScene();
    }

    void CreateGamePlaneInScene()
    {
        
    }
    void Update () {
		
	}
}
