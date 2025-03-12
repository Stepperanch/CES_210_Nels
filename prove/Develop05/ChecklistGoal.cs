public class ChecklistGoal : Goal
{

    public ChecklistGoal(string content, int points, int finalPoints, int times, DateTime endDate = default(DateTime)) : base(content, points, false, endDate)
    {
        _maxTimes = times;
        _finalPoints = finalPoints;
    }

    public override (int points, bool end) CheckGoal()
    {
        _timesCompleted++;
        if (_timesCompleted >= _maxTimes)
        {
            _points = _finalPoints;
        }
        bool continue_goal = _repeating && DateTime.Now < _endDate && _timesCompleted < _maxTimes;
        return (_points, continue_goal);
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"Times Completed: {_timesCompleted} / {_maxTimes}");
    }
}