public class TimeBoundRepeatingGoal : Goal
{
    public TimeBoundRepeatingGoal(string content, int points, DateTime endDate) : base(content, points, true, endDate)
    {
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"End Date: {_endDate}");
        Console.WriteLine($"Times Completed: {_timesCompleted}");
    }
}