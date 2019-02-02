using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorMath {

    public static bool IfAnyVectorHaveEqualXWithVector(Vector2[] vectors, Vector2 vector)
    {
        int vectorsNumber = vectors.Length;
        for (int i = 0; i < vectorsNumber - 1; i++)
        {
            if (vectors[i].x == vector.x)
            {
                return true;
            }
        }
        return false;
    }
    public static bool IfAnyVectorHaveEqualYWithVector(Vector2[] vectors, Vector2 vector)
    {
        int vectorsNumber = vectors.Length;
        for (int i = 0; i < vectorsNumber - 1; i++)
        {
            if (vectors[i].y == vector.y)
            {
                return true;
            }
        }
        return false;
    }
}
