using System;

namespace StarMelee.Geometry
{
    public class Size<T> where T : struct, IComparable<T>
    {
        public T Width { get; }

        public T Height { get; }

        public Size(T width, T height)
        {
            Width = width;

            Height = height;
        }
    }
}