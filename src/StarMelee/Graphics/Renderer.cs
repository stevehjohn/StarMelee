using System.Collections.Generic;
using StarMelee.Extensions;
using StarMelee.GameElements;
using StarMelee.Geometry;
using StarMelee.Infrastructure;

namespace StarMelee.Graphics
{
    public class Renderer
    {
        private readonly SpriteManager _sprites;

        public Renderer(SpriteManager sprites)
        {
            _sprites = sprites;
        }

        public void Draw(Ship focusedShip, List<Ship> ships)
        {
            var origin = new PositionF(focusedShip.Position.X - GameConstants.ScreenWidth / 2f, focusedShip.Position.Y - GameConstants.ScreenHeight / 2f);

            origin = origin.AdjustPosition(focusedShip.Speed * 15, focusedShip.Direction);

            foreach (var ship in ships)
            {
                _sprites.DrawShip(ship.ShipType, (int) (ship.Position.X - origin.X),  (int) (ship.Position.Y - origin.Y), ship.Direction);
            }
        }
    }
}