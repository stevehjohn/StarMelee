using StarMelee.Controls;
using StarMelee.GameElements;
using StarMelee.Geometry;
using StarMelee.Graphics;

namespace StarMelee.Engines
{
    public class Battle : IEngine
    {
        private readonly SpriteManager _sprites;

        private readonly ControlProcessor _controlProcessor;

        private readonly Ship _localShip = new Ship(new Position<float>(0, 0), 0, PlayerType.Local, "Stevo");

        public Battle(SpriteManager spriteManager)
        {
            _sprites = spriteManager;

            _controlProcessor = new ControlProcessor();
        }

        public void Update()
        {
            _controlProcessor.UpdateShipState(_localShip);
        }

        public void Draw()
        {
            _sprites.DrawShip(0, 960, 540, _localShip.Direction);
        }
    }
}