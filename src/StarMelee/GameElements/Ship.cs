using System;
using StarMelee.Geometry;

namespace StarMelee.GameElements
{
    public class Ship
    {
        public Position<float> Position { get; }

        public int ShipType { get; }

        public string Name { get; }

        public PlayerType PlayerType { get; }

        public float Direction { get; set; }

        public float Speed { get; set; }

        public ShipProperties Properties { get; }

        public Ship(Position<float> startPosition, int shipType, PlayerType playerType, string name)
        {
            Position = startPosition;

            ShipType = shipType;

            PlayerType = playerType;

            Name = name;

            Direction = 0;

            Speed = 0;

            Properties = new ShipProperties();
        }

        public void RotateRight()
        {
            Direction += Properties.TurnDelta;

            if (Direction > Math.PI * 2)
            {
                Direction -= (float) Math.PI * 2;
            }
        }

        public void RotateLeft()
        {
            Direction -= Properties.TurnDelta;

            if (Direction < 0)
            {
                Direction += (float) Math.PI * 2;
            }
        }
    }
}