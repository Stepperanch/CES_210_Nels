using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        GoalManager goalManager = new GoalManager();
        goalManager.GoalMenu();
    }
}

// Added 3 aditional goals with time bound functionality
// Added a way to deleate goals
// Added a way to save the score as well as the goals
// Made it so that on the final iteration you see the bonus points for checklist goals