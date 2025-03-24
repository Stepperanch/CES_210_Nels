using System;

class Program
{
    static void Main(string[] args)
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("Welcome to the Event Manager!");
        Console.ResetColor();
        Console.WriteLine("What is the date and time of the event? (MM/dd/yy hh:mm tt) (*)");
    }
}