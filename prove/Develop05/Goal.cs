using System.Diagnostics.Tracing;
using System.Dynamic;
using System.Net;

public class Goal
{
    protected string _content;
    protected DateTime _endDate;
    protected int _points;
    protected bool _repeating;
    protected int _timesCompleted = 0;
    protected int _maxTimes = 0;
    protected int _finalPoints = 0;

    protected Goal(string content, int points, bool repeating, int timesCompleted, DateTime endDate)
    {
        _content = content;
        _endDate = endDate;
        _points = points;
        _repeating = repeating;
        _timesCompleted = timesCompleted;
    }
    public string GetGoalLine()
    {
        return _content + ", " + _points + " points";
    }
    public string Serialize()
    {
        return $"{GetType().Name}|{_content}|{_points}|{_repeating}|{_endDate}|{_timesCompleted}|{_maxTimes}|{_finalPoints}";
    }

    public virtual (int points, bool end ) CheckGoal()
    {
        bool _continuegoal = _repeating && DateTime.Now < _endDate;
        _timesCompleted++;
        return (_points, _continuegoal);
    }

    public virtual void DisplayGoal()
    {
        Console.WriteLine($"Content: {_content}");
        Console.WriteLine($"Points: {_points}");
    }
}

