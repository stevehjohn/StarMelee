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

        public ShipCapabilities Capabilities { get; }

        public Ship(Position<float> startPosition, int shipType, PlayerType playerType, string name)
        {
            Position = startPosition;

            ShipType = shipType;

            PlayerType = playerType;

            Name = name;

            Direction = 0;

            Speed = 0;

            Capabilities = new ShipCapabilities();
        }

        public void RotateRight()
        {
            Direction += Capabilities.TurnDelta;

            if (Direction > Math.PI * 2)
            {
                Direction -= (float) Math.PI * 2;
            }
        }

        public void RotateLeft()
        {
            Direction -= Capabilities.TurnDelta;

            if (Direction < 0)
            {
                Direction += (float) Math.PI * 2;
            }
        }
    }
}