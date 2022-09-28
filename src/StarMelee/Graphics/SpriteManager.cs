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

        private Texture2D _particle;

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

            _particle = _contentManager.Load<Texture2D>("particle");
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
                              0.5f);
        }

        public void DrawParticle(int x, int y, Color color, float opacity, float zIndex)
        {
            _spriteBatch.Draw(_particle, 
                              new Vector2((x - 1) * _xScale, (y - 1) * _yScale),
                              new Rectangle(0, 0, 3, 3), 
                              color * opacity,
                              0, 
                              new Vector2(SpriteConstants.ShipWidth / 2f, SpriteConstants.ShipHeight / 2f), 
                              new Vector2(_xScale, _yScale), 
                              SpriteEffects.None,
                              zIndex);
        }
    }
}