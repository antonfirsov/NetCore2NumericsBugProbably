using System;
using System.Numerics;

namespace VectorEqualityConsole
{
    public struct Vector2Wrapper
    {
        public Vector2 BackingVector;

        public Vector2Wrapper(float x, float y)
        {
            this.BackingVector = new Vector2(x, y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Vector2Wrapper a = new Vector2Wrapper(0.22f, 0.61f);
            Vector2Wrapper b = new Vector2Wrapper(0.22f, 0.61f);

            bool equality = a.BackingVector.Equals(b.BackingVector);

            Console.WriteLine($"Environment.Version: {Environment.Version} | Vector.IsHardwareAccelerated:{Vector.IsHardwareAccelerated}");
            Console.WriteLine("Expected: True | Actual: "+equality);
            Console.ReadLine();
        }
    }
}
