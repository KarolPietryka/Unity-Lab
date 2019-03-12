using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public interface IPathFindDropdown
{
    List<Dropdown.OptionData> GeneratePathFindDropdownList();
    EPathFindAlgorithms GetCurrentSelectPathFindAlgorithm();

}
public class PathFindDropdown : IPathFindDropdown
{
    Dropdown pathFindDropdownUI;
    ICurrentPathFindDropdown currentPathFindDropdown;

    public PathFindDropdown(Dropdown _pathFindDropdownUI, ICurrentPathFindDropdown _currentPathFindDropdown)
    {
        currentPathFindDropdown = _currentPathFindDropdown;
        pathFindDropdownUI = _pathFindDropdownUI;
    }

    public List<Dropdown.OptionData> GeneratePathFindDropdownList()
    {
        return PathFindDropdownListGenerator.GeneratePathFindDropdownList();
    }

    public EPathFindAlgorithms GetCurrentSelectPathFindAlgorithm()
    {
        return currentPathFindDropdown.GetSelectedAlgorithm(pathFindDropdownUI.options[pathFindDropdownUI.value].text);
    }
}
