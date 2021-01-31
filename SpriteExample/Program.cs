using System;

namespace SpriteExample
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new SpriteExampleGame())
                game.Run();
        }
    }
}
