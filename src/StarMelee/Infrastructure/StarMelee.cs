﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        
        private SpriteManager _sprites;

        private SpriteBatch _spriteBatch;

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

            IsFixedTimeStep = true;

            TargetElapsedTime = TimeSpan.FromSeconds(1f / 30f);
        }

        protected override void Initialize()
        {
            IsMouseVisible = false;

            Window.Title = ResourceManager.Instance.GetResource("window-title");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _sprites = new SpriteManager(Content, _spriteBatch);
            
            _sprites.LoadSprites();

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
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin(SpriteSortMode.BackToFront, samplerState: SamplerState.PointClamp);

            _engine.Draw();

            _spriteBatch.End();

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
