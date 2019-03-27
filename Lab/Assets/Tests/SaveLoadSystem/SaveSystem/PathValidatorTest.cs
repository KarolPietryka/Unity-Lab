using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class PathValidatorTest
{

    [Test]
    public void _1_1_ExecuteValidation_NoEmptyFolderPath()
    {
        string folderPath = "FolderPath";
        string defauldFolderPath = "DefaultFolderPath";

        PathValidator pathValidator = new PathValidator();

        pathValidator.SetDefaultIfFolderPathEmpty(ref folderPath, defauldFolderPath);

        Assert.AreNotEqual(folderPath, defauldFolderPath);

    }

    [Test]
    public void _1_2_ExecuteValidation_EmptyFolderPath()
    {
        string folderPath ="";
        string defauldFolderPath = "DefaultFolderPath";

        PathValidator pathValidator = new PathValidator();

        pathValidator.SetDefaultIfFolderPathEmpty(ref folderPath, defauldFolderPath);

        Assert.AreEqual(folderPath, defauldFolderPath);

    }
}
