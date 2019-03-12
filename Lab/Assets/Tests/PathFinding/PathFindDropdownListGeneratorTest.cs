using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class PathFindDropdownListGeneratorTest {

    [Test]
    public void _1_1_GeneratePathFindDropdownList()
    { 
        List<Dropdown.OptionData> pathFindDropdownOptionsList = PathFindDropdownListGenerator.GeneratePathFindDropdownList();

        int counter = 0;
        foreach (EPathFindAlgorithms pathFindAlgorithm in Enum.GetValues(typeof(EPathFindAlgorithms)))
        {
            Assert.AreEqual(pathFindDropdownOptionsList[counter].text, pathFindAlgorithm.ToString());
            counter++;
        }
}
}
