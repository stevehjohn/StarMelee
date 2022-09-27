using StarMelee.Geometry;

namespace StarMelee.GameElements
{
    public class Ship
    {
        public Position<float> Position { get; }

        public float Direction { get; set; }

        public float Speed { get; set; }

        public Ship(Position<float> startPosition)
        {
            Position = startPosition;

            Direction = 0;

            Speed = 0;
        }
    }
}