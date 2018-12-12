using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MouseTest {

    float mouseUpperScrollLimit = 200;

    Bounds gamePlaneBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(100, 100, 1));
    Bounds mazeElementBounds = new Bounds(new Vector3(0, 0, 0), new Vector3(15, 10, 1));


    [TestCase(0, 0, 0)]
    [TestCase(29, -32, 0)]
    [TestCase(42.5f, -45f, 100)]
    [TestCase(42.5f, 42.5f, 0)]
    [TestCase(42.5f, 42.5f, 40)]
    public void _1_InInstantiationArea_ReturnTrue(float mousePositionX, float mousePositionY, float mousePositionZ)
    {
        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(new Vector3(mousePositionX, mousePositionY, mousePositionZ));
        Mouse mouse = new Mouse(mousePositionProvider, gamePlaneBounds, mazeElementBounds, mouseUpperScrollLimit);

        bool inInstantiationArea = mouse.InInstantiationArea();

        Assert.AreEqual(inInstantiationArea, true);
    }


    [TestCase(-96, 0, 0)]
    [TestCase(0, 96, 0)]
    [TestCase(95, -96, 0)]
    [TestCase(-100, 100, 0)]
    [TestCase(-42.6f, -45.001f, 0)]
    [TestCase(45.5f, 42.5f, 40)]
    public void _2_InInstantiationArea_ReturnFalse(float mousePositionX, float mousePositionY, float mousePositionZ)
    {
        IMousePositionProvider mousePositionProvider = new FakeInputMousePositionProvider(new Vector3(mousePositionX, mousePositionY, mousePositionZ));
        Mouse mouse = new Mouse(mousePositionProvider, gamePlaneBounds, mazeElementBounds, mouseUpperScrollLimit);

        bool inInstantiationArea = mouse.InInstantiationArea();

        Assert.AreEqual(inInstantiationArea, false);
    }
    
}

