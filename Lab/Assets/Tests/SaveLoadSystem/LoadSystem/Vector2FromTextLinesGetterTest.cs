using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;

public class Vector2FromTextLinesGetterTest {

    [Test]
    public void _1_1_GetVectorsFromTextLinesThatContainsString_CountCheck()
    {
        string[] saveTextLines = { "(86,0, 86,0) is IntagerNumberOfElementsOnXAndY", "(0,0, 0,0) is maze wall element" };

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "IntagerNumberOfElementsOnXAndY");
        Assert.AreEqual(vector2List.Count, 1);
    }

    [Test]
    public void _1_2_GetVectorsFromTextLinesThatContainsString_ContentCheck()
    {
        string[] saveTextLines = { "(86,0, 86,0) is IntagerNumberOfElementsOnXAndY", "(0,0, 0,0) is maze wall element" };

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
        Assert.AreEqual(vector2List[0], new Vector2(0, 0));
    }
    [Test]
    public void _1_3_GetVectorsFromTextLinesThatContainsString_ContentCheck()
    {
        string[] saveTextLines = { "(86, 0, 86, 0) is IntagerNumberOfElementsOnXAndY", "(0,0, 0,0) is maze wall element", "(1,2, 57) is maze wall element" };

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
        Assert.AreEqual(vector2List[0], new Vector2(0, 0));
        Assert.AreEqual(vector2List[1], new Vector2(1.2f, 57));
    }
    [Test]
    public void _1_4_GetVectorsFromTextLinesThatContainsString_ContentCheck()
    {
        string[] saveTextLines = { "Bounds format: Center: (0, 0, 0, 0, 0, 0), Extents: (5, 0, 5, 0, 5, 0)", "(86, 0, 86, 0) is IntagerNumberOfElementsOnXAndY", "(0,0, 0,0) is maze wall element", "(1,2, 57,0) is maze wall element" };

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
        Assert.AreEqual(vector2List[0], new Vector2(0, 0));
        Assert.AreEqual(vector2List[1], new Vector2(1.2f, 57));
    }

    [Test]
    public void _1_5_GetVectorsFromTextLinesThatContainsString_ContentCheck()
    {
        string[] saveTextLines = { "Bounds format: Center: (0, 0, 0, 0, 0, 0), Extents: (5, 0, 5, 0, 5, 0)", "(86, 0, 86, 0) is IntagerNumberOfElementsOnXAndY", "(0,0, 0,0) is maze wall element", "(1,2, 57,0) is maze wall element", "1,2 54,33 is trahs string for test " };

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
        Assert.AreEqual(vector2List.Count, 2);
    }
    [Test]
    public void _1_6_GetVectorsFromTextLinesThatContainsString_ContentCheck()
    {
        string[] saveTextLines = { "Bounds format: Center: (0, 0, 0, 0, 0, 0), Extents: (5, 0, 5, 0, 5, 0)", "(86, 0, 86, 0) is IntagerNumberOfElementsOnXAndY", "(0,0, 0,0) is maze wall element", "(1,2, 57,0) is maze wall element", "1,2 54,33 is trahs string for test "};

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
        Assert.AreEqual(vector2List[0], new Vector2(0, 0));
        Assert.AreEqual(vector2List[1], new Vector2(1.2f, 57));
    }

    [Test]
    public void _1_7_GetVectorsFromTextLinesThatContainsString_ContentCheck()
    {
        string[] saveTextLines = { "Bounds format: Center: (0, 0, 0, 0, 0, 0), " +
                "Extents: (5, 0, 5, 0, 5, 0)",
            "(86, 0, 86, 0) is IntagerNumberOfElementsOnXAndY",
            "(0,0, 0,0) is maze wall element",
            "(1,2, 57,0) is maze wall element",
            "1,2 54,33 is trahs string for test ",
             "Bounds format: Center: (0, 0, 0, 0, 0, 0), " ,
                "Extents: (5, 0, 5, 0, 5, 0)",
            "(8, 0, 8, 0) is IntagerNumberOfElementsOnXAndY",
            "(9,0, 9,0) is maze wall element",
            "(19,2, 579,0) is maze wall element",
            "1,2 54,33 is trahs string for test "};

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
        Assert.AreEqual(vector2List[0], new Vector2(0, 0));
        Assert.AreEqual(vector2List[1], new Vector2(1.2f, 57));
    }

    [Test]
    public void _1_8_GetVectorsFromTextLinesThatContainsString_CountCheck()
    {
        string[] saveTextLines = { "Bounds format: Center: (0, 0, 0, 0, 0, 0), " +
                "Extents: (5, 0, 5, 0, 5, 0)",
             "(8, 0, 8, 0) is IntagerNumberOfElementsOnXAndY",
            "(9,0, 9,0) is maze wall element",
            "(19,2, 579,0) is maze wall element",
            "1,2 54,33 is trahs string for test ",
        "Extents: (5, 0, 5, 0, 5, 0)",
            "(86, 0, 86, 0) is IntagerNumberOfElementsOnXAndY",
            "(0,0, 0,0) is maze wall element",
            "(1,2, 57,0) is maze wall element",
            "1,2 54,33 is trahs string for test "};

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
        Assert.AreEqual(vector2List.Count, 2);
    }

    [Test]
    public void _1_8_GetVectorsFromTextLinesThatContainsString_ContentCheck()
    {
        string[] saveTextLines = { "Bounds format: Center: (0, 0, 0, 0, 0, 0), " +
                "Extents: (5, 0, 5, 0, 5, 0)",
             "(8, 0, 8, 0) is IntagerNumberOfElementsOnXAndY",
            "(9,0, 9,0) is maze wall element",
            "(19,2, 579,0) is maze wall element",
            "1,2 54,33 is trahs string for test ",
                "Extents: (5, 0, 5, 0, 5, 0)",
            "(86, 0, 86, 0) is IntagerNumberOfElementsOnXAndY",
            "(0,0, 0,0) is maze wall element",
            "(1,2, 57,0) is maze wall element",
            "1,2 54,33 is trahs string for test "};

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
        Assert.AreEqual(vector2List[0], new Vector2(9, 9));
        Assert.AreEqual(vector2List[1], new Vector2(19.2f, 579));
    }

    [Test]
    public void _1_10_GetVectorsFromTextLinesThatContainsString_CountCheck()
    {
        string[] saveTextLines = { "Bounds format: Center: (0, 0, 0, 0, 0, 0), " +
                "Extents: (5, 0, 5, 0, 5, 0)",
             "(8, 0, 8, 0) is IntagerNumberOfElementsOnXAndY",
            "(9,0, 9,0) is maze wall element",
            "(19,2, 579,0) is maze wall element",
            "(9,0, 9,0) is maze wall element",
            "(19,2, 579,0) is maze wall element",
            "(9,0, 9,0) is maze wall element",
            "(19,2, 579,0) is maze wall element",
            "(9,0, 9,0) is maze wall element",
            "(19,2, 579,0) is maze wall element",};

        Vector2FromTextLinesGetter vector2FromTextLinesGetter = new Vector2FromTextLinesGetter();
        List<Vector2> vector2List = vector2FromTextLinesGetter.GetVectorsFromTextLinesThatContainsString(saveTextLines, "is maze wall element");
        Assert.AreEqual(vector2List.Count, 8);
    }
}
