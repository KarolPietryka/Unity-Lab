using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BuildingStatus { Building, Dismantling }
public enum Direction { Left, Up, Right, Down }

public class GameMaster
{
    public IBuildingController buildingController;
    public IInputProvider inputProvider;
    public ITimeProvider timeProvider;
    public IMouse mouse;
    public IPlaneController planeController;

    public void SetBuildingController(IBuildingController _buildingController)
    {
        buildingController = _buildingController;
    }
    public void SetInputProvider(IInputProvider _inputProvider)
    {
        inputProvider = _inputProvider;
    }
    public void SetTimeProvider(ITimeProvider _timeProvider)
    {
        timeProvider = _timeProvider;
    }
    public void SetMouse(IMouse _mouse)
    {
        mouse = _mouse;
    }
    public void SetPlaneController(IPlaneController _planeController)
    {
        planeController = _planeController;
    }


    public void FirstMazeWallConstruct()
    {
        //buildingController.InBuildingProcesss = true;
        buildingController.NextPossibleMazeElementsToProcess = planeController.NextPossibleMazeElementsToProcess(buildingController.BuildingDirection, mouse.CurrentMouseOnMazeElement);
        mouse.UpdateLastMouseClickPosition(inputProvider.GetMousePosition());
        buildingController.SetBuldingStatus(mouse.CurrentMouseOnMazeElement.IsMazeWall);
        mouse.CurrentMouseOnMazeElement.ReverseIsMazeWall();
        mouse.CurrentMouseOnMazeElement.ChangeOnNormalScale();
        mouse.CurrentMouseOnMazeElement.ChangeOnMazeWallColor();
    }

    public void ProcessNextMazeElement()
    {     
     
        if (buildingController.IsCurrentMazeElementLayOnAnyNextMazeElementAxisLine())
        {
            IMazeElement nextMazeElementToProcess = mouse.CurrentMouseOnMazeElement;

            if (nextMazeElementToProcess.PositionInReferenceToCurrentMazeElement == buildingController.BuildingDirection)
            {
                nextMazeElementToProcess.ReverseIsMazeWall();
                nextMazeElementToProcess.ChangeOnMazeWallColor();
                buildingController.NextPossibleMazeElementsToProcess = planeController.NextPossibleMazeElementsToProcess(buildingController.BuildingDirection, mouse.CurrentMouseOnMazeElement);
            }
            else
            {
                //destrowy
            }
        }
        else 
        {
            //destrowy
        }
    }

   


}
