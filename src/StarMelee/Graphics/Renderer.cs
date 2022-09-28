using StarMelee.Extensions;
using StarMelee.GameElements;
using StarMelee.Geometry;
using StarMelee.Infrastructure;
using System.Collections.Generic;

namespace StarMelee.Graphics
{
    public class Renderer
    {
        private readonly SpriteManager _sprites;

        private readonly List<Particle> _particles = new List<Particle>();

        public Renderer(SpriteManager sprites)
        {
            _sprites = sprites;
        }

        public void Draw(Ship focusedShip, List<Ship> ships)
        {
            var origin = new PositionF(focusedShip.Position.X - GameConstants.ScreenWidth / 2f, focusedShip.Position.Y - GameConstants.ScreenHeight / 2f);

            origin = origin.AdjustPosition(focusedShip.Speed * 15, focusedShip.Direction);

            DrawShips(origin, ships);

            DrawParticles(origin);
        }

        public void AddParticle(Particle particle)
        {
            _particles.Add(particle);
        }

        private void DrawShips(PositionF origin, List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                _sprites.DrawShip(ship.ShipType, (int) (ship.Position.X - origin.X),  (int) (ship.Position.Y - origin.Y), ship.Direction);
            }
        }

        private void DrawParticles(PositionF origin)
        {
            foreach (var particle in _particles)
            {
                particle.Update();

                _sprites.DrawParticle((int) (particle.Position.X - origin.X), (int) (particle.Position.Y - origin.Y), particle.Color, particle.Opacity);
            }

            _particles.RemoveAll(p => p.Opacity <= 0);
        }
    }
}