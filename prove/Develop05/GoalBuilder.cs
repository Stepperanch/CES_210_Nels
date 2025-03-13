public class GoalBuilder
{
    private string _content;
    private int _points;
    private int _finalPoints;
    private int _times;
    private int _days;
    private DateTime _endDate;

    public Goal BuildGoal()
    {
        Console.WriteLine("What type of goal would you like to create?");
        Console.WriteLine("1. Basic Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.WriteLine("4. Time Bound Basic Goal");
        Console.WriteLine("5. Time Bound Repeating Goal");
        Console.WriteLine("6. Time Bound Checklist Goal");
        int choice = Convert.ToInt32(Console.ReadLine());
        if (choice < 1 || choice > 6)
        {
            Console.WriteLine("Invalid choice. Please try again.");
            return BuildGoal();
        }

        Console.WriteLine("");
        Console.WriteLine("Enter the content of the goal:");
        _content = Console.ReadLine();

        Console.WriteLine("Enter the number of points for the goal:");
        _points = Convert.ToInt32(Console.ReadLine());

        if (choice == 1)
        {
            return new BasicGoal(_content, _points);
        } 
        else if (choice == 2)
        {
            return new EternalGoal(_content, _points);
        }
        else if (choice == 3)
        {
            Console.WriteLine("Enter the number of times the goal must be completed:");
            _times = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the number of points for the final completion:");
            _finalPoints = Convert.ToInt32(Console.ReadLine());
            return new ChecklistGoal(_content, _points, _finalPoints, _times);
        }
        else if (choice == 4 || choice == 5 || choice == 6)
        {
            Console.WriteLine("Would you like to set the day you want the goal to end(1), or the number of days till the goal ends(2)?");
            int endChoice = Convert.ToInt32(Console.ReadLine());
            if (endChoice == 1)
            {
                Console.WriteLine("Enter the year the goal ends:");
                int _year_endDate = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the month the goal ends:");
                int _month_endDate = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the day the goal ends:");
                int _day_endDate = Convert.ToInt32(Console.ReadLine());
                _endDate = new DateTime(_year_endDate, _month_endDate, _day_endDate);
                if (_endDate < DateTime.Now)
                {
                    Console.WriteLine("The end date must be in the future. Please try again.");
                    return BuildGoal();
                }
            }
            else
            {
                Console.WriteLine("Enter the number of days till the goal ends:");
                _days = Convert.ToInt32(Console.ReadLine());
                if (_days < 1)
                {
                    Console.WriteLine("The number of days must be greater than 0. Please try again.");
                    return BuildGoal();
                }
                _endDate = DateTime.Now.AddDays(_days);
            }
            if (choice == 4)
            {
                return new TimeBoundBasicGoal(_content, _points, _endDate);
            }
            else if (choice == 5)
            {
                return new TimeBoundRepeatingGoal(_content, _points, _endDate);
            }
            else
            {
                Console.WriteLine("Enter the number of times the goal must be completed:");
                _times = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the number of points for the final completion:");
                _finalPoints = Convert.ToInt32(Console.ReadLine());
                return new TimeBoundChecklistGoal(_content, _points, _finalPoints, _times, _endDate);
            }    
        }
        return null;
    }
    public Goal Deserialize(string line)
    {
        string[] parts = line.Split('|');
        string type = parts[0];
        string content = parts[1];
        int points = Convert.ToInt32(parts[2]);
        bool repeating = Convert.ToBoolean(parts[3]);
        DateTime endDate = Convert.ToDateTime(parts[4]);
        int timesCompleted = Convert.ToInt32(parts[5]);
        int maxTimes = Convert.ToInt32(parts[6]);
        int finalPoints = Convert.ToInt32(parts[7]);
        if (type == "BasicGoal")
        {
            return new BasicGoal(content, points);
        }
        else if (type == "EternalGoal")
        {
            return new EternalGoal(content, points, timesCompleted);
        }
        else if (type == "ChecklistGoal")
        {
            return new ChecklistGoal(content, points, finalPoints, maxTimes, timesCompleted);
        }
        else if (type == "TimeBoundBasicGoal")
        {
            return new TimeBoundBasicGoal(content, points, endDate);
        }
        else if (type == "TimeBoundRepeatingGoal")
        {
            return new TimeBoundRepeatingGoal(content, points, endDate, timesCompleted);
        }
        else if (type == "TimeBoundChecklistGoal")
        {
            return new TimeBoundChecklistGoal(content, points, finalPoints, maxTimes, endDate, timesCompleted);
        }
        return null;
    }
    public string Serialize(Goal goal)
    {
        return goal.Serialize();
    }
}
