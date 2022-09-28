using System;
using StarMelee.Geometry;

namespace StarMelee.Extensions
{
    public static class PositionExtensions
    {
        public static PositionF AdjustPosition(this PositionF position, float speed, float direction)
        {
            var x = position.X + (float) Math.Sin(direction) * speed;

            var y = position.Y - (float) Math.Cos(direction) * speed;

            return new PositionF(x, y);
        }
    }
}