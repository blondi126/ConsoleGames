using System;

namespace Gallows
{
    internal class Program
    {
        private static void Main()
        {
            var game = new Gallows();
            Console.WriteLine("We asked the word. Try to guess it.");
            Console.WriteLine(game.GuessedWord);
            Console.WriteLine("\nPlease, enter a lowercase russian letter.");
            while (game.AttemptsCounter > 0 && game.RightAns < game.Word.Length)
            {
                char letter;
                while (!char.TryParse(Console.ReadLine(), out letter))
                    Console.WriteLine("Enter only lowercase russian letter");

                if (game.FindAndGetLetter(letter))
                {
                    Console.WriteLine($"\nYou guessed the letter:\n{game.GuessedWord}\n");
                    if (game.RightAns < game.Word.Length) Console.WriteLine("Enter 1 more letter");
                }
                else if (game.AttemptsCounter > 0) Console.WriteLine("\nThere is no such letter in the word. Try again:");
            }

            Console.WriteLine(game.RightAns == game.Word.Length
                ? $"You win. Congratulations. You made {6 - game.AttemptsCounter} mistakes."
                : $"\nYou lost. You made 6 mistakes. It was the word {game.Word}\n");
        }
    }
}
