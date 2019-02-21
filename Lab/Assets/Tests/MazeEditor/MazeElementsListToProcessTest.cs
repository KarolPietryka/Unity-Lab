using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using NSubstitute;

public class MazeElementsListToProcessTest {

    private IPlaneBuilder planeBuilder;
    private IMouse mouseBoundary;
    private Direction processDirection;
    private List<IMazeElement> MazeElementsToProcess;

    IMouse GetMouseMock(Vector2 _currentMouseOnMazeElementIndex, Vector2 _lastMouseClickMazeElementIndex)
    {
        var mouse = Substitute.For<IMouse>();
        mouse.GetCurrentMouseOnMazeElementIndex().Returns(_currentMouseOnMazeElementIndex);
        mouse.GetLastMouseClickMazeElementIndex().Returns(_lastMouseClickMazeElementIndex);
        return mouse;
    }

    IPlaneBuilder GetPlaneBuilder(Vector2 gamePlaneSize, Vector2 indexesOfMazeElementsBelongingToAnotherMazeWall)
    {
        var planeBuilder = Substitute.For<IPlaneBuilder>();
        for (int i = 0; i <= gamePlaneSize.x; i++)
        {
            for (int j = 0; j <= gamePlaneSize.y; j++)
            {
                var mazeElement = Substitute.For<IMazeElement>();
                mazeElement.Index.Returns(new Vector2(i, j));

                if (i == indexesOfMazeElementsBelongingToAnotherMazeWall.x && j == indexesOfMazeElementsBelongingToAnotherMazeWall.y)
                {
                    mazeElement.IsElementOfAnotherWall.Returns(true);
                }
                else
                {
                    mazeElement.IsElementOfAnotherWall.Returns(false);
                }
                planeBuilder.GetFromMazeArray(i, j).Returns(mazeElement);
            }           
        }
        return planeBuilder;
    }

 
}
