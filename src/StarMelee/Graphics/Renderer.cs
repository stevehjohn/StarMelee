using System;
using StarMelee.Extensions;
using StarMelee.GameElements;
using StarMelee.Geometry;
using StarMelee.Infrastructure;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace StarMelee.Graphics
{
    public class Renderer
    {
        private readonly SpriteManager _sprites;

        private readonly List<Particle> _particles = new List<Particle>();

        private readonly List<Star> _stars = new List<Star>();

        private readonly Random _random = new Random();

        public Renderer(SpriteManager sprites)
        {
            _sprites = sprites;

            InitialiseStars();
        }

        public void Draw(Ship focusedShip, List<Ship> ships)
        {
            var origin = new PositionF(focusedShip.Position.X - GameConstants.ScreenWidth / 2f, focusedShip.Position.Y - GameConstants.ScreenHeight / 2f);

            origin = origin.AdjustPosition(focusedShip.Speed * 15, focusedShip.Direction);

            DrawShips(origin, ships);

            DrawParticles(origin);

            DrawStars();
        }

        public void AddParticle(Particle particle)
        {
            _particles.Add(particle);
        }

        private void DrawShips(PositionF origin, List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                _sprites.DrawShip(ship.ShipType, (int) (ship.Position.X - origin.X), (int) (ship.Position.Y - origin.Y), ship.Direction);
            }
        }

        private void DrawParticles(PositionF origin)
        {
            foreach (var particle in _particles)
            {
                particle.Update();

                _sprites.DrawParticle((int) (particle.Position.X - origin.X), (int) (particle.Position.Y - origin.Y), particle.Color, particle.Opacity, particle.ZIndex);
            }

            _particles.RemoveAll(p => p.Opacity <= 0);
        }

        private void DrawStars()
        {
            foreach (var star in _stars)
            {
                _sprites.DrawStar((int) star.Position.X, (int) star.Position.Y, star.Color, star.Scale);

                star.Position = new PositionF(star.Position.X, star.Position.Y + star.Scale);
            }
        }

        private void InitialiseStars()
        {
            for (var i = 0; i < 1_000; i++)
            {
                var star = new Star(new PositionF(_random.Next(GameConstants.ScreenWidth), _random.Next(GameConstants.ScreenHeight)), Color.White * ((float) _random.NextDouble() / 2f + 0.25f), (float) _random.NextDouble());

                _stars.Add(star);
            }
        }
    }
}