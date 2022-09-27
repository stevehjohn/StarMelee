using StarMelee.Geometry;

namespace StarMelee.GameElements
{
    public class Ship
    {
        public Position<float> Position { get; }

        public int ShipType { get; }

        public PlayerType PlayerType { get; }

        public float Direction { get; set; }

        public float Speed { get; set; }

        public Ship(Position<float> startPosition, int shipType, PlayerType playerType)
        {
            Position = startPosition;

            ShipType = shipType;

            PlayerType = playerType;

            Direction = 0;

            Speed = 0;
        }
    }
}