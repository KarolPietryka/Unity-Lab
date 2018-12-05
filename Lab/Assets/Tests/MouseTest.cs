using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class MouseTest {


    Vector2 minMaxXPositionOfGamePlane = new Vector2(-100, 100);
    Vector2 minMaxYPositionOfGamePlane = new Vector2(-100, 100);
   

    [TestCase(0, 0, 0)]
    [TestCase(29, -82, 0)]
    [TestCase(95, -95, 0)]
    [TestCase(-94, -91, 0)]
    public void _1_InInstantiationArea_ReturnTrue(int mousePositionX, int mousePositionY, int mousePositionZ)
    {
        Vector2 minMaxXPositionOfMazeElement = new Vector2(-10, 10);// x = {-95, 95} y = {-95, 95} squere dimensionsa

        Vector2 minMaxYPositionOfMazeElement = new Vector2(-10, 10);

        Mouse mouse = new Mouse(minMaxXPositionOfMazeElement,
            minMaxYPositionOfMazeElement, 
            minMaxXPositionOfGamePlane, 
            minMaxYPositionOfGamePlane, 
            new FakeInputMousePositionProvider(new Vector3(mousePositionX, mousePositionY, mousePositionZ)));

        bool inInstantiationArea = mouse.InInstantiationArea();

        Assert.AreEqual(inInstantiationArea, true);
    }


    [TestCase(-96, 0, 0)]
    [TestCase(0, 96, 0)]
    [TestCase(95, -96, 0)]
    [TestCase(-100, 100, 0)]
    public void _2_InInstantiationArea_ReturnFalse(int mousePositionX, int mousePositionY, int mousePositionZ)
    {
        Vector2 minMaxXPositionOfMazeElement = new Vector2(-10, 10);// x = {-95, 95} y = {-95, 95} squere dimensionsa

        Vector2 minMaxYPositionOfMazeElement = new Vector2(-10, 10);

        Mouse mouse = new Mouse(minMaxXPositionOfMazeElement,
            minMaxYPositionOfMazeElement,
            minMaxXPositionOfGamePlane,
            minMaxYPositionOfGamePlane,
            new FakeInputMousePositionProvider(new Vector3(mousePositionX, mousePositionY, mousePositionZ)));

        bool inInstantiationArea = mouse.InInstantiationArea();

        Assert.AreEqual(inInstantiationArea, false);
    }
}

