namespace StarMelee.Geometry
{
    public class Size<T>
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