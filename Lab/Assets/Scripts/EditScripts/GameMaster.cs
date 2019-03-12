using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingStatus { Building, Dismantling }
public enum Direction { Left, Up, Right, Down }

public class GameMaster
{
    public IBuildingController buildingController;
    public IMouse mouse;
    public ITimeProvider timeProvider;
    public IPlaneBuilder planeBuilder;

    public void SetBuildingController(IBuildingController _buildingController)
    {
        buildingController = _buildingController;
    }
    public void SetMouse(IMouse _inputProvider)
    {
        mouse = _inputProvider;
    }
    public void SetTimeProvider(ITimeProvider _timeProvider)
    {
        timeProvider = _timeProvider;
    }

    public void SetPlaneBuilder(IPlaneBuilder _planeBuilder)
    {
        planeBuilder = _planeBuilder;
    }


    public void FirstMazeWallConstruct()
    {
        //buildingController.InBuildingProcesss = true;
        //buildingController.NextPossibleMazeElementsToProcess = planeBuilder.NextPossibleMazeElementsToProcess(buildingController.BuildingDirection, mouse.CurrentMouseOnMazeElement);
        //buildingController.SetBuldingStatus(mouse.CurrentMouseOnMazeElement.IsMazeWall);
    }

    public void ProcessNextMazeElement()
    {     
     /*
        if (buildingController.IsCurrentMazeElementLayOnAnyNextMazeElementAxisLine())
        {
            IMazeElement nextMazeElementToProcess = mouse.CurrentMouseOnMazeElement;

            if (nextMazeElementToProcess.PositionInReferenceToCurrentMazeElement == buildingController.BuildingDirection)
            {
                nextMazeElementToProcess.ReverseIsMazeWall();
                //nextMazeElementToProcess.ChangeOnMazeWallColor();
                buildingController.NextPossibleMazeElementsToProcess = planeBuilder.NextPossibleMazeElementsToProcess(buildingController.BuildingDirection, mouse.CurrentMouseOnMazeElement);
            }
            else
            {
                //destrowy
            }
        }
        else 
        {
            //destrowy
        }*/
    }

   


}
