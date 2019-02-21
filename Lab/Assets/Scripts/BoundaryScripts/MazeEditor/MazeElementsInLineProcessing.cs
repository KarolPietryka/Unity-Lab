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

    IMouse mouse;
    float mazeElementsInLineUpdateOffset = 0.5f;
    IFarthestMazeElement farthestMazeEleFromLastMouseClickMazeEle;
    IProcessDirectionUpdate processDirectionUpdate;

    IMazeElementsList mazeElementsListToProcess;

    bool newIsMazeWallForRootMazeElement;

    public void setNewIsMazeWallForRoot(bool newIsMazeWall)
    {
        newIsMazeWallForRootMazeElement = newIsMazeWall;
    }

    public MazeElementsInLineProcessing(IProcessDirectionUpdate _processDirectionUpdate, IFarthestMazeElement _farthestMazeEleFromLastMouseClickMazeEle, IMouse _mouse, IMazeElementsList _mazeElementsListToProcess)
    {
        mouse = _mouse;
        processDirectionUpdate = _processDirectionUpdate;
        farthestMazeEleFromLastMouseClickMazeEle = _farthestMazeEleFromLastMouseClickMazeEle;
        mazeElementsListToProcess = _mazeElementsListToProcess;
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
                mazeElementsListToProcess.MazeElementsToProcess.Clear();
            }
 
            farthestMazeEleFromLastMouseClickMazeEle.UpdateIfCurrentMazeEleIsGreater(processDirection);
            if (DidCurrentMazeEleRewound(processDirection))
            {
                mazeElementsListToProcess.ReverseFromToInList(mouse.GetCurrentMouseOnMazeElementIndex(), farthestMazeEleFromLastMouseClickMazeEle.CurrentFarthestMazeElementIndex, processDirection);
                farthestMazeEleFromLastMouseClickMazeEle.CurrentFarthestMazeElementIndex = mouse.GetCurrentMouseOnMazeElementIndex();
            }

            mazeElementsListToProcess.UpdateMazeElementsToProcessList(processDirection, newIsMazeWallForRootMazeElement);
            mazeElementsListToProcess.ChangeMazeElementsInListFromTo(mouse, processDirection, newIsMazeWallForRootMazeElement);
            
            //mazeElementsListProcessing.ProcessFromLastMouseClickMazeElementToCurrentMazeElement(farthestMazeEleFromLastMouseClickMazeEle);
        }
    }

    public bool DidCurrentMazeEleRewound(Direction processDirection)
    {
        return ! ProjectionOfVectors.isProjectionOfCurrentMazeEleEqualToFarthestMazeEle(farthestMazeEleFromLastMouseClickMazeEle, mouse, processDirection);
    }

    public void MazeElementsListFinalProcess()
    {
        mazeElementsListToProcess.MazeElementsListFinalProcess(newIsMazeWallForRootMazeElement);
    }

}
