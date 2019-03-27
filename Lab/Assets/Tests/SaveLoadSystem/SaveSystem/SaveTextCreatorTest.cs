using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;
using System.Collections.Generic;

public class SaveTextCreatorTest {

    IPlaneBuilder GetPlaneBuilderMock(Vector2 gamePlaneSize, List<Vector2> indexesOfMazeElementsThatAreMazeWall)
    {
        var planeBuilder = Substitute.For<IPlaneBuilder>();
        planeBuilder.IntagerNumberOfMazeElementsOnXAndY.Returns(gamePlaneSize);
        for (int i = 0; i <= gamePlaneSize.x; i++)
        {
            for (int j = 0; j <= gamePlaneSize.y; j++)
            {
                var mazeElement = Substitute.For<IMazeElement>();
                mazeElement.Index.Returns(new Vector2(i, j));

                if (indexesOfMazeElementsThatAreMazeWall.Contains(new Vector2(i, j)))
                {
                    mazeElement.IsMazeWall.Returns(true);
                }                
                else
                {
                    mazeElement.IsMazeWall.Returns(false);
                }
                planeBuilder.GetFromMazeArray(i, j).Returns(mazeElement);
            }
        }
        return planeBuilder;
    }

    public IPlaneElementsBounds GetPlaneElementsBounds(Bounds gamePlaneBound)
    {
        IPlaneElementsBounds planeElementsBounds = Substitute.For<IPlaneElementsBounds>();
        planeElementsBounds.GamePlaneBounds.Returns(gamePlaneBound);

        return planeElementsBounds;
    }
    [Test]
    public void CreateSaveText_CountCheck()
    {
        List<Vector2> listOfMazeElementsThatAreMazeWall = new List<Vector2>();
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 3));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 4));

        IPlaneElementsBounds planeElementsBounds = GetPlaneElementsBounds(new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 10)));
        IPlaneBuilder planeBuilder = GetPlaneBuilderMock(new Vector2(10, 10), listOfMazeElementsThatAreMazeWall);
        
        MazeSaveTextCreator mazeSaveTextCreator = new MazeSaveTextCreator(planeBuilder, planeElementsBounds, new List<string>(), Substitute.For<IMazeSpecialElementsSeeker>());
        List<string> saveTextToCheck = mazeSaveTextCreator.CreateSaveText();
        Assert.AreEqual(saveTextToCheck.Count, 8);
    }

    [Test]
    public void CreateSaveText_ContainCheck()
    {
        List<Vector2> listOfMazeElementsThatAreMazeWall = new List<Vector2>();
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 0));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 1));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 3));
        listOfMazeElementsThatAreMazeWall.Add(new Vector2(0, 4));
        Vector3 gamePlaneCenter = new Vector3(0, 0, 0);
        Vector3 gamePlaneSize = new Vector3(10, 10, 10);

        IPlaneElementsBounds planeElementsBounds = GetPlaneElementsBounds(new Bounds(new Vector3(0, 0, 0), new Vector3(10, 10, 10)));
        IPlaneBuilder planeBuilder = GetPlaneBuilderMock(new Vector2(10, 10), listOfMazeElementsThatAreMazeWall);

        MazeSaveTextCreator mazeSaveTextCreator = new MazeSaveTextCreator(planeBuilder, planeElementsBounds, new List<string>(), Substitute.For<IMazeSpecialElementsSeeker>());
        List<string> saveTextToCheck = mazeSaveTextCreator.CreateSaveText();
        Assert.AreEqual(saveTextToCheck[0].Contains(gamePlaneCenter.ToString()), true);// Bounds format: "Center: (0,0, 0,0, 0,0), Extents: (5,0, 5,0, 5,0)"
        Assert.AreEqual(saveTextToCheck[0].Contains("5,0, 5,0, 5,0"), true);
        Assert.AreEqual(saveTextToCheck[3].Contains("10,0, 10,0"), true);
        Assert.AreEqual(saveTextToCheck[4].Contains("0,0, 0,0"), true);
        Assert.AreEqual(saveTextToCheck[5].Contains("0,0, 1,0"), true);
        Assert.AreEqual(saveTextToCheck[6].Contains("0,0, 3,0"), true);
        Assert.AreEqual(saveTextToCheck[7].Contains("0,0, 4,0"), true);
    }
}
