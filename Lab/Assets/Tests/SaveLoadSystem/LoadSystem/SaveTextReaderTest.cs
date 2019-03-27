using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;
using NSubstitute;
using System.Collections.Generic;

public class SaveTextReaderTest {

    public ITextFileController GetTextFileController(string[] saveTextLines)
    {
        var textFileController = Substitute.For<ITextFileController>();
        textFileController.GetNTextFromList(0).ReturnsForAnyArgs(saveTextLines);

        return textFileController;
    }
    public IVector2FromTextLinesGetter GetVector2FromTextLinesGetter()
    {
        var vector2FromTextLinesGetter = Substitute.For<IVector2FromTextLinesGetter>();

        return vector2FromTextLinesGetter;
    }

    [Test]
    public void _1_1_GetGamePlaneBounds_ContentCheck()
    {
        string[] saveTextLines = { "(1,2, 57) is maze wall element", "(1,2, 57) is maze wall element", "Bounds format: Center: (0, 0, 0, 0, 0, 0), Extents: (5,0, 5,0, 5,0)", "(1,2, 57) is maze wall element" };
        var textFileController = GetTextFileController(saveTextLines);
        var vector2FromTextLinesGetter = GetVector2FromTextLinesGetter();
        SaveTextReader saveTextReader = new SaveTextReader(textFileController, new Vector2(), vector2FromTextLinesGetter);
        Bounds gamePlanebounds = saveTextReader.GetGamePlaneBounds(0);
        Assert.AreEqual(gamePlanebounds.center, new Vector3(0, 0, 0));
        Assert.AreEqual(gamePlanebounds.extents, new Vector3(5, 5, 5));
    }

}
