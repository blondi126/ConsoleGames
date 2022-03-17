using System;

namespace Guess_the_number
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to guess the number game!\n");
            Console.WriteLine("What do you want to do:");
            Console.WriteLine("1. Pick a number");
            Console.WriteLine("2. Guess the number");

            var k = 0;
            while (k != 1 && k!= 2)
            {
                var choice = Console.ReadLine();
                if (int.TryParse(choice, out k))
                {
                    if (k == 1 || k == 2) continue;
                    Console.WriteLine("Invalid format. Pick 1 or 2:");
                    k = 0;
                }
                else Console.WriteLine("Invalid format. Pick 1 or 2:");
            }
            var counter = 0;
            if (k==1)
            {
                Console.WriteLine("\nPlease, pick a number between 0 and 100.");
                Console.WriteLine("I will try to guess it :)\n");
                var left = 0;
                var right = 100;
                var ans = 50;
                while (counter < 5)
                {
                    Console.WriteLine($"\nI think it's {ans}");
                    Console.WriteLine("The number you picked is:");
                    Console.WriteLine("1. Equals");
                    Console.WriteLine("2. More");
                    Console.WriteLine("3. Less");
                    var numChoice = 0;
                    while (true)
                    {
                        var choice = Console.ReadLine();
                        if (int.TryParse(choice, out numChoice))
                        {
                            if (numChoice == 1 || numChoice == 2 || numChoice == 3)
                            {
                                break;
                            }
                            Console.WriteLine("Please, pick 1, 2 or 3:");
                            numChoice = -1;
                        }
                        else Console.WriteLine("Invalid format. Enter a 1, 2 or 3:");

                    }
                    switch(numChoice)
                    {
                        case 1:
                            Console.WriteLine("\nSheeesh. I win!");
                            counter = 6;
                            break;
                        case 2:
                            left = ans;
                            break;
                        case 3:
                            right = ans;
                            break;
                    }
                    ans = Search.Middle(left, right);
                    counter++;
                }
                if (counter == 5) Console.WriteLine("\nCongratulations. You win!");
            }
            else
            {
                var randomInt = new Random();
                var result = randomInt.Next(101);
                Console.WriteLine("\nPlease, enter a number between 0 and 100:");
                while (counter < 5)
                {
                    var num = -1;
                    while (true)
                    {
                        var choice = Console.ReadLine();
                        if (int.TryParse(choice, out num))
                        {
                            if (num >= 0 && num <= 100)
                            {
                                break;
                            }
                            Console.WriteLine("The number must be between 0 and 100. Try again:");
                            k = -1;

                        }
                        else Console.WriteLine("Invalid format. Enter a number between 0 and 100:");
                    }
                    if (result == num)
                    {
                        Console.WriteLine("\nCongratulations. You win!");
                        counter = 6;
                        break;
                    } else if (result > num && counter != 4)
                    {
                        Console.WriteLine("\nMy number is more. Try again:");
                    } else if (result < num && counter != 4)
                    {
                        Console.WriteLine("\nMy number is less. Try again:");
                    }
                    counter++;
                }
                if (counter == 5) Console.WriteLine("\nYou have no more attempts. I win!");
            }
        }
    }

    public static class Search
    {
        public static int Middle (int left, int right)
        {
            return (left+right)/2;
        }
    }
}
