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

        public void DrawShip(int shipIndex, int x, int y, float rotation)
        {
            _spriteBatch.Draw(_ships, 
                              new Vector2(x * _xScale, y * _yScale),
                              new Rectangle(shipIndex * SpriteConstants.ShipWidth, 0, SpriteConstants.ShipWidth, SpriteConstants.ShipHeight), 
                              Color.White, 
                              rotation, 
                              new Vector2(SpriteConstants.ShipWidth / 2f, SpriteConstants.ShipHeight / 2f), 
                              new Vector2(_xScale, _yScale), 
                              SpriteEffects.None, 
                              0);
        }
    }
}