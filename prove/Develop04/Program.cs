using System;
using System.ComponentModel.Design;
using System.Xml.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.WriteLine("Welcome to the Mindfulness Activity Program.");
        Console.WriteLine("Please select an activity to begin.");
        Console.WriteLine("1. Breathing");
        Console.WriteLine("2. Box Breathing");
        Console.WriteLine("3. Listening");
        Console.WriteLine("4. Reflection");
        Console.WriteLine("5. Exit");

        int choice;
        if (!int.TryParse(Console.ReadLine(), out choice))
        {
            choice = 0;
        }

        Console.Clear();

        if (choice == 5)
        {
            Console.WriteLine("Thank you for participating in the Mindfulness Activity Program.");
            Thread.Sleep(3000);
            Environment.Exit(0);
        }
        else if (choice < 1 || choice > 4)
        {
            Console.WriteLine("Invalid choice. Please try again.");
            Thread.Sleep(2000);
            Main(args);
        }

        Console.WriteLine("How long would you like to participate in this activity? (default 30 seconds)");
        int time;
        if (!int.TryParse(Console.ReadLine(), out time))
        {
            time = 30;
        }
        if (time < 1)
        {
            Console.WriteLine("Invalid time. Please try again.");
            Thread.Sleep(2000);
            Main(args);
        }

        Console.Clear();
        
        if (choice == 1)
        {
            BreathingActivity activity = new BreathingActivity(time);
            activity.Start();
        }
        else if (choice == 2)
        {
            BoxBreathing activity = new BoxBreathing(time);
            activity.Start();
        }
        else if (choice == 3)
        {
            ListingActivity activity = new ListingActivity(time);
            activity.Start();
        }
        else if (choice == 4)
        {
            ReflectionActivity activity = new ReflectionActivity(time);
            activity.Start();
        }
        Main(args);
    }
}