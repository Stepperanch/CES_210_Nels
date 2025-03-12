public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int score = 0;
    private GoalBuilder _builder = new GoalBuilder();
    public void NewGoal()
    {
        _goals.Add(_builder.BuildGoal());
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
        (int points, bool end) = _goals[choice - 1].CheckGoal();
        score += points;
        if (end)
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
    private void LoadGoals()
    {
        string fileName = "goals.txt";
        
        using StreamReader reader = new StreamReader(fileName);
        string line;
        while ((line = reader.ReadLine()) != null)
        {
            _goals.Add(_builder.Deserialize())
        }
    }
    public void SaveGoals()
    {
        string fileName = "goals.txt";
        using StreamWriter writer = new StreamWriter(fileName);
        for (int i = 0; i < _goals.Count; i++)
        {
            writer.WriteLine(_goals[i].Serialize());
        }
    }
    public void GoalMenu()
    {
        Console.WriteLine("Welcome to the goal Manager");
        Console.WriteLine($"Your current score is {score}");
        Console.WriteLine("");
        Console.WriteLine("1. Add a new goal");
        Console.WriteLine("2. Display goals");
        Console.WriteLine("3. Check off a goal");
        Console.WriteLine("4. Delete a goal");
        Console.WriteLine("5. Load goals from file");
        Console.WriteLine("6. Save goals to file");
        Console.WriteLine("7. Exit");
        int choice = Convert.ToInt32(Console.ReadLine());
    }
}