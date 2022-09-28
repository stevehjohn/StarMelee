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

        private Texture2D _star;

        private Texture2D _background;

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

            _star = _contentManager.Load<Texture2D>("star");

            _background = _contentManager.Load<Texture2D>("background-1");
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

        public void DrawStar(int x, int y, Color color, float scale)
        {
            _spriteBatch.Draw(_star,
                              new Vector2(x * _xScale, y * _yScale),
                              new Rectangle(0, 0, 7, 7),
                              color,
                              0,
                              Vector2.Zero, 
                              new Vector2(_xScale * scale, _yScale * scale),
                              SpriteEffects.None,
                              0.1f);
        }

        public void DrawBackground()
        {
            _spriteBatch.Draw(_background,
                              new Vector2(0, 0),
                              new Rectangle(0, 0, 1920, 1080),
                              Color.White * 0.2f,
                              0,
                              Vector2.Zero,
                              new Vector2(_xScale, _yScale),
                              SpriteEffects.None,
                              0.0f);
        }
    }
}