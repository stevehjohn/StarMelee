using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace StarMelee.Graphics
{
    public class SpriteManager
    {
        private readonly ContentManager _contentManager;

        private readonly SpriteBatch _spriteBatch;

        private readonly float _xScale;
        
        private readonly float _yScale;

        private Texture2D _ships;

        public SpriteManager(ContentManager contentManager, SpriteBatch spriteBatch, float xScale, float yScale)
        {
            _contentManager = contentManager;

            _spriteBatch = spriteBatch;

            _xScale = xScale;

            _yScale = yScale;
        }

        public void LoadSprites()
        {
            _ships = _contentManager.Load<Texture2D>("ships");
        }

        public void DrawShip(int x, int y, float rotation)
        {
            _spriteBatch.Draw(_ships, new Vector2(x * _xScale, y * _yScale), new Rectangle(0, 0, 96, 96), Color.White, rotation, new Vector2(48, 48), new Vector2(_xScale, _yScale), SpriteEffects.None, 0);
        }
    }
}