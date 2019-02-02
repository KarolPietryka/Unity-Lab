﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingController : IBuildingController {

    public IMazeElement[] NextPossibleMazeElementsToProcess { get; set; }
   // public bool InBuildingProcesss { get; set; }
    public BuildingStatus BuildingStatus { get; set; }
    public Direction BuildingDirection { get; set; }
    public IInputProvider InputProvider { get; set; }
    public IMouse Mouse { get; set; }

    public void SetBuldingStatus(bool isMazeWall)
    {
        if (isMazeWall == true)
        {
            BuildingStatus = BuildingStatus.Dismantling;
        }
        else
        {
            BuildingStatus = BuildingStatus.Building;
        }
    }
    public void SetInputProvider(IInputProvider _inputProvider)
    {
        InputProvider = _inputProvider;
    }
    public void SetMouse(IMouse _mouse)
    {
        Mouse = _mouse;
    }

    public Direction UpdateBuildingDirection()
    {
        Direction buildingDirection;
        Vector3 currentMousePosition = InputProvider.GetMousePosition();
        Vector3 lastMouseClickPosition = Mouse.LastMouseClickPosition;

        if (InputProvider.WasHorizontalMoveInReferenceToLastClick())
        {
            if (currentMousePosition.x > lastMouseClickPosition.x)
            {
                buildingDirection = Direction.Right;
            }
            else
            {
                buildingDirection = Direction.Left;
            }
        }
        else
        {
            if (currentMousePosition.y > lastMouseClickPosition.y)
            {
                buildingDirection = Direction.Up;
            }
            else
            {
                buildingDirection = Direction.Down;
            }
        }
        return buildingDirection;
    }

    public bool IsCurrentMazeElementLayOnAnyNextMazeElementAxisLine()
    {
        bool ret;

        Vector2[] nextIndexesOfMazeElementsToProcess = new Vector2[2];
        Vector2 currentMouseOnMazeElementIndex = Mouse.CurrentMouseOnMazeElement.Index;
        nextIndexesOfMazeElementsToProcess[0] = NextPossibleMazeElementsToProcess[0].Index;
        nextIndexesOfMazeElementsToProcess[0] = NextPossibleMazeElementsToProcess[1].Index;

        if (InputProvider.WasHorizontalMoveInReferenceToLastClick() && VectorMath.IfAnyVectorHaveEqualXWithVector(nextIndexesOfMazeElementsToProcess, currentMouseOnMazeElementIndex) ||
            !InputProvider.WasHorizontalMoveInReferenceToLastClick() && VectorMath.IfAnyVectorHaveEqualYWithVector(nextIndexesOfMazeElementsToProcess, currentMouseOnMazeElementIndex))
        {
            ret = true;
        }
        else
        {
            ret = false;
        }
        return ret;
    }
               
    public Vector2[] GetNextPossibleMazeElementsToProcessIndexes()
    {
        Vector2[] nextPossibleMazeElementsToProcessIndexes = new Vector2[2];
        nextPossibleMazeElementsToProcessIndexes[0] = NextPossibleMazeElementsToProcess[0].Index;
        nextPossibleMazeElementsToProcessIndexes[1] = NextPossibleMazeElementsToProcess[1].Index;

        return nextPossibleMazeElementsToProcessIndexes;
    }
}