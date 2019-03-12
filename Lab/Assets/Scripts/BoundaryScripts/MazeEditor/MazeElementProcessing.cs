using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IMazeElementProcessing
{
    void FirstMazeElementBuildProcess();
    void MazeElementInLineProcessing();
    void MazeElementsFinalProcess();
}
public class MazeElementProcessing : IMazeElementProcessing {

    private IFirstMazeElementProcessing firstMazeElementProcessing;
    private IMazeElementsInLineProcessing mazeElementInLineProcessing;
     

    public MazeElementProcessing(IFirstMazeElementProcessing _firstMazeElementProcessing, IMazeElementsInLineProcessing _mazeElementInLineProcessing)
    {
        firstMazeElementProcessing = _firstMazeElementProcessing;
        mazeElementInLineProcessing = _mazeElementInLineProcessing;
    }

    public void FirstMazeElementBuildProcess()
    {
        firstMazeElementProcessing.Execute();
        mazeElementInLineProcessing.setNewIsMazeWallForRoot(firstMazeElementProcessing.GetIsMazeWallForRootAfterCurrentProcess());
    }
    public void MazeElementInLineProcessing()
    {
        mazeElementInLineProcessing.Execute();
    }
    public void MazeElementsFinalProcess()
    {
        mazeElementInLineProcessing.MazeElementsListFinalProcess();
    }

}
