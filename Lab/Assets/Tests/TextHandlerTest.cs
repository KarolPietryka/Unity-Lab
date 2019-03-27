using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;

public class TextHandlerTest {

    [Test]
    public void _1_1_RemoveAllNonVectorPartsOfString()
    {
       // SaveTextReader saveTextReader = new SaveTextReader(Substitute.For<ITextFileController>());
        string intagerNumberOfMazeElementsOnXAndY = TextHandler.RemoveAllNonVectorPartsOfString("(1,0, 1,0) is IntagerNumberOfElementsOnXAndY");
        Assert.AreEqual("1,0, 1,0", intagerNumberOfMazeElementsOnXAndY);
    }

    [Test]
    public void _1_2_RemoveAllNonVectorPartsOfString()
    {
       // SaveTextReader saveTextReader = new SaveTextReader(Substitute.For<ITextFileController>());
        string intagerNumberOfMazeElementsOnXAndY = TextHandler.RemoveAllNonVectorPartsOfString("(  1,  0, 1, 0  ) is IntagerNumberOfElementsOnXAndY");
        Assert.AreEqual("  1,  0, 1, 0  ", intagerNumberOfMazeElementsOnXAndY);
    }

    [Test]
    public void _1_3_RemoveAllNonVectorPartsOfString()
    {
        string intagerNumberOfMazeElementsOnXAndY = TextHandler.RemoveAllNonVectorPartsOfString("Center: (0,0, 0,0, 0,0), Extents: (5,0, 5,0, 5,0)");
        Assert.AreEqual("0,0, 0,0, 0,0", intagerNumberOfMazeElementsOnXAndY);
    }

    [Test]
    public void _1_1_FindFirstLineWhichContainsString()
    {
        string[] stringLines = { "(1,2 2,1, 1,1) is GamePlaneBounds", "(10,0, 10,0) is IntagerNumberOfElementsOnXAndY" };
        int lineWithString = TextHandler.FindFirstLineWhichContainsString("IntagerNumberOfElementsOnXAndY", stringLines);
        Assert.AreEqual(lineWithString, 1);
    }

    [Test]
    public void _1_2_FindFirstLineWhichContainsString()
    {
        string[] stringLines = { "(1,2 2,1, 1,1) is GamePlaneBounds"," ", "(10,0, 10,0) is IntagerNumberOfElementsOnXAndY", "0,0, 0,0  is maze wall element"};
        int lineWithString = TextHandler.FindFirstLineWhichContainsString("IntagerNumberOfElementsOnXAndY", stringLines);
        Assert.AreEqual(lineWithString, 2);
    }
}
