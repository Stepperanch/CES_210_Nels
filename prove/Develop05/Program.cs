using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        goalManager.NewGoal();
        
        goalManager.DisplayGoals();

        goalManager.SaveGoals();
    }
}