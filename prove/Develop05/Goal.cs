using System.Diagnostics.Tracing;
using System.Net;

public class Goal
{
    protected string _content;
    protected DateTime _endDate;
    protected int _points;
    protected bool _repeating;
    protected int _timesCompleted=0;

    protected Goal(string content, int points, bool repeating, DateTime endDate)
    {
        _content = content;
        _endDate = endDate;
        _points = points;
        _repeating = repeating;
    }


    public virtual (int points, bool end) CheckGoal()
    {
        bool continue_goal = _repeating && DateTime.Now < _endDate;
        _timesCompleted++;
        return (_points, continue_goal);
    }

    public virtual void DisplayGoal()
    {
        Console.WriteLine($"Content: {_content}");
        Console.WriteLine($"Points: {_points}");
    }
}

