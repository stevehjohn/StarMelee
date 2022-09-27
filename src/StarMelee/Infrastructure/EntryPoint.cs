using System;

namespace StarMelee.Infrastructure
{
    public static class EntryPoint
    {
        [STAThread]
        public static void Main()
        {
            using (var game = new StarMelee())
            {
                game.Run();
            }
        }
    }
}
