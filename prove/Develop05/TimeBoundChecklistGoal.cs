public class TimeBoundChecklistGoal : ChecklistGoal
{
    public TimeBoundChecklistGoal(string content, int points, int finalPoints, int times, DateTime endDate, int timesCompleated = 0) : base(content, points, finalPoints, times, timesCompleated, endDate)
    {
    }

    public override void DisplayGoal()
    {
        base.DisplayGoal();
        Console.WriteLine($"End Date: {_endDate}");
    }
}