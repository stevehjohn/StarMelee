using StarMelee.Geometry;

namespace StarMelee.GameElements
{
    public class Ship
    {
        public Position<float> Position { get; }

        public Ship(Position<float> startPosition)
        {
            Position = startPosition;
        }
    }
}