using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Guess my number!");
        Console.WriteLine("I'm thinking of a number between 1 and 100.");
        Console.WriteLine("Can you guess it?");
        // Console.WriteLine("Give me a magic number, and then guess.");
        // Console.Write("I will tell you if your guess is too high or too low. ");
        
        do
        {
        //    Console.WriteLine("What is your magic number? ");
        //     int magicNumber = int.Parse(Console.ReadLine());
            Random random = new Random();
            int magicNumber = random.Next(1, 101);
            int guessCount = 0;

            while (true)
            {
                Console.Write("What is your guess? ");
                int guess = int.Parse(Console.ReadLine());
                if (guess == magicNumber)
                {
                    Console.WriteLine("You got it!");
                    break;
                }
                else if (guess < magicNumber)
                {
                    Console.WriteLine("Too low!");
                }
                else
                {
                    Console.WriteLine("Too high!");
                }
                guessCount++;
            } 
            Console.WriteLine($"It took you {guessCount} guesses.");
            Console.Write("Do you want to play again? (y/n) ");
        } while (Console.ReadLine().ToLower() == "y");
        Console.WriteLine("Goodbye!");
    }
}