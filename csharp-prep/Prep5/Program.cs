using System;

class Program
{
    static void DisplayWelcome()
        {
            Console.WriteLine("Welcome To the Program");
        }
    static string PromptUserName()
    {
        Console.Write("What is your name? ");
        return Console.ReadLine();
    }
    static int PromptUserNumber()
    {
        Console.Write("Enter a number: ");
        return int.Parse(Console.ReadLine());
    }
    static int SquareNumber(int number)
    {
        return (int)Math.Pow(number, 2);
    }
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName();
        int number = PromptUserNumber();
        int square = SquareNumber(number);
        DisplayResult(name, square);
    }
}