public class ChecklistGoal : Goal
{

    public ChecklistGoal(string content, int points, int finalPoints, int times, int timesCompleated = 0, DateTime endDate = default(DateTime)) : base(content, points, true, timesCompleated, endDate)
    {
        _maxTimes = times;
        _finalPoints = finalPoints;
        _endDate = DateTime.MaxValue;
    }

    public override (int points, bool end) CheckGoal()
    {
        _timesCompleted++;
        int returnPoints = _points;
        if (_timesCompleted == _maxTimes-1)
        {
            _points = _finalPoints;
        }
        if (_timesCompleted >= _maxTimes)
        {
            returnPoints = _finalPoints;
        }
        bool continue_goal = _repeating && DateTime.Now < _endDate && _timesCompleted < _maxTimes;
        return (returnPoints, continue_goal);
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"Times Completed: {_timesCompleted} / {_maxTimes}");
    }
}