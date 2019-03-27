using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class StringToVector2ParserTest {

    [Test]
    public void _1_1_Parse()
    {
        string stringToParse = "  1,0, 1,0 ";

        Vector2 parsedString = StringToVector2Parser.Parse(stringToParse);
        Assert.AreEqual(new Vector2(1, 1), parsedString);
    }

    [Test]
    public void _1_2_Parse()
    {
        string stringToParse = "  1,0,                                1,0 ";

        Vector2 parsedString = StringToVector2Parser.Parse(stringToParse);
        Assert.AreEqual(new Vector2(1, 1), parsedString);
    }

    [Test]
    public void _1_3_Parse()
    {
        string stringToParse = "  1        ,0      ,                                1,0 ";

        Vector2 parsedString = StringToVector2Parser.Parse(stringToParse);
        Assert.AreEqual(new Vector2(1, 1), parsedString);
    }

    [Test]
    public void _1_4_Parse()
    {
        string stringToParse = "  1        ,3333      ,                                1,1 ";

        Vector2 parsedString = StringToVector2Parser.Parse(stringToParse);
        Assert.AreEqual(new Vector2(1.3333f, 1.1f), parsedString);
    }

    [Test]
    public void _1_5_Parse()
    {
        string stringToParse = "  1,0, 1,0  ";

        Vector2 parsedString = StringToVector2Parser.Parse(stringToParse);
        Assert.AreEqual(new Vector2(1, 1), parsedString);
    }
}
