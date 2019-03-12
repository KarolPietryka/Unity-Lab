using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public interface ICurrentPathFindDropdown
{
    EPathFindAlgorithms GetSelectedAlgorithm(string pathFindDropdownUIValue);
}

public class CurrentPathFindDropdown : ICurrentPathFindDropdown{


    public EPathFindAlgorithms GetSelectedAlgorithm(string pathFindDropdownUIValue)
    {
        EPathFindAlgorithms pathFindDropdownSelectedAlgorithm;

        if (Enum.TryParse(pathFindDropdownUIValue, true, out pathFindDropdownSelectedAlgorithm))
        {
            return pathFindDropdownSelectedAlgorithm;
        }
        else
        {
            throw new System.InvalidCastException();
        }
    }
}
