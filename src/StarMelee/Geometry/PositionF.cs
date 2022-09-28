namespace StarMelee.Geometry
{
    public class PositionF
    {
        public float X { get; }

        public float Y { get; }

        public PositionF(float x, float y)
        {
            X = x;

            Y = y;
        }

        public override string ToString()
        {
            return $"{X}, {Y}";
        }
    }
}