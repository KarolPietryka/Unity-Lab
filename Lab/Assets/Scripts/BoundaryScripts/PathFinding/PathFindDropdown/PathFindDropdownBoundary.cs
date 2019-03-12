using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public interface IPathFindDropdownBoundary
{
    EPathFindAlgorithms GetCurrentSelectPathFindAlgorithm();
}
public class PathFindDropdownBoundary : MonoBehaviour, IPathFindDropdownBoundary{

    private Dropdown pathFindDropdownUI;

    private IPathFindDropdown pathFindDropdown;

    public void Awake()
    {
        pathFindDropdownUI = transform.GetComponent<Dropdown>();

        pathFindDropdown = new PathFindDropdown(
            pathFindDropdownUI,
            new CurrentPathFindDropdown());
    }
    public void Start()
    {
        FillPathFindDropdown();
    }
    private void FillPathFindDropdown()
    {
        List<Dropdown.OptionData> pathFindDropdownOptionsList = pathFindDropdown.GeneratePathFindDropdownList();
        pathFindDropdownUI.AddOptions(pathFindDropdownOptionsList);
    }



    public EPathFindAlgorithms GetCurrentSelectPathFindAlgorithm()
    {
        return pathFindDropdown.GetCurrentSelectPathFindAlgorithm();
    }


}
