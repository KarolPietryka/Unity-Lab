using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeRestarterBoundary
{
}
public class MazeRestarterBoundary : MonoBehaviour, IMazeRestarterBoundary
{
    MazeInOutPointsBoundary mazeInOutPoints;
    [SerializeField]
    PlaneBoundry planeBoundry;
    IMazeElementsPathFindParametersRestarter mazeElementsPathFindParametersRestarter;


    public void Awake()
    {
        mazeElementsPathFindParametersRestarter = new MazeRestarter(planeBoundry);
        mazeInOutPoints = GetComponent<MazeInOutPointsBoundary>();


    }

    public void RestartMaze()
    {
        throw new System.NotImplementedException();// TODO deal with it
        mazeElementsPathFindParametersRestarter.RestartMazeElementsParameters();
        mazeInOutPoints.RemoveInOutPoints();
    }


}
