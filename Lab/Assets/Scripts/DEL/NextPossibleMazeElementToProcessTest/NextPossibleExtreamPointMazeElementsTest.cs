/*using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class NextPossibleExtreamPointMazeElementsTest {

    private IPlaneBuilder getPlaneControllerMock(
        Vector2 intagerNumberOfMazeElementsOnXAndY,
        Direction buildingDirection, 
        Vector2 currentMouseOnMazeElementIndex, 
        IMazeElement leftOrUpMazeElement, 
        IMazeElement rightOrDownMazeElement)
    {
        var planeController = Substitute.For<IPlaneBuilder>();
        planeController.IntagerNumberOfMazeElementsOnXAndY = intagerNumberOfMazeElementsOnXAndY;
        if (buildingDirection == Direction.Left || buildingDirection == Direction.Right)
        {
            if (currentMouseOnMazeElementIndex.x == 0)
            {
                planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x - 1, (int)currentMouseOnMazeElementIndex.y).Returns(x => { throw new System.IndexOutOfRangeException(); });
                planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x + 1, (int)currentMouseOnMazeElementIndex.y).Returns(rightOrDownMazeElement);
            }
            else if (currentMouseOnMazeElementIndex.x == intagerNumberOfMazeElementsOnXAndY.x)
            {
                planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x - 1, (int)currentMouseOnMazeElementIndex.y).Returns(leftOrUpMazeElement);
                planeController.GetFromMazeArray((int)currentMouseOnMazeElementIndex.x + 1, (int)currentMouseOnMazeElementIndex.y).Returns(x => { throw new System.IndexOutOfRangeException(); });
            }
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

    #region 1_NextPossibleExtreamPointMazeElementsTest
    [Test]
    public void _1_1_GetNextRegularPossibleMazeElementsToProcess_HorizontalDirection_ReturnsBothDirectionsMazeElementsIndexes()
    {
        Vector2 currentMouseOnMazeElementIndex = new Vector2(0, 1);
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(10, 10);
        var buildingDirection = Direction.Left;
        var leftMazeElement = getMazeElementMock(new Vector2(0, 1));
        var rightMazeElement = getMazeElementMock(new Vector2(1, 1));
        var currentMouseOnMazeElement = getMazeElementMock(currentMouseOnMazeElementIndex);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY, buildingDirection, currentMouseOnMazeElementIndex, leftMazeElement, rightMazeElement);

        var nextPossibleExtreamPointMazeElements = Substitute.For<NextPossibleExtreamPointMazeElements>(currentMouseOnMazeElementIndex, buildingDirection, planeController);
        IMazeElement[] nextPossibleMazeElementsToProcess = nextPossibleExtreamPointMazeElements.NextPossibleMazeElementsToProcessForExtremePoints();
        Assert.AreEqual(nextPossibleMazeElementsToProcess[0].Index, nextPossibleMazeElementsToProcess[1].Index);
    }
    [Test]
    public void _1_2_GetNextRegularPossibleMazeElementsToProcess_HorizontalDirection_ReturnsBothDirectionsMazeElementsIndexes()
    {
        Vector2 currentMouseOnMazeElementIndex = new Vector2(10, 1);
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(10, 10);
        var buildingDirection = Direction.Left;
        var leftMazeElement = getMazeElementMock(new Vector2(9, 1));
        var rightMazeElement = getMazeElementMock(new Vector2(10, 1));
        var currentMouseOnMazeElement = getMazeElementMock(currentMouseOnMazeElementIndex);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY, buildingDirection, currentMouseOnMazeElementIndex, leftMazeElement, rightMazeElement);

        var nextPossibleExtreamPointMazeElements = Substitute.For<NextPossibleExtreamPointMazeElements>(currentMouseOnMazeElementIndex, buildingDirection, planeController);
        IMazeElement[] nextPossibleMazeElementsToProcess = nextPossibleExtreamPointMazeElements.NextPossibleMazeElementsToProcessForExtremePoints();
        Assert.AreEqual(nextPossibleMazeElementsToProcess[0].Index, nextPossibleMazeElementsToProcess[1].Index);
    }
    [Test]
    public void _1_3_GetNextRegularPossibleMazeElementsToProcess_VerticalDirection_ReturnsBothDirectionsMazeElementsIndexes()
    {
        Vector2 currentMouseOnMazeElementIndex = new Vector2(5, 0);
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(10, 10);
        var buildingDirection = Direction.Down;
        var leftMazeElement = getMazeElementMock(new Vector2(5, 1));
        var rightMazeElement = getMazeElementMock(new Vector2(5, 1));
        var currentMouseOnMazeElement = getMazeElementMock(currentMouseOnMazeElementIndex);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY, buildingDirection, currentMouseOnMazeElementIndex, leftMazeElement, rightMazeElement);

        var nextPossibleExtreamPointMazeElements = Substitute.For<NextPossibleExtreamPointMazeElements>(currentMouseOnMazeElementIndex, buildingDirection, planeController);
        IMazeElement[] nextPossibleMazeElementsToProcess = nextPossibleExtreamPointMazeElements.NextPossibleMazeElementsToProcessForExtremePoints();
        Assert.AreEqual(nextPossibleMazeElementsToProcess[0].Index, nextPossibleMazeElementsToProcess[1].Index);
    }

    [Test]
    public void _1_4_GetNextRegularPossibleMazeElementsToProcess_VerticalDirection_ReturnsException()
    {
        Vector2 currentMouseOnMazeElementIndex = new Vector2(5, 0);
        Vector2 intagerNumberOfMazeElementsOnXAndY = new Vector2(10, 10);
        var buildingDirection = Direction.Right;
        var leftMazeElement = getMazeElementMock(new Vector2(5, 1));
        var rightMazeElement = getMazeElementMock(new Vector2(5, 1));
        var currentMouseOnMazeElement = getMazeElementMock(currentMouseOnMazeElementIndex);
        var planeController = getPlaneControllerMock(intagerNumberOfMazeElementsOnXAndY, buildingDirection, currentMouseOnMazeElementIndex, leftMazeElement, rightMazeElement);

        var nextPossibleExtreamPointMazeElements = Substitute.For<NextPossibleExtreamPointMazeElements>(currentMouseOnMazeElementIndex, buildingDirection, planeController);
        //IMazeElement[] nextPossibleMazeElementsToProcess = nextPossibleExtreamPointMazeElements.NextPossibleMazeElementsToProcessForExtremePoints();
        //Assert.AreEqual(nextPossibleMazeElementsToProcess[0].Index, nextPossibleMazeElementsToProcess[1].Index);
        Assert.Throws<System.InvalidOperationException>(() => nextPossibleExtreamPointMazeElements.NextPossibleMazeElementsToProcessForExtremePoints());
    }

    #endregion
}*/
