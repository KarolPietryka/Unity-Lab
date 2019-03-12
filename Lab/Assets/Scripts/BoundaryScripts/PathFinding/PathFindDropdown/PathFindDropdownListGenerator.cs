using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public static class PathFindDropdownListGenerator{

    public static List<Dropdown.OptionData> GeneratePathFindDropdownList()
    {
        List<Dropdown.OptionData> pathFindDropdownOptionsList = new List<Dropdown.OptionData>();

        foreach (EPathFindAlgorithms pathFindAlgorithm in Enum.GetValues(typeof(EPathFindAlgorithms)))//in pathFindDropdownBoundary.PathFindAlgorithms)
        {
            Dropdown.OptionData pathFindAlgorithmOption = new Dropdown.OptionData(pathFindAlgorithm.ToString());
            pathFindDropdownOptionsList.Add(pathFindAlgorithmOption);
        }
        return pathFindDropdownOptionsList;
    }
}
