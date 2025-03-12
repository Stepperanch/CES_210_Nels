using System.Diagnostics.Tracing;

public class Goal
{
    protected string _content;
    protected DateTime _endDate;
    protected int _points;

    protected Goal(string content, int days, int points)
    {
        _content = content;
        _endDate = DateTime.Now.AddDays(days);
        _points = points;
    }

    protected Goal(string content, DateTime endDate, int points)
    {
        _content = content;
        _endDate = endDate;
        _points = points;
    }

    protected Goal(string content, int points)
    {
        _content = content;
        _endDate = DateTime.MinValue;
        _points = points;
    }

    public (int points, bool end) CheckGoal()
    {
        return (_points, DateTime.Now > _endDate);
    }

    public void DisplayGoal()
    {
        Console.WriteLine($"Content: {_content}");
        if (_endDate != DateTime.MinValue)
        {
            Console.WriteLine($"End Date: {_endDate}");
        }
        Console.WriteLine($"Points: {_points}");
    }
}

