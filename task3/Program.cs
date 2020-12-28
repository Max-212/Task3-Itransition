using System;
using System.Linq;

namespace task3
{
    class Program
    {
        static void Main(string[] args)
        {
            if(args.Length < 3 || args.Length%2 == 0)
            {
                Console.WriteLine("Invalid number of parameters( Odd number of parameters expected >= 3)");
                return;
            }
            if(args.Distinct().Count() != args.Length)
            {
                Console.WriteLine("All parameters must be unique");
                return;
            }

            Game game = new Game(args);
            game.StartGame();

        }
    }
}
