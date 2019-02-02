using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class NextPossibleMazeElementsProviderTest {

    private IPlaneController getPlaneControllerMock(Direction buildingDirection, Vector2 currentMouseOnMazeElementIndex, IMazeElement leftOrUpMazeElement, IMazeElement rightOrDownMazeElement)
    {
        var planeController = Substitute.For<IPlaneController>();
        if (buildingDirection == Direction.Left || buildingDirection == Direction.Right)
        {
            planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x - 1, (int)currentMouseOnMazeElementIndex.y).Returns(leftOrUpMazeElement);
            planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x + 1, (int)currentMouseOnMazeElementIndex.y).Returns(rightOrDownMazeElement);
        }
        else if (buildingDirection == Direction.Up || buildingDirection == Direction.Down)
        {
            planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y - 1).Returns(leftOrUpMazeElement);
            planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x, (int)currentMouseOnMazeElementIndex.y + 1).Returns(rightOrDownMazeElement);
        }

        return planeController;
    }

    private IMazeElement getMazeElementMock(Vector2 mazeElementIndex)
    {
        var currentMouseOnMazeElement = Substitute.For<IMazeElement>();
        currentMouseOnMazeElement.Index.Returns(mazeElementIndex);

        return currentMouseOnMazeElement;
    }

    #region NextPossibleMazeElementsToProcess
    [Test]
    public void _9_1_NextPossibleMazeElementsToProcess_ReturnsBothDirectionsMazeElementsIndexes()
    {
        Vector2 currentMouseOnMazeElementIndex = new Vector2(1, 1);
        var buildingDirection = Direction.Left;

        var leftMazeElement = getMazeElementMock(new Vector2(0, 1));
        var rightMazeElement = getMazeElementMock(new Vector2(2, 1));
        var currentMouseOnMazeElement = getMazeElementMock(currentMouseOnMazeElementIndex);
        var planeController = getPlaneControllerMock(buildingDirection, currentMouseOnMazeElementIndex, leftMazeElement, rightMazeElement);

        var nexePossibleMazeElementsProvider = Substitute.For<NextPossibleMazeElementsProvider>();

        nexePossibleMazeElementsProvider.SetPlaneController(planeController);    

        IMazeElement[] nextPossibleMazeElementsToProcess = nexePossibleMazeElementsProvider.GetNextPossibleMazeElementsToProcess(buildingDirection, currentMouseOnMazeElement);

        Assert.AreEqual(nextPossibleMazeElementsToProcess[0].Index, leftMazeElement.Index);
        Assert.AreEqual(nextPossibleMazeElementsToProcess[1].Index, rightMazeElement.Index);
    }

    [Test]
    public void _9_2_NextPossibleMazeElementsToProcess_ReturnsBothDirectionsMazeElementsIndexes()
    {
        Vector2 currentMouseOnMazeElementIndex = new Vector2(5, 2);
        var buildingDirection = Direction.Left;

        var leftMazeElement = getMazeElementMock(new Vector2(6, 2));
        var rightMazeElement = getMazeElementMock(new Vector2(4, 2));
        var currentMouseOnMazeElement = getMazeElementMock(currentMouseOnMazeElementIndex);
        var planeController = getPlaneControllerMock(buildingDirection, currentMouseOnMazeElementIndex, leftMazeElement, rightMazeElement);

        var nexePossibleMazeElementsProvider = Substitute.For<NextPossibleMazeElementsProvider>();

        nexePossibleMazeElementsProvider.SetPlaneController(planeController);

        IMazeElement[] nextPossibleMazeElementsToProcess = nexePossibleMazeElementsProvider.GetNextPossibleMazeElementsToProcess(buildingDirection, currentMouseOnMazeElement);

        Assert.AreEqual(nextPossibleMazeElementsToProcess[0].Index, leftMazeElement.Index);
        Assert.AreEqual(nextPossibleMazeElementsToProcess[1].Index, rightMazeElement.Index);
    }

    [Test]
    public void _9_3_NextPossibleMazeElementsToProcess_ReturnsBothDirectionsMazeElementsIndexes()
    {
        Vector2 currentMouseOnMazeElementIndex = new Vector2(1, 4);
        var buildingDirection = Direction.Left;

        var leftMazeElement = getMazeElementMock(new Vector2(-6, -7));
        var rightMazeElement = getMazeElementMock(new Vector2(-4, -7));
        var currentMouseOnMazeElement = getMazeElementMock(currentMouseOnMazeElementIndex);
        var planeController = getPlaneControllerMock(buildingDirection, currentMouseOnMazeElementIndex, leftMazeElement, rightMazeElement);

        var nexePossibleMazeElementsProvider = Substitute.For<NextPossibleMazeElementsProvider>();

        nexePossibleMazeElementsProvider.SetPlaneController(planeController);

        IMazeElement[] nextPossibleMazeElementsToProcess = nexePossibleMazeElementsProvider.GetNextPossibleMazeElementsToProcess(buildingDirection, currentMouseOnMazeElement);

        Assert.AreEqual(nextPossibleMazeElementsToProcess[0].Index, leftMazeElement.Index);
        Assert.AreEqual(nextPossibleMazeElementsToProcess[1].Index, rightMazeElement.Index);
    }

    [Test]
    public void _9_4_NextPossibleMazeElementsToProcess_ReturnsBothDirectionsMazeElementsIndexes()
    {
        Vector2 currentMouseOnMazeElementIndex = new Vector2(1, 4);
        var buildingDirection = Direction.Up;

        var upMazeElement = getMazeElementMock(new Vector2(-6, -1));
        var downMazeElement = getMazeElementMock(new Vector2(-6, -3));
        var currentMouseOnMazeElement = getMazeElementMock(currentMouseOnMazeElementIndex);
        var planeController = getPlaneControllerMock(buildingDirection, currentMouseOnMazeElementIndex, upMazeElement, downMazeElement);

        var nexePossibleMazeElementsProvider = Substitute.For<NextPossibleMazeElementsProvider>();

        nexePossibleMazeElementsProvider.SetPlaneController(planeController);

        IMazeElement[] nextPossibleMazeElementsToProcess = nexePossibleMazeElementsProvider.GetNextPossibleMazeElementsToProcess(buildingDirection, currentMouseOnMazeElement);

        Assert.AreEqual(nextPossibleMazeElementsToProcess[0].Index, upMazeElement.Index);
        Assert.AreEqual(nextPossibleMazeElementsToProcess[1].Index, downMazeElement.Index);
    }
    #endregion
}
