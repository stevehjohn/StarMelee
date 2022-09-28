using StarMelee.Controls;
using StarMelee.Extensions;
using StarMelee.GameElements;
using StarMelee.Geometry;
using StarMelee.Graphics;
using StarMelee.Infrastructure;
using System.Collections.Generic;

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
            }
        }

        public void Draw()
        {
            _renderer.Draw(_ships);
        }
    }
}