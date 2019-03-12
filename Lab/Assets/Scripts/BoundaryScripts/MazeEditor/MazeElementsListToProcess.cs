using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeElementsListToProcess
{
    void UpdateMazeElementsToProcessList(Direction processDirection, bool newIsMazeWallForRootMazeElement);
    void ReverseFromToInList(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, Direction processDirection);
    void ChangeMazeElementsInListFromTo(IMouse mouseBoundary, Direction processDirection, bool newIsMazeWallForRootMazeElement);
    void MazeElementsListFinalProcess(bool newIsMazeWallForRootMazeElement);

    List<IMazeElement> MazeElementsToProcess { get; }
}
public class MazeElementsListToProcess : IMazeElementsListToProcess{

    public List<IMazeElement> MazeElementsToProcess{ get; set; }
    IReversalOfMazeElements reversalOfMazeElements;
    IMazeElementsListUpdate mazeElementsListUpdate;
    IChangesOfMazeElements changesOfMazeElements;
    IMazeElementsListFinalProcess mazeElementsListFinalProcess;

    public MazeElementsListToProcess(IMazeElementsListUpdate _mazeElementsListUpdate, 
        IReversalOfMazeElements _reversalOfMazeElements, 
        IChangesOfMazeElements _changesOfMazeElements, 
        IMazeElementsListFinalProcess _mazeElementsListFinalProcess)
    {

        mazeElementsListUpdate = _mazeElementsListUpdate;
        reversalOfMazeElements = _reversalOfMazeElements;
        changesOfMazeElements = _changesOfMazeElements;
        mazeElementsListFinalProcess = _mazeElementsListFinalProcess;
        MazeElementsToProcess = new List<IMazeElement>();
    }

    public void UpdateMazeElementsToProcessList(Direction processDirection, bool newIsMazeWallForRootMazeElement)
    {
        MazeElementsToProcess.Clear();
        mazeElementsListUpdate.UpdateList(MazeElementsToProcess, processDirection, newIsMazeWallForRootMazeElement);
    }

    public void ReverseFromToInList(Vector2 firstMazeElementToReverseIndex, Vector2 lastMazeElementToReverseIndex, Direction processDirection)
    {
        reversalOfMazeElements.ReverseFromToInList(firstMazeElementToReverseIndex, lastMazeElementToReverseIndex, processDirection, MazeElementsToProcess);
    }

    public void ChangeMazeElementsInListFromTo(IMouse mouseBoundary, Direction processDirection, bool newIsMazeWallForRootMazeElement)
    {
        changesOfMazeElements.ChangeMazeElementsInListFromTo(mouseBoundary, processDirection, MazeElementsToProcess, newIsMazeWallForRootMazeElement);
    }

    public void MazeElementsListFinalProcess(bool newIsMazeWallForRootMazeElement)
    {
        mazeElementsListFinalProcess.Execute(MazeElementsToProcess, newIsMazeWallForRootMazeElement);
    }
}
