using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeElementsInLineProcessing
{
    void Execute();
    void MazeElementsListFinalProcess();
    void setNewIsMazeWallForRoot(bool newIsMazeWallForRootMazeElement);
}
public class MazeElementsInLineProcessing : IMazeElementsInLineProcessing{

    float mazeElementsInLineUpdateOffset = 0.5f;
    bool newIsMazeWallForRootMazeElement;

    IMouse mouse;
    IFarthestMazeElement farthestMazeEleFromLastMouseClickMazeEle;
    IMazeElementsListToProcess mazeElementsListToProcess;

    IProcessDirectionUpdate processDirectionUpdate;

    public MazeElementsInLineProcessing(IProcessDirectionUpdate _processDirectionUpdate, IFarthestMazeElement _farthestMazeEleFromLastMouseClickMazeEle, IMouse _mouse, IMazeElementsListToProcess _mazeElementsListToProcess)
    {
        mouse = _mouse;
        processDirectionUpdate = _processDirectionUpdate;
        farthestMazeEleFromLastMouseClickMazeEle = _farthestMazeEleFromLastMouseClickMazeEle;
        mazeElementsListToProcess = _mazeElementsListToProcess;
    }

    public void setNewIsMazeWallForRoot(bool newIsMazeWall)
    {
        newIsMazeWallForRootMazeElement = newIsMazeWall;
    }

    public void Execute()
    {
        mazeElementsInLineUpdateOffset -= Time.deltaTime;
        if (mazeElementsInLineUpdateOffset <= 0)
        {
            mazeElementsInLineUpdateOffset = 0.5f;

            Direction processDirection = processDirectionUpdate.ExecuteUpdate();
            if (processDirectionUpdate.WasProcessDirectionChange())
            {
                mazeElementsListToProcess.ReverseFromToInList(mouse.GetLastMouseClickMazeElementIndex(), farthestMazeEleFromLastMouseClickMazeEle.CurrentFarthestMazeElementIndex, processDirectionUpdate.GetLastCheckDirection());
            }

            farthestMazeEleFromLastMouseClickMazeEle.UpdateIfCurrentMazeEleIsGreater(processDirection);

            if (DidCurrentMazeEleRewound(processDirection))
            {
                RewoundProcess(processDirection);
            }

            ProgressProcess(processDirection);
        }
    }


    private bool DidCurrentMazeEleRewound(Direction processDirection)
    {
        return ! ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeEleFromLastMouseClickMazeEle, mouse, processDirection);
    }

    public void MazeElementsListFinalProcess()
    {
        mazeElementsListToProcess.MazeElementsListFinalProcess(newIsMazeWallForRootMazeElement);
    }

    private void RewoundProcess(Direction processDirection)
    {
        mazeElementsListToProcess.ReverseFromToInList(mouse.GetCurrentMouseOnMazeElementIndex(), farthestMazeEleFromLastMouseClickMazeEle.CurrentFarthestMazeElementIndex, processDirection);
        farthestMazeEleFromLastMouseClickMazeEle.CurrentFarthestMazeElementIndex = mouse.GetCurrentMouseOnMazeElementIndex();
    }

    private void ProgressProcess(Direction processDirection)
    {
        mazeElementsListToProcess.UpdateMazeElementsToProcessList(processDirection, newIsMazeWallForRootMazeElement);
        mazeElementsListToProcess.ChangeMazeElementsInListFromTo(mouse, processDirection, newIsMazeWallForRootMazeElement);
    }
}
