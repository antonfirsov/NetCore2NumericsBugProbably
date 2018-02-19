using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using Xunit;

namespace VectorEqualityBug
{
    public struct Vector2Wrapper
    {
        public Vector2 BackingVector;

        public Vector2Wrapper(float x, float y)
        {
            this.BackingVector = new Vector2(x, y);
        }
    }

    public struct Vector4Wrapper
    {
        public Vector4 BackingVector;

        public Vector4Wrapper(float x, float y, float z, float w)
        {
            this.BackingVector = new Vector4(x, y, z, w);
        }
    }

    public struct Vector3Wrapper
    {
        public Vector3 BackingVector;

        public Vector3Wrapper(float x, float y, float z)
        {
            this.BackingVector = new Vector3(x, y, z);
        }
    }

    public class NestedVectorEqualityMagic
    {
        [Fact]
        public void FailsInDebug()
        {
            Vector2Wrapper a = new Vector2Wrapper(0.22f, 0.61f);
            Vector2Wrapper b = new Vector2Wrapper(0.22f, 0.61f);

            Assert.True(a.BackingVector.Equals(b.BackingVector));
        }

        [Fact]
        public void AlwaysSucceeds1()
        {
            Vector2 a = new Vector2(0.22f, 0.61f);
            Vector2 b = new Vector2(0.22f, 0.61f);

            Assert.True(a.Equals(b));
        }

        [Fact]
        public void AlwaysSucceeds2()
        {
            Vector2Wrapper a = new Vector2Wrapper(0.22f, 0.61f);
            Vector2Wrapper b = new Vector2Wrapper(0.22f, 0.61f);

            Assert.True(a.BackingVector.Equals((object)b.BackingVector));
        }

        [Fact]
        public void Vector4Test()
        {
            Vector4Wrapper a = new Vector4Wrapper(0.22f, 0.61f, 88.8f, 123);
            Vector4Wrapper b = new Vector4Wrapper(0.22f, 0.61f, 88.8f, 123);

            Assert.True(a.BackingVector.Equals(b.BackingVector));
        }

        [Fact]
        public void Vector3Test()
        {
            Vector3Wrapper a = new Vector3Wrapper(0.22f, 0.61f, 88.8f);
            Vector3Wrapper b = new Vector3Wrapper(0.22f, 0.61f, 88.8f);

            Assert.True(a.BackingVector.Equals(b.BackingVector));
        }
    }
}
