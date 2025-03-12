using System;

class Program
{
    static void Main(string[] args)
    {
        BasicGoal goal = new BasicGoal("Complete CES 210", 10);
        goal.DisplayGoal();
        Console.WriteLine($"Goal is complete: {goal.CheckGoal()}");
    }
}