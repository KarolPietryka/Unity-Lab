using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;

public static class StringToVector2Parser  {

    public static Vector2 Parse(string stringToParse)
    {
        //stringToParse = Regex.Replace(stringToParse, @"\^d+,\^d+,\!s\!d+,\!d+" , "");TODO try set pattern

        float x = float.Parse(stringToParse.Remove(stringToParse.IndexOf(",", stringToParse.IndexOf(",") + 1)));
       
        float y = float.Parse(stringToParse.Remove(0, stringToParse.IndexOf(", ") + 1));
        
        return new Vector2(x, y);
    }

}
