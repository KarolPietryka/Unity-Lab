/*using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class NextPossibleMazeElementsProviderTest {

    public INextPossibleExtreamPointMazeElements GetNextPossibleExtreamPointMazeElementsMock()
    {
        var nextPossibleExtreamPointMazeElements = Substitute.For<INextPossibleExtreamPointMazeElements>();
        return nextPossibleExtreamPointMazeElements;
    }
    public INextPossibleRegularMazeElements GetNextPossibleRegularMazeElementsMock()
    {
        var nextPossibleRegularMazeElements = Substitute.For<INextPossibleRegularMazeElements>();
        nextPossibleRegularMazeElements.NextRegularPossibleMazeElementsToProcess().Returns(x => { throw new System.IndexOutOfRangeException(); });

        return nextPossibleRegularMazeElements;
    }
    #region
    [Test]
    public void _1_1_NextPossibleMazeElementsProvider_ThrewIndexOutOfRangeException()
    {
        var nextPossibleExtreamPointMazeElements = GetNextPossibleExtreamPointMazeElementsMock();
        var nextPossibleRegularMazeElements = GetNextPossibleRegularMazeElementsMock();

        var nextPossibleMazeElementsProvider = Substitute.For<NextPossibleMazeElementsProvider>(nextPossibleRegularMazeElements, nextPossibleExtreamPointMazeElements);
        nextPossibleMazeElementsProvider.GetNextPossibleMazeElementsToProcess();

        nextPossibleExtreamPointMazeElements.Received().NextPossibleMazeElementsToProcessForExtremePoints();
        //Assert.Throws<System.IndexOutOfRangeException>(() => nextPossibleMazeElementsProvider.GetNextPossibleMazeElementsToProcess());
    }
    #endregion
}*/
