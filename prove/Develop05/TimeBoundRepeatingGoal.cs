public class TimeBoundRepeatingGoal : Goal
{
    public TimeBoundRepeatingGoal(string content, int points, DateTime endDate, int timesCompleated = 0) : base(content, points, true, timesCompleated, endDate)
    {
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"End Date: {_endDate}");
        Console.WriteLine($"Times Completed: {_timesCompleted}");
    }
}