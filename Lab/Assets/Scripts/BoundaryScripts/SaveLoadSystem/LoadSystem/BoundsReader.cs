using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BoundsReader {

    public static Bounds GetBoundsFromString(string gamePlaneBoundsString)
    {
        int extentsStringPosition = gamePlaneBoundsString.IndexOf("Extents:");
        int centerStringPosition = gamePlaneBoundsString.IndexOf("Center:");

        string extentsVector3String = TextHandler.RemoveAllNonVectorPartsOfString(gamePlaneBoundsString.Remove(0, extentsStringPosition));
        string centerVector3String = TextHandler.RemoveAllNonVectorPartsOfString(gamePlaneBoundsString.Remove(extentsStringPosition));

        Bounds readedBound = new Bounds();
        readedBound.center = StringToVector3Parser.Parse(centerVector3String);
        readedBound.extents = StringToVector3Parser.Parse(extentsVector3String);

        return readedBound;
    }
}
