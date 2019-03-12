using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IOpenCloseListController
{
    void AddToOpenList(IMazeElement mazeElement);
    void AddToCloseList(IMazeElement mazeElement);
    int OpenListCount();
    IMazeElement GetMazeElementWithLowestWeight();
    void RemoveFirstElementFromOpenList(IMazeElement mazeElement);
    bool CloseListContains(IMazeElement mazeElement);
    bool OpenListContains(IMazeElement mazeElement);


}
public class OpenCloseListController : IOpenCloseListController
{
    List<IMazeElement> openList;
    List<IMazeElement> closeList;

    public OpenCloseListController(List<IMazeElement> _openList, List<IMazeElement> _closeList)
    {
        openList = _openList;
        closeList = _closeList;
    }

    public void AddToOpenList(IMazeElement mazeElement)
    {
        openList.Add(mazeElement);
    }
    public void AddToCloseList(IMazeElement mazeElement)
    {
        closeList.Add(mazeElement);
    }
    public int OpenListCount()
    {
        return openList.Count;
    }
    public IMazeElement GetMazeElementWithLowestWeight()
    {
        SortOpenList();
        return openList[0];
    }
    public void RemoveFirstElementFromOpenList(IMazeElement mazeElement)
    {
        //Debug.Log(openList[0]);
        openList.Remove(mazeElement);//openList[0]);
    }
    public bool CloseListContains(IMazeElement mazeElement)
    {
        return closeList.Contains(mazeElement);
    }
    public bool OpenListContains(IMazeElement mazeElement)
    {
        return openList.Contains(mazeElement);
    }


    private void SortOpenList()
    {
        openList.Sort((x, y) => (x.PathFindWeight + x.PathFindDistanceHeuristic).CompareTo((y.PathFindWeight + y.PathFindDistanceHeuristic)));
    }
}
