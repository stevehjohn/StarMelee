using StarMelee.Controls;
using StarMelee.Extensions;
using StarMelee.GameElements;
using StarMelee.Geometry;
using StarMelee.Graphics;
using StarMelee.Infrastructure;
using System.Collections.Generic;
using System.Diagnostics;

namespace StarMelee.Engines
{
    public class Battle : IEngine
    {
        private readonly Renderer _renderer;

        private readonly ControlProcessor _controlProcessor;

        private readonly List<Ship> _ships = new List<Ship>();

        private readonly Ship _focusedShip;

        public Battle(Renderer renderer)
        {
            _renderer = renderer;

            _controlProcessor = new ControlProcessor();

            _ships.Add(new Ship(new PositionF(GameConstants.ArenaWidth / 2f, GameConstants.ArenaHeight / 2f), 0, PlayerType.Local, "Stevo")
                       {
                           Speed = 10,
                           Deceleration = 0.05f,
                           Acceleration = 0.2f,
                           MaxSpeed = 10
                       });

            _ships.Add(new Ship(new PositionF(GameConstants.ArenaWidth / 2f + 200, GameConstants.ArenaHeight / 2f), 1, PlayerType.Cpu, "Badger")
                       {
                           Speed = 8
                       });

            _focusedShip = _ships[0];
        }

        public void Update()
        {
            foreach (var ship in _ships)
            {
                UpdateShip(ship);
            }
        }

        public void Draw()
        {
            _renderer.Draw(_focusedShip, _ships);
        }

        private void UpdateShip(Ship ship)
        {
            ship.Speed -= ship.Deceleration;

            if (ship.Speed < 0)
            {
                ship.Speed = 0;
            }

            if (ship.PlayerType == PlayerType.Local)
            {
                _controlProcessor.UpdateShipState(ship);
            }

            ship.Position = ship.Position.AdjustPosition(ship.Speed, ship.Direction);
        }
    }
}