using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StringToVector3Parser {

    public static Vector3 Parse(string sVector)
    {
        sVector = sVector.Replace(", ", ".");

        string[] temp = sVector.Split('.');
        float x = float.Parse(temp[0]);
        float y = float.Parse(temp[1]);
        float z = float.Parse(temp[2]);
        Vector3 rValue = new Vector3(x, y, z);
        return rValue;
    }
}
