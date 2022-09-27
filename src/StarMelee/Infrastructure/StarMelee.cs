using Microsoft.Xna.Framework;
using StarMelee.Engines;
using StarMelee.Graphics;
using StarMelee.Infrastructure.Configuration;
using StarMelee.Infrastructure.Utilities;
using StarMelee.Resources;

namespace StarMelee.Infrastructure
{
    public class StarMelee : Game
    {
        private readonly GraphicsDeviceManager _graphicsDeviceManager;
        
        private readonly SpriteManager _sprites;

        private IEngine _engine;

        public StarMelee()
        {
            var windowSize = ResolutionResolver.GetResolution(AppSettings.Instance.Resolution);

            _graphicsDeviceManager = new GraphicsDeviceManager(this) 
                        { 
                            PreferredBackBufferWidth = windowSize.Width,
                            PreferredBackBufferHeight = windowSize.Height
                        };

            Content.RootDirectory = "_Content";

            _sprites = new SpriteManager(GraphicsDevice);
        }

        protected override void Initialize()
        {
            IsMouseVisible = false;

            Window.Title = ResourceManager.Instance.GetResource("window-title");

            _engine = new Battle(_sprites);

            base.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            _engine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _engine.Draw();

            base.Draw(gameTime);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _graphicsDeviceManager.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
