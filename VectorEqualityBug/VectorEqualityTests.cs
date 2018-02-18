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
    }
}
