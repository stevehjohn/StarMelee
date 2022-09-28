﻿using System;
using StarMelee.Controls;
using StarMelee.Extensions;
using StarMelee.GameElements;
using StarMelee.Geometry;
using StarMelee.Graphics;
using StarMelee.Infrastructure;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace StarMelee.Engines
{
    public class Battle : IEngine
    {
        private readonly Renderer _renderer;

        private readonly ControlProcessor _controlProcessor;

        private readonly List<Ship> _ships = new List<Ship>();

        private readonly Ship _focusedShip;

        private readonly Random _random = new Random();

        public Battle(Renderer renderer)
        {
            _renderer = renderer;

            _controlProcessor = new ControlProcessor();

            _ships.Add(new Ship(new PositionF(GameConstants.ArenaWidth / 2f, GameConstants.ArenaHeight / 2f), 0, PlayerType.Local, "Stevo")
                       {
                           Speed = 20,
                           Properties =
                           {
                               Deceleration = 0.05f,
                               Acceleration = 0.2f,
                               MaxSpeed = 20
                           }
                       });

            _ships.Add(new Ship(new PositionF(GameConstants.ArenaWidth / 2f + 200, GameConstants.ArenaHeight / 2f), 1, PlayerType.Cpu, "Badger")
                       {
                           Speed = 15
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
            ship.Speed -= ship.Properties.Deceleration;

            if (ship.Speed < 0)
            {
                ship.Speed = 0;
            }

            if (ship.PlayerType == PlayerType.Local)
            {
                _controlProcessor.UpdateShipState(ship);
            }

            ship.Position = ship.Position.AdjustPosition(ship.Speed, ship.Direction);

            AddThrust(ship);
        }

        private void AddThrust(Ship ship)
        {
            if (ship.Speed == 0)
            {
                return;
            }

            // TODO: Make configurable depending on ship thruster location.
            var thrustOrigin = new PositionF(ship.Position.X + SpriteConstants.ShipWidth / 2f - 1, ship.Position.Y + SpriteConstants.ShipHeight / 2f);

            thrustOrigin = thrustOrigin.AdjustPosition(-47, ship.Direction);

            for (var i = 0; i < 20; i++)
            {
                var color = Color.Red;

                var hOffset = _random.Next(15) - 7;

                var vOffset = _random.Next(15) - 7;

                if (hOffset > -4 && hOffset < 4)
                {
                    color = Color.Yellow;
                }
                
                if (hOffset > -2 && hOffset < 2)
                {
                    color = Color.White;
                }

                _renderer.AddParticle(new Particle(new PositionF(thrustOrigin.X + hOffset, thrustOrigin.Y + vOffset), color, 1f, 0.1f, 0.4f));
            }
        }
    }
}