using StarMelee.Graphics;

namespace StarMelee.Engines
{
    public class Battle : IEngine
    {
        private readonly SpriteManager _sprites;

        public Battle(SpriteManager spriteManager)
        {
            _sprites = spriteManager;
        }

        public void Update()
        {
        }

        public void Draw()
        {
            _sprites.DrawShip(960, 540);
        }
    }
}