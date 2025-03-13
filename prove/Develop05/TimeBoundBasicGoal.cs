public class TimeBoundBasicGoal : Goal
{
    public TimeBoundBasicGoal(string content, int points, DateTime endDate) : base(content, points, false, 0, endDate)
    {
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"End Date: {_endDate}");
    }
}