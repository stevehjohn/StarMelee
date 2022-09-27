using Microsoft.Xna.Framework.Graphics;

namespace StarMelee.Graphics
{
    public class SpriteManager
    {
        private readonly GraphicsDevice _graphicsDevice;

        public SpriteManager(GraphicsDevice graphicsDevice)
        {
            _graphicsDevice = graphicsDevice;
        }
    }
}