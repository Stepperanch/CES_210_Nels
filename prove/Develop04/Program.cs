using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        BreathingActivity breathing = new BreathingActivity(10);
        breathing.Start();
        ReflectionActivity reflection = new ReflectionActivity(30);
        reflection.Start();
    }
}