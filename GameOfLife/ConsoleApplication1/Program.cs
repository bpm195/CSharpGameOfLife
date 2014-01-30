using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;


namespace GameOfLife
{
    class Program
    {
        public const char quitKey = 'q';

        static void Main(string[] args)
        {
            iGameOfLifeBoard game;

            ConfiguredSettings.intitialize();
            using (StreamReader reader = new StreamReader(ConfiguredSettings.InputFile))
            {
                game = new GameOfLifeBoard2D(reader);
            }

            do
            {
                game.Tick();
                game.Print(Console.Out);
            } while (userWantsToContinue());
        }

        public static bool userWantsToContinue()
        {
            Console.WriteLine(String.Format("Type anything but {0} to continue", quitKey));
            char response = Console.ReadKey(true).KeyChar;
            return !(response==quitKey);
        }
    }
}
