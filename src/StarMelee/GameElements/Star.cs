using Microsoft.Xna.Framework;
using StarMelee.Geometry;

namespace StarMelee.GameElements
{
    public class Star
    {
        public PositionF Position { get; set; }

        public Color Color { get; }

        public float Scale { get; }

        public Star(PositionF position, Color color, float scale)
        {
            Position = position;

            Color = color;

            Scale = scale;
        }
    }
}