using Microsoft.Xna.Framework.Input;
using StarMelee.GameElements;

namespace StarMelee.Controls
{
    public class ControlProcessor
    {
        public void UpdateShipState(Ship ship)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.O))
            {
                ship.RotateLeft();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.P))
            {
                ship.RotateRight();
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                ship.Accelerate();
            }
        }
    }
}