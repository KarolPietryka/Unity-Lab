/*using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class NextPossibleRegularMazeElementsTest {

    private IPlaneBuilder getPlaneControllerMock(Direction buildingDirection, Vector2 currentMouseOnMazeElementIndex, IMazeElement leftOrUpMazeElement, IMazeElement rightOrDownMazeElement)
    {
        var planeController = Substitute.For<IPlaneBuilder>();   
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

    #region 1_GetNextRegularPossibleMazeElementsToProcess
    [Test]
    public void GetNextRegularPossibleMazeElementsToProcess_HorizontalDirection_ReturnsBothDirectionsMazeElementsIndexes()
    {
        Vector2 currentMouseOnMazeElementIndex = new Vector2(1, 1);
        var buildingDirection = Direction.Left;
        var leftMazeElement = getMazeElementMock(new Vector2(0, 1));
        var rightMazeElement = getMazeElementMock(new Vector2(2, 1));
        var currentMouseOnMazeElement = getMazeElementMock(currentMouseOnMazeElementIndex);
        var planeController = getPlaneControllerMock(buildingDirection, currentMouseOnMazeElementIndex, leftMazeElement, rightMazeElement);

        var nextPossibleRegularMazeElements = Substitute.For<NextPossibleRegularMazeElements>(currentMouseOnMazeElementIndex, buildingDirection, planeController);

        IMazeElement[] nextPossibleMazeElementsToProcess = nextPossibleRegularMazeElements.NextRegularPossibleMazeElementsToProcess();
        //Assert.AreEqual(nextPossibleMazeElementsToProcess[0].Index, leftMazeElement.Index);
        Assert.AreEqual(nextPossibleMazeElementsToProcess[1].Index, rightMazeElement.Index);
    }
    #endregion
}*/
