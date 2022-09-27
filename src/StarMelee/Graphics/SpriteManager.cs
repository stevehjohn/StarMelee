using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StarMelee.Graphics
{
    public class SpriteManager
    {
        private readonly ContentManager _contentManager;

        private readonly SpriteBatch _spriteBatch;

        private Texture2D _ships;

        public SpriteManager(ContentManager contentManager, SpriteBatch spriteBatch)
        {
            _contentManager = contentManager;

            _spriteBatch = spriteBatch;
        }

        public void LoadSprites()
        {
            _ships = _contentManager.Load<Texture2D>("ships");
        }

        public void DrawShip(int x, int y)
        {
            _spriteBatch.Draw(_ships, new Vector2(x - 48, y - 48), new Rectangle(0, 0, 96, 96), Color.White);
        }
    }
}