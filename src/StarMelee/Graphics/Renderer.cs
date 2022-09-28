using System.Collections.Generic;
using StarMelee.GameElements;

namespace StarMelee.Graphics
{
    public class Renderer
    {
        private readonly SpriteManager _sprites;

        public Renderer(SpriteManager sprites)
        {
            _sprites = sprites;
        }

        public void Draw(List<Ship> ships)
        {
            foreach (var ship in ships)
            {
                _sprites.DrawShip(ship.ShipType, 960, 540, ship.Direction);
            }
        }
    }
}