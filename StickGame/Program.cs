using System;

namespace StickGame
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var game = new StickGame(10, FirstPlayer.Man);
            game.RegistOnCheck(StickIs0);
            Console.WriteLine("Let's play to StickGame");
            Console.WriteLine($"Total {game.Sticks} sticks" );

            while (game.GameStatus == GameStatus.InProgress)
            {
                if (game.CounterSteps % 2 == 0)
                {
                    Console.WriteLine("Pick 1-3 sticks, please:");
                    var step = int.Parse(Console.ReadLine());
                    Console.WriteLine($"Left {game.ManIsRunning(step)} sticks"); 
                } else
                {
                    Console.WriteLine($"Machine choose {game.CarIsRunning()} sticks");
                    Console.WriteLine($"Left {game.Sticks} sticks");
                }
            }
          
        }
        public static void StickIs0(StickGame game)
        {
            Console.WriteLine("Sticks is over!");
            switch (game.GameStatus)
            {
                case GameStatus.Lost:
                    Console.WriteLine("You lost.");
                    break;
                case GameStatus.Won:
                    Console.WriteLine("You won.");
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
