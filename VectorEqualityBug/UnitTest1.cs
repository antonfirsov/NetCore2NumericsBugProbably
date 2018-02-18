using System;
using System.Numerics;
using Xunit;

namespace VectorEqualityBug
{
    public struct Foo : IEquatable<Foo>
    {
        public Vector2 BackingVector;

        public Foo(float x, float y)
        {
            this.BackingVector = new Vector2(x, y);
        }

        public bool Equals(Foo other)
        {
            return this.BackingVector.Equals(other.BackingVector);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Foo && Equals((Foo)obj);
        }

        public override int GetHashCode()
        {
            return this.BackingVector.GetHashCode();
        }

        public static bool operator ==(Foo left, Foo right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(Foo left, Foo right)
        {
            return !left.Equals(right);
        }
    }

    public class FooEqualityTests
    {
        [Fact]
        public void NormalEquality()
        {
            Foo a = new Foo(0.22f, 0.61f);
            Foo b = new Foo(0.22f, 0.61f);

            Assert.Equal(a, b);
        }

        [Fact]
        public void DirectBackingVectorEquality()
        {
            Foo a = new Foo(0.22f, 0.61f);
            Foo b = new Foo(0.22f, 0.61f);

            Assert.Equal(a.BackingVector, b.BackingVector);
        }
    }
}
