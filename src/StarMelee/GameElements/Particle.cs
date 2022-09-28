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

        public float ZIndex { get; }

        public Particle(PositionF position, Color color, float opacity, float opacityDelta, float zIndex)
        {
            Position = position;

            Color = color;

            Opacity = opacity;

            OpacityDelta = opacityDelta;

            ZIndex = zIndex;
        }

        public void Update()
        {
            Opacity -= OpacityDelta;
        }
    }
}