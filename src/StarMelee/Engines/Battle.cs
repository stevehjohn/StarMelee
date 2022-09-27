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
            throw new System.NotImplementedException();
        }

        public void Draw()
        {
            throw new System.NotImplementedException();
        }
    }
}