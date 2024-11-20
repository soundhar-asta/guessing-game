using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();
        int Answer = random.Next(1, 101);
        List<Guess> guesses = new List<Guess>();
        int userGuess = 0;

        do
        {
            Console.Write("Enter your number guess: ");
            string input = Console.ReadLine();

            if (int.TryParse(input, out userGuess))
            {
                var previousGuessnumber = guesses.FirstOrDefault(g => g.UserGuess == userGuess);
                if (previousGuessnumber != null)
                {
                    int turnsAgo = guesses.Count - guesses.IndexOf(previousGuessnumber);
                    Console.WriteLine($"You guessed this number {turnsAgo} turns ago!");
                }

                if (userGuess > Answer)
                {
                    Console.WriteLine("Too high!");
                }
                else if (userGuess < Answer)
                {
                    Console.WriteLine("Too low!");
                }
                else
                {
                    Console.WriteLine($"You won! The answer was {Answer}.");
                    break;
                }

                guesses.Add(new Guess(userGuess));
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a number.");
            }

        } while (userGuess != Answer);
    }
}
