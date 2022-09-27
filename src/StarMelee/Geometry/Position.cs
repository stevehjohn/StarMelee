using System;

namespace StarMelee.Geometry
{
    public class Position<T> where T : struct, IComparable<T>
    {
        public T X { get; }

        public T Y { get; }

        public Position(T x, T y)
        {
            X = x;

            Y = y;
        }
    }
}