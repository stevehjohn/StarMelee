using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using StarMelee.Infrastructure.Configuration;
using StarMelee.Infrastructure.Utilities;

namespace StarMelee.Infrastructure
{
    public class StarMelee : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        
        private SpriteBatch _spriteBatch;

        public StarMelee()
        {
            var windowSize = ResolutionResolver.GetResolution(AppSettings.Instance.Resolution);

            _graphics = new GraphicsDeviceManager(this) 
                        { 
                            PreferredBackBufferWidth = windowSize.Width,
                            PreferredBackBufferHeight = windowSize.Height
                        };

            Content.RootDirectory = "_Content";
        }

        protected override void Initialize()
        {
            IsMouseVisible = false;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            base.Draw(gameTime);
        }
    }
}
