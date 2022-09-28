using System.Collections.Generic;
using System.Diagnostics;
using StarMelee.Controls;
using StarMelee.Extensions;
using StarMelee.GameElements;
using StarMelee.Geometry;
using StarMelee.Graphics;

namespace StarMelee.Engines
{
    public class Battle : IEngine
    {
        private readonly SpriteManager _sprites;

        private readonly ControlProcessor _controlProcessor;

        private readonly List<Ship> _ships = new List<Ship>();

        private readonly Ship _focusedShip;

        public Battle(SpriteManager spriteManager)
        {
            _sprites = spriteManager;

            _controlProcessor = new ControlProcessor();

            _ships.Add(new Ship(new PositionF(0, 0), 0, PlayerType.Local, "Stevo")
                       {
                           Speed = 10
                       });

            _focusedShip = _ships[0];
        }

        public void Update()
        {
            foreach (var ship in _ships)
            {
                if (ship.PlayerType == PlayerType.Local)
                {
                    _controlProcessor.UpdateShipState(ship);
                }

                ship.Position = ship.Position.AdjustPosition(ship.Speed, ship.Direction);

                Debug.WriteLine($"{ship.Position.X}, {ship.Position.Y}");
            }
        }

        public void Draw()
        {
            _sprites.DrawShip(0, 960, 540, _focusedShip.Direction);
        }
    }
}