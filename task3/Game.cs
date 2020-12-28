using System;
using System.Collections.Generic;
using System.Text;

namespace task3
{
    public class Game
    {
        private string[] parameters;

        public Game(string[] parameters)
        {
            this.parameters = parameters;
        }

        private int playerTurn()
        {
            int move = 0;
            do
            {
                int i = 1;
                Console.WriteLine("Available moves:");
                foreach (var param in parameters)
                {
                    Console.WriteLine(i++ + " - " + param);
                }

                Console.WriteLine("0 - exit");
                Console.WriteLine("Enter your move:");
                var input = Console.ReadLine();
                try
                {
                    move = Convert.ToInt32(input);
                }
                catch(FormatException e)
                {
                    move = -1;
                }
            } while (move > parameters.Length || move < 0);
            if (move == 0) return move;
            Console.WriteLine("Your move is " + parameters[move-1]);
            return move;
        }

        private int botTurn()
        {
            Random rnd = new Random();
            return rnd.Next(1,parameters.Length);
        }

        private int GetWinner(int playerMove, int botMove)
        {
            var substract = playerMove - botMove;
            if (substract == 0) return 3;
            else if ((substract <= parameters.Length / 2 && substract > 0)
                    || substract < -parameters.Length / 2)
                return 2;
            else
                return 1;
        }

        public void StartGame()
        {
            int botMove = botTurn();
            string key = Crypt.GenerateKey();
            string hmac = Crypt.GenerateHMAC(key, parameters[botMove - 1]);
            Console.WriteLine("HMAC: " + hmac);
            int playerMove = playerTurn();
            if (playerMove == 0) return;
            int result = GetWinner(playerMove, botMove);
            if (result == 3) Console.WriteLine("Draw");
            else if (result == 1) Console.WriteLine("You win!");
            else Console.WriteLine("You lost");
            Console.WriteLine("Bot move is " + parameters[botMove-1]);
            Console.WriteLine("Hmac key: " + key);
            
        }
    }
}

// 1 2 3 4 5 6 7 
