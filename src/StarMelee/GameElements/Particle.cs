using Microsoft.Xna.Framework;
using StarMelee.Geometry;

namespace StarMelee.GameElements
{
    public class Particle
    {
        public PositionF Position { get; }

        public Color Color { get; }

        public float Opacity { get; private set; }

        public float OpacityDelta { get; }

        public Particle(PositionF position, Color color, float opacity, float opacityDelta)
        {
            Position = position;
            Color = color;
            Opacity = opacity;
            OpacityDelta = opacityDelta;
        }

        public void Update()
        {
            Opacity -= OpacityDelta;
        }
    }
}