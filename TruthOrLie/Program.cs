using System;

namespace TruthOrLie
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var game = new TruthOrLieGame("Questions.csv");
            Console.WriteLine("Let's play Truth Or Lie game!");
            while (game.CountOfGetQuestions < game.CountOfQuestion && game.CountOfWrongAnswers <= game.CountOfWrong)
            {
                var question = game.GetQuestion();
                Console.WriteLine($"\nTruth or lie: {question.Name}? Answer \"Yes\" or \"No\"");
                var answer = Console.ReadLine();
                if (answer == question.Answer)
                {
                    Console.WriteLine("You're right!");
                }
                else
                {
                    Console.WriteLine($"Wrong answer! Tip: {question.Note}");
                    game.WrongAnswer();
                }
            }
            Console.WriteLine(game.CountOfWrongAnswers > game.CountOfWrong
                ? $"\nYou lost! You could make only {game.CountOfWrongAnswers} mistakes."
                : $"\nYou won! You have {game.CountOfWrongAnswers} mistakes");
        }
    }
}
