using UnityEngine;
using UnityEngine.TestTools;
using NUnit.Framework;
using System.Collections;

public class VectorMathTest {

    #region 1_IfAnyVectorsHaveEqualXYWithVector
    [Test]
    public void _1_1_IfAnyVectorsHaveEqualXWithVector_ReturnTrue()
    {
        bool ifAnyVectorsHaveEqualXWithVector;
        Vector2[] vectors = new Vector2[4] { new Vector2(1, 2), new Vector2(4, 1), new Vector2(3, 0), new Vector2(6, 10) };
        Vector2 vector = new Vector2(1, 3);

        ifAnyVectorsHaveEqualXWithVector = VectorMath.IfAnyVectorHaveEqualXWithVector(vectors, vector);
        Assert.AreEqual(ifAnyVectorsHaveEqualXWithVector, true);
    }
    [Test]
    public void _1_2_IfAnyVectorsHaveEqualXWithVector_ReturnFalse()
    {
        bool ifAnyVectorsHaveEqualXWithVector;
        Vector2[] vectors = new Vector2[4] { new Vector2(1, 2), new Vector2(4, 1), new Vector2(1, 0), new Vector2(6, 10) };
        Vector2 vector = new Vector2(7, 2);


        ifAnyVectorsHaveEqualXWithVector = VectorMath.IfAnyVectorHaveEqualXWithVector(vectors, vector);
        Assert.AreEqual(ifAnyVectorsHaveEqualXWithVector, false);
    }
    [Test]
    public void _1_3_IfAnyVectorsHaveEqualYWithVector_ReturnTrue()
    {
        bool ifAnyVectorsHaveEqualYWithVector;
        Vector2[] vectors = new Vector2[4] { new Vector2(1, 2), new Vector2(4, 1), new Vector2(3, 3), new Vector2(6, 10) };
        Vector2 vector = new Vector2(1, 3);

        ifAnyVectorsHaveEqualYWithVector = VectorMath.IfAnyVectorHaveEqualYWithVector(vectors, vector);
        Assert.AreEqual(ifAnyVectorsHaveEqualYWithVector, true);
    }
    [Test]
    public void _1_4_IfAnyVectorsHaveEqualYWithVector_ReturFalse()
    {
        bool ifAnyVectorsHaveEqualYWithVector;
        Vector2[] vectors = new Vector2[4] { new Vector2(1, 2), new Vector2(4, 1), new Vector2(3, 0), new Vector2(6, 10) };
        Vector2 vector = new Vector2(1, 3);

        ifAnyVectorsHaveEqualYWithVector = VectorMath.IfAnyVectorHaveEqualYWithVector(vectors, vector);
        Assert.AreEqual(ifAnyVectorsHaveEqualYWithVector, false);
    }
    #endregion

}
