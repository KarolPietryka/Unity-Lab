using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using UnityEngine.UI;
using System;
using NSubstitute;

public class CurrentPathFindDropdownTest {

    [Test]
    public void _1_1_GetSelectedAlgorithm()
    {
        CurrentPathFindDropdown currentPathFindDropdown = new CurrentPathFindDropdown();
        Assert.AreEqual(EPathFindAlgorithms.DijkstraAlgorithm,currentPathFindDropdown.GetSelectedAlgorithm("DijkstraAlgorithm"));
            
    }


}
