namespace StarMelee.Geometry
{
    public class SizeI
    {
        public int Width { get; }

        public int Height { get; }

        public SizeI(int width, int height)
        {
            Width = width;

            Height = height;
        }
 
        public override string ToString()
        {
            return $"{Width}, {Height}";
        }
    }
}