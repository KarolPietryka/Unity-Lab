using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using Moq;
using NSubstitute;

public class MouseTest {

    private IMouse GetMouseBoundryMock(Vector3 lastMouseClickPosition)
    {
        var mouseBoundry = Substitute.For<IMouse>();
        mouseBoundry.LastMouseClickPosition.Returns(lastMouseClickPosition);
        
        return mouseBoundry;
    }
    [Test]
    public void _1_01_WasHorizontalMoveInReferenceToLastClick_BothVectorHaveNegativeXYValues_ReturnTrue()
    {
        Vector3 currentMousePosition = new Vector3(-3, -10, 0);
        Vector3 lastMouseClickPosition = new Vector3(-1, -100, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, false);
    }

    [Test]
    public void _1_02_WasHorizontalMoveInReferenceToLastClick_BothVectorHaveAlternatingXYValues_ReturnFalse()
    {
        Vector3 currentMousePosition = new Vector3(-3, -10, 0);
        Vector3 lastMouseClickPosition = new Vector3(-1, 10, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, false);
    }

    [Test]
    public void _1_03_WasHorizontalMoveInReferenceToLastClick_BothVectorHaveAlternatingXYValues_ReturnFalse()
    {
        Vector3 currentMousePosition = new Vector3(-11, -6, 0);
        Vector3 lastMouseClickPosition = new Vector3(2, 10, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, false);
    }
    
    [Test]
    public void _1_04_WasHorizontalMoveInReferenceToLastClick_VectorHaveAlternatingXYValues_ReturnTrue()
    {
        Vector3 currentMousePosition = new Vector3(-0.01f, 0, 0);
        Vector3 lastMouseClickPosition = new Vector3(0, 0, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, true);
    }

    [Test]
    public void _1_05_WasHorizontalMoveInReferenceToLastClick_VectorHaveAlternatingXYValues_ReturnTrue()
    {
        Vector3 currentMousePosition = new Vector3(3, 0, 0);
        Vector3 lastMouseClickPosition = new Vector3(0, 2, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, true);
    }

    [Test]
    public void _1_06_WasHorizontalMoveInReferenceToLastClick_BothVectorsHavePositiveXYValues_ReturnTrue()
    {
        Vector3 currentMousePosition = new Vector3(10, 3, 0);
        Vector3 lastMouseClickPosition = new Vector3(14, 0, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, true);
    }
    
    [Test]
    public void _1_07_WasHorizontalMoveInReferenceToLastClick_VectorsHaveNegativeXValues_ReturnTrue()
    {
        Vector3 currentMousePosition = new Vector3(-10, 5, 0);
        Vector3 lastMouseClickPosition = new Vector3(-3, 0, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, true);
    }

    [Test]
    public void _1_08_WasHorizontalMoveInReferenceToLastClick_VectorsHaveAlternatingXYValues_ReturnTrue()
    {
        Vector3 currentMousePosition = new Vector3(-10, 5, 0);
        Vector3 lastMouseClickPosition = new Vector3(11, 0, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, true);
    }

    [Test]
    public void _1_09_WasHorizontalMoveInReferenceToLastClick_BothVectorsHavePositiveXYValues_ReturnFalse()
    {
        Vector3 currentMousePosition = new Vector3(10, 5, 0);
        Vector3 lastMouseClickPosition = new Vector3(14, 0, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, false);
    }

    [Test]
    public void _1_10_WasHorizontalMoveInReferenceToLastClick_VectorsHaveNegativeXValues_ReturnFalse()
    {
        Vector3 currentMousePosition = new Vector3(-10, -55, 0);
        Vector3 lastMouseClickPosition = new Vector3(-11, -10, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, false);
    }

    [Test]
    public void _1_11_WasHorizontalMoveInReferenceToLastClick_VectorsHaveNegativeXValues_ReturnFalse()
    {
        Vector3 currentMousePosition = new Vector3(-10, -55, 0);
        Vector3 lastMouseClickPosition = new Vector3(-11, -1000, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, false);
    }

    [Test]
    public void _1_12_WasHorizontalMoveInReferenceToLastClick_VectorsHaveAlternatingXYValues_ReturnTrue()
    {
        Vector3 currentMousePosition = new Vector3(-10, 5, 0);
        Vector3 lastMouseClickPosition = new Vector3(11, -22, 0);

        IMouse mouseBoundry = GetMouseBoundryMock(lastMouseClickPosition);
        var mouse = new Mouse(mouseBoundry);

        bool wasHorizontalMove = mouse.WasHorizontalMoveInReferenceToLastClick(currentMousePosition);

        Assert.AreEqual(wasHorizontalMove, false);
    }
}

