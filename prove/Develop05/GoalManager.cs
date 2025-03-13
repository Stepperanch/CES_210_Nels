public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private GoalBuilder Builder = new GoalBuilder();
    private Anamation Anamation = new Anamation();
    public void NewGoal()
    {
        _goals.Add(Builder.BuildGoal());
    }
    public void DisplayGoals()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            _goals[i].DisplayGoal();
        }
    }
    private void CheckOffGoal()
    {
        Console.WriteLine("Which goal would you like to check off?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetGoalLine()}");
        }
        int choice = Convert.ToInt32(Console.ReadLine());
        (int points, bool continuegoal) = _goals[choice - 1].CheckGoal();
        _score += points;
        if (!continuegoal)
        {
            _goals.RemoveAt(choice - 1);
        }
    }
    private void DeleteGoal()
    {
        Console.WriteLine("Which goal would you like to delete?");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetGoalLine()}");
        }
        int choice = Convert.ToInt32(Console.ReadLine());
        _goals.RemoveAt(choice - 1);
    }
    public void LoadGoals()
    {
        string fileName = "goals.txt";
        
        using StreamReader reader = new StreamReader(fileName);
        string line;
        _score = Convert.ToInt32(reader.ReadLine());
        while ((line = reader.ReadLine()) != null)
        {
            _goals.Add(Builder.Deserialize(line));
        }
    }
    public void SaveGoals()
    {
        string fileName = "goals.txt";
        using StreamWriter writer = new StreamWriter(fileName);
        writer.WriteLine(_score);
        for (int i = 0; i < _goals.Count; i++)
        {
            writer.WriteLine(Builder.Serialize(_goals[i]));
        }
    }
    public void GoalMenu()
    {
        Console.WriteLine("");
        Anamation.Spiner(2);
        Console.Clear();
        Console.WriteLine("");
        Console.WriteLine("Welcome to the goal Manager");
        Console.WriteLine($"Your current score is {_score}");
        Console.WriteLine("");
        Console.WriteLine("1. Add a new goal");
        Console.WriteLine("2. Display goals");
        Console.WriteLine("3. Check off a goal");
        Console.WriteLine("4. Delete a goal");
        Console.WriteLine("5. Load goals from file");
        Console.WriteLine("6. Save goals to file");
        Console.WriteLine("7. Exit");
        int choice = 0;
        try
        {
            choice = Convert.ToInt32(Console.ReadLine());
        }
        catch (Exception)
        {
            GoalMenu();
        }
        
        if (choice == 1)
        {
            NewGoal();
            Console.WriteLine("Goal added.");
        }
        else if (choice == 2)
        {
            DisplayGoals();
            Anamation.PressAnyKeyToContinue();
        }
        else if (choice == 3)
        {
            CheckOffGoal();
            Console.WriteLine("Goal checked off.");
        }
        else if (choice == 4)
        {
            DeleteGoal();
            Console.WriteLine("Goal deleted.");
        }
        else if (choice == 5)
        {
            LoadGoals();
            Console.WriteLine("Goals loaded successfully.");
        }
        else if (choice == 6)
        {
            SaveGoals();
            Console.WriteLine("Goals saved successfully.");
        }
        else if (choice == 7)
        {
            Console.WriteLine("Thank you for using the goal manager.");
            Anamation.Dashes(2);
            Console.Clear();
            return;
        }
        else if (choice == 8)
        {
            Console.WriteLine("Invalid choice. Please try again.");
        }
        GoalMenu();
    }
}