using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int hiddenNumber = random.Next(1, 101);
        List<Guess> guesses = new List<Guess>();
        int userGuess = 0;

        do
        {
            Console.Write("Enter your number guess: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out userGuess))
            {
                var previousGuess = guesses.FirstOrDefault(g => g.UserGuess == userGuess);
                if (previousGuess != null)
                {
                    int turnsAgo = guesses.Count - guesses.IndexOf(previousGuess);
                    Console.WriteLine($"You guessed this number {turnsAgo} turns ago!");
                }

                if (userGuess > hiddenNumber)
                {
                    Console.WriteLine("Too high!");
                }
                else if (userGuess < hiddenNumber)
                {
                    Console.WriteLine("Too low!");
                }
                else
                {
                    Console.WriteLine($"You won! The answer was {hiddenNumber}.");
                    break;
                }

                guesses.Add(new Guess(userGuess));
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (userGuess != hiddenNumber);
    }
}
